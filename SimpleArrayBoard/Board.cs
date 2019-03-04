using System;
using System.Collections.Generic;

namespace SimpleArrayBoard
{
    public class Board
    {
        enum Pieces
        {
            Empty = 0,
            King = 1,
            Queen = 2 | Slider,
            Bishop = 3 | Slider,
            Knight = 4,
            Rook = 5 | Slider,
            Pawn = 6,
            Black = 8,
            Slider = 16
        }

        public enum Ranks { r8, r7, r6, r5, r4, r3, r2, r1 }
        public enum Files { a, b, c, d, e, f, g, h }
        
        private Pieces[,] Field;

        public Board()
        {
            Field = new Pieces[8, 8];
            SetFromFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR");
        }

        public Board(string FEN)
        {
            Field = new Pieces[8, 8];
            SetFromFEN(FEN);
        }

        private bool isSlider(Pieces Piece) => ((Piece & Pieces.Slider) != 0) ? true : false;

        public void Clear()
        {
            if (Field != null)
            {
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                        Field[i, j] = Pieces.Empty;
            }
        }

        public void SetFromFEN(string FEN)
        {
            var FENToPiece = new Dictionary<char, Pieces>
            {
                {'K', Pieces.King },
                {'Q', Pieces.Queen },
                {'B', Pieces.Bishop },
                {'N', Pieces.Knight },
                {'R', Pieces.Rook },
                {'P', Pieces.Pawn },
                {'k', Pieces.King | Pieces.Black },
                {'q', Pieces.Queen | Pieces.Black },
                {'b', Pieces.Bishop | Pieces.Black },
                {'n', Pieces.Knight | Pieces.Black },
                {'r', Pieces.Rook | Pieces.Black },
                {'p', Pieces.Pawn | Pieces.Black},
            };

            int CurrentRank = (int)Ranks.r8;
            int CurrentFile = (int)Files.a;
            foreach(char C in FEN)
            {
                if (C == '/')
                {
                    CurrentRank++;
                    CurrentFile = (int)Files.a;
                    continue;
                }

                if (char.IsDigit(C))
                    for (int i = CurrentFile; CurrentFile < i + C - '0'; CurrentFile++)
                        Field[CurrentRank, CurrentFile] = Pieces.Empty;
                else
                    Field[CurrentRank, ++CurrentFile] = FENToPiece[C];
            }
        }
    }
}
