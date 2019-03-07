using System.Collections.Generic;

namespace Chess.Model.Pieces
{
    public interface IPiece
    {
        Square Pos { get; set; }
        PieceType Type { get; }
        Player Player { get; }
        IEnumerable<Square> GetPseudoLegalMoves(IEnumerable<IPiece> BoardState);
    }
}
