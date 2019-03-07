using Chess.Model;
using Chess.Model.Pieces;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;
using System.Windows;

namespace Chess.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        private SourceList<Square> currentPieceMoves;
        public IObservableCollection<Square> CurrentPieceMoves { get; }

        private SourceCache<IPiece, Square> board;
        public IObservableCollection<IPiece> Board { get; }

        public ReactiveCommand<Square, Unit> ProcessSquareClick { get; set; }

        public MainViewModel()
        {
            board = new SourceCache<IPiece, Square>(k => k.Pos);
            board.AddOrUpdate(new IPiece[] {
                new Pawn(new Square(0, 6), Player.White),
                new Pawn(new Square(1, 6), Player.White),
                new Pawn(new Square(2, 6), Player.White),
                new Pawn(new Square(3, 6), Player.White),
                new Pawn(new Square(4, 6), Player.White),
                new Pawn(new Square(5, 6), Player.White),
                new Pawn(new Square(6, 6), Player.White),
                new Pawn(new Square(7, 6), Player.White),
                new Rook(new Square(0, 7), Player.White),
                new Knight(new Square(1, 7), Player.White),
                new Bishop(new Square(2, 7), Player.White),
                new Queen(new Square(3, 7), Player.White),
                new King(new Square(4, 7), Player.White),
                new Bishop(new Square(5, 7), Player.White),
                new Knight(new Square(6, 7), Player.White),
                new Rook(new Square(7, 7), Player.White),
                new Pawn(new Square(0, 1), Player.Black),
                new Pawn(new Square(1, 1), Player.Black),
                new Pawn(new Square(2, 1), Player.Black),
                new Pawn(new Square(3, 1), Player.Black),
                new Pawn(new Square(4, 1), Player.Black),
                new Pawn(new Square(5, 1), Player.Black),
                new Pawn(new Square(6, 1), Player.Black),
                new Pawn(new Square(7, 1), Player.Black),
                new Rook(new Square(0, 0), Player.Black),
                new Knight(new Square(1, 0), Player.Black),
                new Bishop(new Square(2, 0), Player.Black),
                new Queen(new Square(3, 0), Player.Black),
                new King(new Square(4, 0), Player.Black),
                new Bishop(new Square(5, 0), Player.Black),
                new Knight(new Square(6, 0), Player.Black),
                new Rook(new Square(7, 0), Player.Black),
                //test pieces
                new Knight(new Square(1, 2), Player.White),
                new Bishop(new Square(5, 4), Player.Black),
                new Rook(new Square(2, 4), Player.Black),
                new Queen(new Square(7, 3), Player.White),
                new King(new Square(2, 3), Player.Black),
                });
            Board = new ObservableCollectionExtended<IPiece>();
            board.Connect().Bind(Board).Subscribe();

            currentPieceMoves = new SourceList<Square>();
            CurrentPieceMoves = new ObservableCollectionExtended<Square>();
            currentPieceMoves.Connect().Bind(CurrentPieceMoves).Subscribe();
            
            ProcessSquareClick = ReactiveCommand.Create<Square>(x => DoSimpleCommand(x));
        }
        
        private void DoSimpleCommand(object obj)
        {
            if (obj is Square S)
            {
                var kek = board.Items.SingleOrDefault(x => x.Pos.Equals(S));

                if (kek != null)
                {
                    currentPieceMoves.Clear();
                    currentPieceMoves.AddRange(kek.GetPseudoLegalMoves(Board.ToArray()));
                }
            }
            //if (board.Count > 0) board.Remove(new Square(4, 6));
        }

        public void SquareSelect(Point P)
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
