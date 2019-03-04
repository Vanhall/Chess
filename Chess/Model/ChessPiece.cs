using System.Windows;

namespace Chess.Model
{
    public class ChessPiece : RaisePropertyChangedBase
    {
        private Point pos;
        public Point Pos
        {
            get => pos;
            set { pos = value; RaisePropertyChanged(); }
        }

        private PieceType type;
        public PieceType Type
        {
            get => type;
            set { type = value; RaisePropertyChanged(); }
        }

        private Player player;
        public Player Player
        {
            get => player;
            set { player = value; RaisePropertyChanged(); }
        }
    }
}
