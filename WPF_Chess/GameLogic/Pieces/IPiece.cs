using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_Chess.GameLogic.Pieces {
    public interface IPiece {
        public string ResourceKey { get; }
        public bool IsBlackPiece { get; set; }

        public static abstract List<(int, int)> GetPossibleMoves(IPiece piece, IPiece[,] board);
    }
}
