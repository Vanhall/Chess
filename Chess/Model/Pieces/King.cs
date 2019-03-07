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

        public override IEnumerable<Square> GetPseudoLegalMoves(IEnumerable<IPiece> BoardState)
        {
            var Moves = new List<Square>();
            var S = Pos;

            foreach (Delta D in Deltas)
            {
                var Obstacle = GetSquare(S + D, BoardState);
                if ((Obstacle == null || Obstacle.Player != Player) && !(S + D).IsOffBoard())
                    Moves.Add(S + D);
            }
            return Moves;
        }
    }
}
