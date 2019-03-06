using Chess.Model.Pieces;
using System.Collections.Generic;
using System.Windows;

namespace Chess.Model
{
    public class ChessPiece : RaisePropertyChangedBase, IPiece
    {
        private Square pos;
        public Square Pos
        {
            get => pos;
            set { pos = value; RaisePropertyChanged(); }
        }

        private PieceType type;
        public PieceType Type
        {
            get => type;
            set { type = value; /*RaisePropertyChanged();*/ }
        }

        private Player player;
        public Player Player
        {
            get => player;
            set { player = value; /*RaisePropertyChanged();*/ }
        }

        public IEnumerable<Square> GetLegalMoves(IEnumerable<IPiece> BoardState)
        {
            throw new System.NotImplementedException();
        }
    }
}
