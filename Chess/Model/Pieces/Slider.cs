using System.Collections.Generic;
using System.Linq;

namespace Chess.Model.Pieces
{
    public class Slider : PieceBase
    {
        public Slider(Square Position) : base(Position) { }

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
                                where P.Pos == CurrentSqaure //!!! TODO: Square.Equals !!!!
                                select P).SingleOrDefault();

                    if (Obstacle != null)
                    {
                        if (Obstacle.Player != Player)
                            LegalMoves.Add(CurrentSqaure);
                    }
                    else LegalMoves.Add(CurrentSqaure);
                }

            }

            return LegalMoves;
        }
    }
}
