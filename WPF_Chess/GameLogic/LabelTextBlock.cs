using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPF_Chess.GameLogic {
    public class LabelTextBlock : TextBlock {
        public LabelTextBlock() {
            FontSize = 20;
            Foreground = Brushes.SaddleBrown;
            FontFamily = new FontFamily("Courier New");
            FontWeight = FontWeights.Bold;
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
