using System.Collections.Generic;

namespace WPF_Chess.GameLogic.Pieces {
    internal static interface IPieceHelpers {
        List<(int, int)> GetPossibleMoves(IPiece[,] board);
    }
}