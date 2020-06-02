using System.Windows;

namespace ArgEditor.Features.CarSet.SwapDrivers
{
    /// <summary>
    /// Interaction logic for SwapDriversWindow.xaml
    /// </summary>
    public partial class SwapDriversWindow : Window
    {
        public SwapDriversWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
