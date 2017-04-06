using ArgEditor.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ArgEditor.UserControls.Settings
{
    /// <summary>
    /// Interaction logic for RainAtFirstTrackUserControl.xaml
    /// </summary>
    public partial class RainAtFirstTrackUserControl : UserControl
    {
        public RainAtFirstTrackUserControl()
        {
            InitializeComponent();
        }

        private void SetDefault_OnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).RainAtFirstTrack = false;
        }
    }
}
