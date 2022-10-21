using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_Chess.GameLogic.Pieces {
    public class Rook : IPiece {
        public string ResourceKey { get; }
        public bool IsBlackPiece { get; set; }

        public Rook(bool isBlackPiece) {
            IsBlackPiece = isBlackPiece;
            ResourceKey = (IsBlackPiece ? "Black" : "White") + GetType().Name;
        }

        public static List<(int, int)> GetPossibleMoves(IPiece piece, IPiece[,] board) {
            (int, int) position = ChessGame.FindPiece(board, piece);

        }
    }
}
