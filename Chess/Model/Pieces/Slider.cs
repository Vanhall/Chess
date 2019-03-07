using System.Collections.Generic;
using System.Linq;

namespace Chess.Model.Pieces
{
    public class Slider : PieceBase
    {
        public Slider(Square Position, Player Player) : base(Position, Player) { }

        public override IEnumerable<Square> GetLegalMoves(IEnumerable<IPiece> BoardState)
        {
            var LegalMoves = new List<Square>();
            foreach (var D in Deltas)
            {
                Square CurrentSqaure = Pos;
                IPiece Obstacle = null;
                while (!(CurrentSqaure+=D).IsOffBoard() && Obstacle == null)
                {
                    Obstacle = (from P in BoardState
                                where P.Pos.Equals(CurrentSqaure)
                                select P).SingleOrDefault();

                    if ((Obstacle == null || Obstacle.Player != Player) && !CurrentSqaure.IsOffBoard())
                        LegalMoves.Add(CurrentSqaure);
                }

            }
            return LegalMoves;
        }
    }
}
