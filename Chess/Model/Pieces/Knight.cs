using System.Collections.Generic;
using System.Linq;

namespace Chess.Model.Pieces
{
    public class Knight : PieceBase
    {
        public Knight(Square Position, Player Player) : base(Position, Player)
        {
            Type = PieceType.Knight;
            Deltas = new Delta[]
            {
                new Delta(-2, -1), new Delta(-2, 1),
                new Delta(-1, 2), new Delta(1, 2),
                new Delta(2, 1), new Delta(2, -1),
                new Delta(1, -2), new Delta(-1, -2)
            };
        }

        public override IEnumerable<Square> GetLegalMoves(IEnumerable<IPiece> BoardState)
        {
            var LegalMoves = new List<Square>();
            var S = Pos;

            foreach (Delta D in Deltas)
            {
                var Obstacle = (from P in BoardState
                                where P.Pos.Equals(S + D)
                                select P).SingleOrDefault();
                if ((Obstacle == null || Obstacle.Player != Player) && !(S + D).IsOffBoard())
                    LegalMoves.Add(S + D);
            }
            return LegalMoves;
        }
    }
}
