using Chess.Model.Pieces;
using System.Windows;

namespace Chess.Model
{
    public class Square : RaisePropertyChangedBase
    {
        public static char[] Ranks = { '8', '7', '6', '5', '4', '3', '2', '1' };
        public static char[] Files = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        
        private int rank;
        public int Rank
        {
            get => rank;
            set { rank = value; RaisePropertyChanged(); }
        }

        private int file;
        public int File
        {
            get => file;
            set { file = value; RaisePropertyChanged(); }
        }

        public Square()
        {
            File = 0;
            Rank = 0;
        }

        public Square(int Vertical, int Horizontal)
        {
            File = Vertical;
            Rank = Horizontal;
        }

        public static Square operator +(Square S, Delta D)
        {
            return new Square(S.Rank + D.V, S.File + D.H);
        }

        public static Square operator +(Delta D, Square S)
        {
            return new Square(S.Rank + D.V, S.File + D.H);
        }

        public bool IsOffBoard()
        {
            return (file < 0 || file > 7 || rank < 0 || rank > 7) ? true : false;
        }

        public override string ToString()
        {
            return $"{Files[File]}{Ranks[Rank]}";
        }
    }
}
