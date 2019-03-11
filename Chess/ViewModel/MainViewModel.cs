using Chess.Model;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Windows;

namespace Chess.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        //private SourceList<Square> selectedPieceMoves;
        public IObservableCollection<Square> SelectedPieceMoves { get; }
        
        public Board Board { get; }

        public ReactiveCommand<Square, Unit> ProcessSquareClick { get; set; }

        public Player Turn { get; set; }

        private Square SelectedPiecePos { get; set; }

        private Dictionary<Square, List<Square>> LegalMoves;

        private MoveGenerator MoveGen;

        public MainViewModel()
        {
            Board = new Board();

            //selectedPieceMoves = new SourceList<Square>();
            SelectedPieceMoves = new ObservableCollectionExtended<Square>();
            //selectedPieceMoves.Connect().Bind(SelectedPieceMoves).Subscribe();
            
            ProcessSquareClick = ReactiveCommand.Create<Square>(x => ProcessClick(x));

            Turn = Player.White;
            SelectedPiecePos = null;

            // TODO: Generate initial Moves here
            MoveGen = new MoveGenerator();
            LegalMoves = MoveGen.GenerateMoves(Board, Turn);
        }
        
        private void ProcessClick(Square S)
        {
            var ClickedPiece = Board.GetPiece(S);
            
            if (SelectedPiecePos == null)
            {
                if (ClickedPiece != null && ClickedPiece.Player == Turn)
                {
                    SelectPiece(S);
                }
                else
                {
                    DeselectPiece();
                }
            }
            else
            {
                if (LegalMoves[SelectedPiecePos].Contains(S))
                {
                    MakeMove(SelectedPiecePos, S);
                }
                else
                {
                    if (ClickedPiece != null && ClickedPiece.Player == Turn)
                    {
                        SelectPiece(S);
                    }
                    else
                    {
                        DeselectPiece();
                    }
                }
            }
        }

        private void SelectPiece(Square S)
        {
            SelectedPiecePos = S;
            SelectedPieceMoves.Clear();
            SelectedPieceMoves.Add(SelectedPiecePos);
            SelectedPieceMoves.AddRange(LegalMoves[SelectedPiecePos]);
        }

        private void DeselectPiece()
        {
            SelectedPiecePos = null;
            SelectedPieceMoves.Clear();
        }

        private void MakeMove(Square From, Square To)
        {
            Board.MovePiece(From, To);
            DeselectPiece();
            Turn = (Turn == Player.White) ? Player.Black : Player.White;
            LegalMoves = MoveGen.GenerateMoves(Board, Turn);
        }

        public void Square_clicked(Point P)
        {
            int Rank = (int)Math.Floor(P.Y);
            int File = (int)Math.Floor(P.X);
            if (Rank < 0) Rank = 0;
            if (Rank > 7) Rank = 7;
            if (File < 0) File = 0;
            if (File > 7) File = 7;
            
            ProcessSquareClick.Execute(new Square(File, Rank)).Subscribe();
        }
    }
}
