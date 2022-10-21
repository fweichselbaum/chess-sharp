using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF_Chess.GameLogic.Pieces;

namespace WPF_Chess.GameLogic {
    public class ChessGame {

        public MainWindow Window { get; set; }
        public IPiece[,] Pieces { get; set; } = GetStartingPieces();

        public (int, int) LastClicked { get; set; }

        public (int,int)[,] Indicators { get; set; } = new (int, int)[8, 8];

        public ChessGame(MainWindow window) {
            Window = window;
        }

        public static IPiece[,] GetStartingPieces() {

            IPiece[,] pieces = new IPiece[8, 8];

            // black
            pieces[0, 0] = new Rook(true);
            pieces[7, 0] = new Rook(true);

            // white
            pieces[0, 7] = new Rook(false);
            pieces[7, 7] = new Rook(false);

            return pieces;
        }

        public void Start() {
            RenderBoard();
            RenderFieldLabels();
            RenderPieces();
        }
        private void RenderBoard() {
            for (int col = 0; col < 8; col++) {
                for (int row = ((col % 2 == 0) ? 1 : 0); row < 8; row += 2) {
                    Rectangle rect = new() { Fill = Brushes.Peru };
                    Window.BoardGrid.Children.Add(rect);
                    Grid.SetColumn(rect, col);
                    Grid.SetRow(rect, row);
                }
            }
        }

        private void RenderFieldLabels() {
            for (int col = 0; col < 8; col++) {
                LabelTextBlock textTop = new() { Text = ((char)('A' + col)).ToString() };
                Window.MainGrid.Children.Add(textTop);
                Grid.SetColumn(textTop, col + 1);
                Grid.SetRow(textTop, 0);
                LabelTextBlock textBot = new() { Text = ((char)('A' + col)).ToString() };
                Window.MainGrid.Children.Add(textBot);
                Grid.SetColumn(textBot, col + 1);
                Grid.SetRow(textBot, 9);
            }
            for (int row = 0; row < 8; row++) {
                LabelTextBlock textTop = new() { Text = (row + 1).ToString() };
                Window.MainGrid.Children.Add(textTop);
                Grid.SetColumn(textTop, 0);
                Grid.SetRow(textTop, 8 - row);
                LabelTextBlock textBot = new() { Text = (row + 1).ToString() };
                Window.MainGrid.Children.Add(textBot);
                Grid.SetColumn(textBot, 9);
                Grid.SetRow(textBot, 8 - row);
            }
        }
        
        private void RenderPieces() {
            for (int col = 0; col < 8; col++) {
                for (int row = 0; row < 8; row++) {
                    IPiece currentPiece = Pieces[col, row];
                    if (currentPiece != null) {
                        RenderPiece(currentPiece, (col, row));
                    }
                }
            }
        }
        
        private void RenderPiece(IPiece piece, (int, int) position) {
            Image image = new() { Source = (ImageSource)Window.FindResource(piece.ResourceKey) };
            image.MouseLeftButtonDown += PieceClicked;
            Window.BoardGrid.Children.Add(image);
            Grid.SetColumn(image, position.Item1);
            Grid.SetRow(image, position.Item2);
        }
        
        private void PieceClicked(object sender, MouseButtonEventArgs e) {
            Image clickedImage = (Image)sender;
            (int, int) index = (Grid.GetColumn(clickedImage), 7 - Grid.GetRow(clickedImage));
            LastClicked = index;
            IPiece clickedPiece = Pieces[index.Item1, index.Item2];
        }

        public static (int,int) FindPiece(IPiece[,] board, IPiece piece) {
            for (int col = 0; col < 8; col++) {
                for (int row = 0; row < 8; row++) {
                    if (board[col, row] == piece) {
                        return (col, row);
                    }
                }
            }
            throw new ArgumentException("Not found");
        }
    }
}

