using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Chess.GameLogic.Pieces {
    public class Rook : IPiece {
        public string ResourceKey { get; }
        public (int, int) Position { get; set; }
        public bool IsBlackPiece { get; set; }

        public Rook((int, int) position, bool isBlackPiece) {
            Position = position;
            IsBlackPiece = isBlackPiece;
            ResourceKey = (IsBlackPiece ? "Black" : "White") + GetType().Name;
        }
        public List<(int, int)> GetMoves() {
            throw new NotImplementedException();
        }
    }
}
