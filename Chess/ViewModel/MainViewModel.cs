using Chess.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Chess.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<ChessPiece> PiecesPlacement { get; }
        public ObservableCollection<Sqare> LegalMoves { get; }
        public ICommand TestCommand { get; set; }
        
        public MainViewModel()
        {
            PiecesPlacement = new ObservableCollection<ChessPiece>
            {
                new ChessPiece{Pos=new Point(0, 6), Type=PieceType.Pawn, Player=Player.White},
                new ChessPiece{Pos=new Point(1, 6), Type=PieceType.Pawn, Player=Player.White},
                new ChessPiece{Pos=new Point(2, 6), Type=PieceType.Pawn, Player=Player.White},
                new ChessPiece{Pos=new Point(3, 6), Type=PieceType.Pawn, Player=Player.White},
                new ChessPiece{Pos=new Point(4, 6), Type=PieceType.Pawn, Player=Player.White},
                new ChessPiece{Pos=new Point(5, 6), Type=PieceType.Pawn, Player=Player.White},
                new ChessPiece{Pos=new Point(6, 6), Type=PieceType.Pawn, Player=Player.White},
                new ChessPiece{Pos=new Point(7, 6), Type=PieceType.Pawn, Player=Player.White},
                new ChessPiece{Pos=new Point(0, 7), Type=PieceType.Rook, Player=Player.White},
                new ChessPiece{Pos=new Point(1, 7), Type=PieceType.Knight, Player=Player.White},
                new ChessPiece{Pos=new Point(2, 7), Type=PieceType.Bishop, Player=Player.White},
                new ChessPiece{Pos=new Point(3, 7), Type=PieceType.King, Player=Player.White},
                new ChessPiece{Pos=new Point(4, 7), Type=PieceType.Queen, Player=Player.White},
                new ChessPiece{Pos=new Point(5, 7), Type=PieceType.Bishop, Player=Player.White},
                new ChessPiece{Pos=new Point(6, 7), Type=PieceType.Knight, Player=Player.White},
                new ChessPiece{Pos=new Point(7, 7), Type=PieceType.Rook, Player=Player.White},
                new ChessPiece{Pos=new Point(0, 1), Type=PieceType.Pawn, Player=Player.Black},
                new ChessPiece{Pos=new Point(1, 1), Type=PieceType.Pawn, Player=Player.Black},
                new ChessPiece{Pos=new Point(2, 1), Type=PieceType.Pawn, Player=Player.Black},
                new ChessPiece{Pos=new Point(3, 1), Type=PieceType.Pawn, Player=Player.Black},
                new ChessPiece{Pos=new Point(4, 1), Type=PieceType.Pawn, Player=Player.Black},
                new ChessPiece{Pos=new Point(5, 1), Type=PieceType.Pawn, Player=Player.Black},
                new ChessPiece{Pos=new Point(6, 1), Type=PieceType.Pawn, Player=Player.Black},
                new ChessPiece{Pos=new Point(7, 1), Type=PieceType.Pawn, Player=Player.Black},
                new ChessPiece{Pos=new Point(0, 0), Type=PieceType.Rook, Player=Player.Black},
                new ChessPiece{Pos=new Point(1, 0), Type=PieceType.Knight, Player=Player.Black},
                new ChessPiece{Pos=new Point(2, 0), Type=PieceType.Bishop, Player=Player.Black},
                new ChessPiece{Pos=new Point(3, 0), Type=PieceType.King, Player=Player.Black},
                new ChessPiece{Pos=new Point(4, 0), Type=PieceType.Queen, Player=Player.Black},
                new ChessPiece{Pos=new Point(5, 0), Type=PieceType.Bishop, Player=Player.Black},
                new ChessPiece{Pos=new Point(6, 0), Type=PieceType.Knight, Player=Player.Black},
                new ChessPiece{Pos=new Point(7, 0), Type=PieceType.Rook, Player=Player.Black}
            };
            LegalMoves = new ObservableCollection<Sqare>
            {
                new Sqare{Pos=new Point(4, 6)},
                new Sqare{Pos=new Point(4, 5)},
                new Sqare{Pos=new Point(4, 4)},
            };
            TestCommand = new RelayCommand(DoSimpleCommand);
        }
        
        private void DoSimpleCommand(object obj)
        {
            PiecesPlacement.RemoveAt(0);
        }

        public void SquareSelect(Point P)
        {
            char[] Ranks = new char[] { '8', '7', '6', '5', '4', '3', '2', '1' };
            char[] Files = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            int Rank = (int)Math.Floor(P.Y);
            int File = (int)Math.Floor(P.X);
            if (Rank < 0) Rank = 0;
            if (Rank > 7) Rank = 7;
            if (File < 0) File = 0;
            if (File > 7) File = 7;
            MessageBox.Show($"Square \'{Files[File]}{Ranks[Rank]}\' was clicked!");
        }
    }
}
