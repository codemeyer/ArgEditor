using System.Windows;
using ArgEditor.Features.Main;
using RadioButton = System.Windows.Controls.RadioButton;
using UserControl = System.Windows.Controls.UserControl;

namespace ArgEditor.Features.CarSet.DriverPerformance
{
    /// <summary>
    /// Interaction logic for TeamDriverPerformanceTabUserControl.xaml
    /// </summary>
    public partial class TeamDriverPerformanceTabUserControl : UserControl
    {
        public TeamDriverPerformanceTabUserControl()
        {
            InitializeComponent();
        }

        private void PerformanceViewToggle(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
            {
                return;}

            if ((sender as RadioButton).Name.Equals("PerformanceToggleShowQualifying"))
            {
                (DataContext as MainViewModel).DriverPerformanceMetric = PerformanceMetric.Qualifying;
            }
            else
            {
                (DataContext as MainViewModel).DriverPerformanceMetric = PerformanceMetric.Race;
            }
        }
    }
}
