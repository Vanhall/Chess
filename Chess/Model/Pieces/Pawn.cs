using System.Collections.Generic;
using System.Linq;

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

        public override IEnumerable<Square> GetLegalMoves(IEnumerable<IPiece> BoardState)
        {
            var LegalMoves = new List<Square>();
            var D = Deltas[0];
            Square S = Pos + D;
            LegalMoves.Add(S);
            if (LongMove) LegalMoves.Add(S + D);
            return LegalMoves;
        }
    }
}
