using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Security.Cryptography;
using WPF_Chess.GameLogic;
using System.Windows.Markup;
using WPF_Chess.GameLogic.Pieces;
using System.Windows.Automation;

namespace WPF_Chess {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public Board Board { get; set; }
        public MainWindow() {
            InitializeComponent();

            Board = new();
            DrawBoard();
        }

        private void DrawBoard() {
            DrawFields();
            DrawFieldLabels();
            DrawPieces();
        }

        private void DrawPieces() {
            Board.BlackPieces.ForEach(piece => DrawPiece(piece));
            Board.WhitePieces.ForEach(piece => DrawPiece(piece));
        }

        private void DrawPiece(IPiece piece) {
            Trace.WriteLine(piece.ResourceKey);
            Image image = new() { Source = (ImageSource)FindResource(piece.ResourceKey)};
            //image.MouseLeftButtonDown += ToggleIndicator;
            BoardGrid.Children.Add(image);
            Grid.SetColumn(image, piece.Position.Item1);
            Grid.SetRow(image, piece.Position.Item2);
        }

        private void DrawFields() {
            for (int col = 0; col < 8; col++) {
                for (int row = ((col % 2 == 0) ? 1 : 0); row < 8; row += 2) {
                    Rectangle rect = new() { Fill = Brushes.Peru };
                    BoardGrid.Children.Add(rect);
                    Grid.SetColumn(rect, col);
                    Grid.SetRow(rect, row);
                }
            }
        }

        private void DrawFieldLabels() {
            for (int col = 0; col < 8; col++) {
                LabelTextBlock textTop = new() { Text = ((char)('A' + col)).ToString() };
                MainGrid.Children.Add(textTop);
                Grid.SetColumn(textTop, col + 1);
                Grid.SetRow(textTop, 0);
                LabelTextBlock textBot = new() { Text = ((char)('A' + col)).ToString() };
                MainGrid.Children.Add(textBot);
                Grid.SetColumn(textBot, col + 1);
                Grid.SetRow(textBot, 9);
            }
            for (int row = 0; row < 8; row++) {
                LabelTextBlock textTop = new() { Text = (row + 1).ToString() };
                MainGrid.Children.Add(textTop);
                Grid.SetColumn(textTop, 0);
                Grid.SetRow(textTop, 8 - row);
                LabelTextBlock textBot = new() { Text = (row + 1).ToString() };
                MainGrid.Children.Add(textBot);
                Grid.SetColumn(textBot, 9);
                Grid.SetRow(textBot, 8 - row);
            }
        }
    }
}
