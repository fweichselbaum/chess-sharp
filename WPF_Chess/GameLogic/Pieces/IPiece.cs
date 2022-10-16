using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Chess.GameLogic.Pieces {
    public interface IPiece {
        public string ResourceKey { get; }
        public (int, int) Position { get; set; }
        public bool IsBlackPiece { get; set; }
        public List<(int,int)> GetMoves();
    }
}
