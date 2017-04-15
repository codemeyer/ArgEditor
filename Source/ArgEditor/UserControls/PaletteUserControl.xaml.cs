using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using ArgEditor.ViewModels;

namespace ArgEditor.UserControls
{
    /// <summary>
    /// Interaction logic for PaletteUserControl.xaml
    /// </summary>
    public partial class PaletteUserControl : UserControl
    {
        public PaletteUserControl()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            byte colorIndex = ((PaletteColorViewModel)(sender as Rectangle).DataContext).ColorIndex;

            DataContextViewModel.SelectedColor = colorIndex;
        }

        private PaletteViewModel DataContextViewModel
        {
            get { return DataContext as PaletteViewModel; }
        }

        private void PaletteToolFill_Click(object sender, RoutedEventArgs e)
        {
            DataContextViewModel.ActivePaletteTool = PaletteTool.Paint;
        }

        private void PaletteToolPickup_Click(object sender, RoutedEventArgs e)
        {
            DataContextViewModel.ActivePaletteTool = PaletteTool.PickupColor;
        }

        private void PaletteToolDarker_Click(object sender, RoutedEventArgs e)
        {
            DataContextViewModel.ActivePaletteTool = PaletteTool.Darker;
        }

        private void PaletteToolBrighter_Click(object sender, RoutedEventArgs e)
        {
            DataContextViewModel.ActivePaletteTool = PaletteTool.Brighter;
        }
    }
}
