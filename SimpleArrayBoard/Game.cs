using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleArrayBoard
{
    public enum Side { Black, White };

    class Game
    {
        [Flags]
        enum CastlingFlags
        {
            None = 0,
            WhiteKingSide = 2,
            WhiteQueenSide = 4,
            BlackKingSide = 8,
            BlackQueenSide = 16,
            //All = WhiteKingSide | WhiteQueenSide | BlackKingSide | BlackQueenSide
        }
        CastlingFlags CastlingRights;

        Side Turn { get; }

        private int HalfMovesClock;
        private int FullMoves;
        private Board Board;
        
    }
}
