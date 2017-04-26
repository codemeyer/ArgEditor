using ArgEditor.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ArgEditor.UserControls.Settings
{
    /// <summary>
    /// Interaction logic for WeatherSettingsUserControl.xaml
    /// </summary>
    public partial class WeatherSettingsUserControl : UserControl
    {
        public WeatherSettingsUserControl()
        {
            InitializeComponent();
        }

        private void ResetChanceOfRain_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).ChanceOfRainPercent = 6;
        }

        private void ResetRainAtFirstTrack_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).RainAtFirstTrack = false;
        }
    }
}
