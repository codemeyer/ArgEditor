using System.Windows;
using System.Windows.Controls;
using ArgEditor.Features.CarSet;

namespace ArgEditor.Features.Palette
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
