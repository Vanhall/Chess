using System.Collections.Generic;

namespace Chess.Model.Pieces
{
    public class Pawn : PieceBase
    {
        private Delta[] Attacks;
        private bool LongMove = false;
        public Pawn(Square Position, Player Player) : base(Position, Player)
        {
            Type = PieceType.Pawn;
            if (Player == Player.White)
            {
                Deltas = new Delta[] { new Delta(-1, 0) };
                Attacks = new Delta[] { new Delta(-1,-1), new Delta(-1, 1)};
                if (Pos.Rank == 6) LongMove = true;
            }
            else
            {
                Deltas = new Delta[] { new Delta(1, 0) };
                Attacks = new Delta[] { new Delta(1, -1), new Delta(1, 1) };
                if (Pos.Rank == 1) LongMove = true;
            }
        }

        public override IEnumerable<Square> GetPseudoLegalMoves(Board BoardState)
        {
            var Moves = new List<Square>();
            var D = Deltas[0];
            Square S = Pos + D;
            var Obstacle = BoardState.GetPiece(S);
            if (Obstacle == null)
            {
                Moves.Add(S);
                if (LongMove)
                {
                    S += D;
                    Obstacle = BoardState.GetPiece(S);
                    if (Obstacle == null) Moves.Add(S);
                }
            }

            S = Pos;
            foreach (Delta A in Attacks)
            {
                Obstacle = BoardState.GetPiece(S + A);
                if (Obstacle != null && Obstacle.Player != Player) Moves.Add(S + A);
            }
            return Moves;
        }
    }
}
