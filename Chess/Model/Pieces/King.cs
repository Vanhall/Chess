using System.Collections.Generic;

namespace Chess.Model.Pieces
{
    public class King : PieceBase
    {
        public King(Square Position, Player Player) : base(Position, Player)
        {
            Type = PieceType.King;
            Deltas = new Delta[]
            {
                new Delta(-1, -1), new Delta(1, 1),
                new Delta(-1, 1), new Delta(1, -1),
                new Delta(-1, 0), new Delta(1, 0),
                new Delta(0, 1), new Delta(0, -1),
            };
        }

        public override IEnumerable<Square> GetLegalMoves(IEnumerable<IPiece> BoardState)
        {
            //TODO
            return new List<Square>();
        }
    }
}
