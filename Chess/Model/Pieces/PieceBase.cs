using System.Collections.Generic;

namespace Chess.Model.Pieces
{
    public abstract class PieceBase : RaisePropertyChangedBase, IPiece
    {
        private Square pos;
        public Square Pos
        {
            get => pos;
            set { pos = value; RaisePropertyChanged(); }
        }

        public PieceType Type { get; protected set; }

        public Player Player { get; protected set; }

        protected IEnumerable<Delta> Deltas { get;  set; }

        public PieceBase(Square Position)
        {
            pos = Position;
        }

        public abstract IEnumerable<Square> GetLegalMoves(IEnumerable<IPiece> BoardState);
    }
}
