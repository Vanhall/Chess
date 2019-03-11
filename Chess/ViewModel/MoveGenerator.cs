using Chess.Model;
using System.Collections.Generic;
using System.Linq;

namespace Chess.ViewModel
{
    public class MoveGenerator
    {
        public Dictionary<Square, List<Square>> GenerateMoves(Board Board, Player Turn)
        {
            var Moves = new Dictionary<Square, List<Square>>();
            var Friends = Board.Pieces.Where(x => x.Player == Turn);

            foreach (var Piece in Friends)
            {
                var Pos = Piece.Pos;
                var PieceMoves = new List<Square>();

                #region Temp
                //switch(Piece.Type)
                //{
                //    case PieceType.Bishop:
                //    case PieceType.Rook:
                //    case PieceType.Queen:
                //        {
                //            foreach (var D in Piece.Deltas)
                //            {
                //                Square CurrentSqaure = new Square(Pos);
                //                IPiece Obstacle = null;
                //                while (!(CurrentSqaure += D).IsOffBoard() && Obstacle == null)
                //                {
                //                    Obstacle = Board.GetPiece(CurrentSqaure);

                //                    if ((Obstacle == null || Obstacle.Player != Turn) && !CurrentSqaure.IsOffBoard())
                //                        PieceMoves.Add(CurrentSqaure);
                //                }

                //            }
                //        }
                //        break;
                //    case PieceType.Knight:
                //    case PieceType.King:
                //        {
                //            foreach (Delta D in Piece.Deltas)
                //            {
                //                var Obstacle = Board.GetPiece(Pos + D);
                //                if ((Obstacle == null || Obstacle.Player != Turn) && !(Pos + D).IsOffBoard())
                //                    PieceMoves.Add(Pos + D);
                //            }
                //        }
                //        break;
                //    case PieceType.Pawn:
                //        {
                //            var D = Piece.Deltas[0];
                //            Square S = Pos + D;
                //            var Obstacle = Board.GetPiece(Pos);
                //            if (Obstacle == null)
                //            {
                //                PieceMoves.Add(S);
                //                //if (LongMove)
                //                //{
                //                //    S += D;
                //                //    Obstacle = Board.GetPiece(Pos);
                //                //    if (Obstacle == null) Moves.Add(S);
                //                //}
                //            }

                //            S = Pos;
                //            for (int i = 1; i < 3; i++)
                //            {
                //                Obstacle = Board.GetPiece(Pos + Piece.Deltas[i]);
                //                if (Obstacle != null && Obstacle.Player != Turn) PieceMoves.Add(Pos + Piece.Deltas[i]);
                //            }
                //        }
                //        break;
                //}
                #endregion
                Moves.Add(Pos, Piece.GetPseudoLegalMoves(Board).ToList());
            }
            return Moves;
        }
    }
}
