using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF_Chess.GameLogic;
using WPF_Chess.GameLogic.Pieces;

namespace WPF_Chess {
    public partial class MainWindow : Window {

        public ChessGame Game { get; set; }
        public MainWindow() {
            InitializeComponent();

            Game = new ChessGame(this);
            Game.Start();
        }


        //private void ToggleIndicator(object sender, MouseButtonEventArgs e) {
        //    Image clicked = (Image)sender;
        //    (int, int) clickedPosition = (Grid.GetColumn(clicked), Grid.GetRow(clicked));
        //    IPiece clickedPiece = Board.Pieces.Find(piece => piece.Position == clickedPosition);
        //    clickedPiece.GetMoves().ForEach(move => {
        //        if (move == clickedPosition) {
        //            return;
        //        }
        //        if (Board.Pieces
        //                .FindAll(piece => piece.IsBlackPiece != clickedPiece.IsBlackPiece)
        //                .Select(piece => piece.Position).Contains(clickedPosition)) {
        //            return;
        //        }
        //        if (Board.Pieces.Select(p => p.Position).Contains(clickedPosition)) {
        //            return;
        //        }
        //        // TODO: schlagen
        //        // TODO: rochade
        //        // TODO: figur tauschen
        //        // TODO: 
        //    });
        //}

    }
}
