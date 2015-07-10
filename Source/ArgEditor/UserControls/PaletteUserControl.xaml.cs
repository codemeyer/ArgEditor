using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ArgEditor.ViewModels;

namespace ArgEditor.UserControls
{
    /// <summary>
    /// Interaction logic for PaletteUserControl.xaml
    /// </summary>
    public partial class PaletteUserControl : UserControl
    {
        // TODO: this was copy-paste-with-haste
        public PaletteUserControl()
        {
            InitializeComponent();

            for (int i = 0; i <= 255; i++)
            {
                var colorSquare = new Rectangle
                {
                    Fill = new SolidColorBrush(PaletteHelper.GetColor(i)),
                    Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                    StrokeThickness = 0.5,
                    Width = 20,
                    Height = 20,
                    Tag = i
                };

                colorSquare.MouseEnter += (sender, args) => (sender as Rectangle).Stroke = new SolidColorBrush(Color.FromRgb(200,200,200));
                colorSquare.MouseLeave += (sender, args) => (sender as Rectangle).Stroke = new SolidColorBrush(Color.FromRgb(0,0,0));

                colorSquare.MouseDown += ColorSquareOnMouseDown;

                PaletteContainer.Children.Add(colorSquare);
            }
        }

        private void ColorSquareOnMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (mouseButtonEventArgs.LeftButton != MouseButtonState.Pressed) { return; }

            byte colorIndex = Convert.ToByte((sender as Rectangle).Tag);
            //byte colorIndex = ((byte)(sender as Rectangle).Tag);

            DataContextViewModel.SelectedColor = colorIndex;
        }

        private MainViewModel DataContextViewModel
        {
            get { return DataContext as MainViewModel; }
        }
    }
}
