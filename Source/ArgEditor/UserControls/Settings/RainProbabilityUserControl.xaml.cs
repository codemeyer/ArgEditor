using ArgEditor.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ArgEditor.UserControls.Settings
{
    /// <summary>
    /// Interaction logic for RainProbabilityUserControl.xaml
    /// </summary>
    public partial class RainProbabilityUserControl : UserControl
    {
        public RainProbabilityUserControl()
        {
            InitializeComponent();
        }

        private void SetDefault_OnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).ChanceOfRainPercent = 6;
        }
    }
}
