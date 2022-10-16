using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Chess.GameLogic.Pieces;

namespace WPF_Chess.GameLogic {
    public class Board {
        public List<IPiece> WhitePieces { get; set; } = GetStartingPiecesWhite();
        public List<IPiece> BlackPieces { get; set; } = GetStartingPiecesBlack();
        public List<Move> Indicators { get; set; }

        public static List<IPiece> GetStartingPiecesBlack() {
            List<IPiece> pieces = new() {
                new Rook   ((0, 0),true),
                new Knight ((1, 0),true),
                new Bishop ((2, 0),true),
                new Queen  ((3, 0),true),
                new King   ((4, 0),true),
                new Bishop ((5, 0),true),
                new Knight ((6, 0),true),
                new Rook   ((7, 0),true)
            };
            for (int col = 0; col < 8; col++) {
                pieces.Add(new Pawn ((col, 1), true ));
            }
            return pieces;
        }
        public static List<IPiece> GetStartingPiecesWhite() {
            List<IPiece> pieces = new() {
                new Rook   ((0, 7), false),
                new Knight ((1, 7), false),
                new Bishop ((2, 7), false),
                new Queen  ((3, 7), false),
                new King   ((4, 7), false),
                new Bishop ((5, 7), false),
                new Knight ((6, 7), false),
                new Rook   ((7, 7), false)
            };
            for (int col = 0; col < 8; col++) {
                pieces.Add(new Pawn ((col, 6), false));
            }
            return pieces;
        }

    }
}

