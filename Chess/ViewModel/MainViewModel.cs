using Chess.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using Chess.Model.Pieces;
using ReactiveUI;
using DynamicData;

namespace Chess.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        public ObservableCollection<IPiece> PiecesPlacement { get; }
        public ObservableCollection<Square> LegalMoves { get; }
        public ICommand TestCommand { get; set; }

        public SourceCache<IPiece, Square> MyDict = new SourceCache<IPiece, Square>(k => k.Pos);

        public MainViewModel()
        {
            PiecesPlacement = new ObservableCollection<IPiece>
            {
                new Pawn(new Square(0, 6), Player.White),
                new Pawn(new Square(1, 6), Player.White),
                new Pawn(new Square(2, 6), Player.White),
                new Pawn(new Square(3, 6), Player.White),
                new Pawn(new Square(4, 6), Player.White),
                new Pawn(new Square(5, 6), Player.White),
                new Pawn(new Square(6, 6), Player.White),
                new Pawn(new Square(7, 6), Player.White),
                new ChessPiece{Pos = new Square(0, 7), Type=PieceType.Rook, Player=Player.White},
                new ChessPiece{Pos = new Square(1, 7), Type=PieceType.Knight, Player=Player.White},
                new ChessPiece{Pos = new Square(2, 7), Type=PieceType.Bishop, Player=Player.White},
                new ChessPiece{Pos = new Square(3, 7), Type=PieceType.King, Player=Player.White},
                new ChessPiece{Pos = new Square(4, 7), Type=PieceType.Queen, Player=Player.White},
                new ChessPiece{Pos = new Square(5, 7), Type=PieceType.Bishop, Player=Player.White},
                new ChessPiece{Pos = new Square(6, 7), Type=PieceType.Knight, Player=Player.White},
                new ChessPiece{Pos = new Square(7, 7), Type=PieceType.Rook, Player=Player.White},
                new Pawn(new Square(0, 1), Player.Black),
                new Pawn(new Square(1, 1), Player.Black),
                new Pawn(new Square(2, 1), Player.Black),
                new Pawn(new Square(3, 1), Player.Black),
                new Pawn(new Square(4, 1), Player.Black),
                new Pawn(new Square(5, 1), Player.Black),
                new Pawn(new Square(6, 1), Player.Black),
                new Pawn(new Square(7, 1), Player.Black),
                new ChessPiece{Pos = new Square(0, 0), Type=PieceType.Rook, Player=Player.Black},
                new ChessPiece{Pos = new Square(1, 0), Type=PieceType.Knight, Player=Player.Black},
                new ChessPiece{Pos = new Square(2, 0), Type=PieceType.Bishop, Player=Player.Black},
                new ChessPiece{Pos = new Square(3, 0), Type=PieceType.King, Player=Player.Black},
                new ChessPiece{Pos = new Square(4, 0), Type=PieceType.Queen, Player=Player.Black},
                new ChessPiece{Pos = new Square(5, 0), Type=PieceType.Bishop, Player=Player.Black},
                new ChessPiece{Pos = new Square(6, 0), Type=PieceType.Knight, Player=Player.Black},
                new ChessPiece{Pos = new Square(7, 0), Type=PieceType.Rook, Player=Player.Black}
            };

            MyDict.AddOrUpdate(PiecesPlacement);
            LegalMoves = new ObservableCollection<Square>();

            TestCommand = new RelayCommand(DoSimpleCommand);
        }
        
        private void DoSimpleCommand(object obj)
        {
            if(PiecesPlacement.Count > 0) PiecesPlacement.RemoveAt(0);
            if (LegalMoves.Count > 0) LegalMoves.RemoveAt(0);
        }

        public void SquareSelect(Point P)
        {
            int Rank = (int)Math.Floor(P.Y);
            int File = (int)Math.Floor(P.X);
            if (Rank < 0) Rank = 0;
            if (Rank > 7) Rank = 7;
            if (File < 0) File = 0;
            if (File > 7) File = 7;
            
            var CS = (from S in PiecesPlacement
                      where S.Pos.Rank == Rank && S.Pos.File == File
                      select S).SingleOrDefault();
            if (CS != null && CS.Type == PieceType.Pawn)
            {
                LegalMoves.Clear();
                var newLM = CS.GetLegalMoves(PiecesPlacement);
                foreach (var item in newLM) LegalMoves.Add(item);
            }

        }
    }
}
