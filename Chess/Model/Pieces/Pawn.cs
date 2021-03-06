﻿using ReactiveUI;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace Chess.Model.Pieces
{
    public class Pawn : PieceBase
    {
        private Delta[] attacks;

        private ObservableAsPropertyHelper<bool> longMove;
        private bool LongMove => longMove.Value;

        public Pawn(Square Position, Player Player) : base(Position, Player)
        {
            Type = PieceType.Pawn;
            if (Player == Player.White)
            {
                Deltas = new Delta[] { new Delta(-1, 0) };
                attacks = new Delta[] { new Delta(-1,-1), new Delta(-1, 1)};
            }
            else
            {
                Deltas = new Delta[] { new Delta(1, 0) };
                attacks = new Delta[] { new Delta(1, -1), new Delta(1, 1) };
            }
            longMove = this.WhenAny(x => x.Pos, _ => new bool())
                .Select(x => Pos.Rank == 6 && Player == Player.White || Pos.Rank == 1 && Player == Player.Black)
                .ToProperty(this, x => x.LongMove);
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
            foreach (Delta A in attacks)
            {
                Obstacle = BoardState.GetPiece(S + A);
                if (Obstacle != null && Obstacle.Player != Player) Moves.Add(S + A);
            }
            return Moves;
        }
    }
}
