using System.Collections.Generic;
using System.Linq;
using ReactiveUI;

namespace Chess.Model.Pieces
{
    public abstract class PieceBase : ReactiveObject, IPiece
    {
        private Square pos;
        public Square Pos
        {
            get => pos;
            set => this.RaiseAndSetIfChanged(ref pos, value);
        }

        public PieceType Type { get; protected set; }

        public Player Player { get; protected set; }

        protected Delta[] Deltas { get;  set; }

        public PieceBase(Square Position, Player Player)
        {
            pos = Position;
            this.Player = Player;
        }

        public abstract IEnumerable<Square> GetPseudoLegalMoves(IEnumerable<IPiece> BoardState);

        protected IPiece GetSquare(Square Sq, IEnumerable<IPiece> Board) => (from P in Board
                                                                           where P.Pos.Equals(Sq)
                                                                           select P).SingleOrDefault();
    }
}
