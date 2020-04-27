using System.Windows;
using System.Windows.Controls;
using ArgData;

namespace ArgEditor.Features.GameSettings
{
    /// <summary>
    /// Interaction logic for DamageSettingsUserControl.xaml
    /// </summary>
    public partial class DamageSettingsUserControl : UserControl
    {
        public DamageSettingsUserControl()
        {
            InitializeComponent();
        }

        private void ResetRetireAfterHittingWall_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as DamageSettingsViewModel).RetireAfterHittingWall = DefaultValues.RetireAfterHittingWall;
        }

        private void ResetRetireAfterHittingOtherCar_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as DamageSettingsViewModel).RetireAfterHittingOtherCar = DefaultValues.RetireAfterHittingOtherCar;
        }

        private void ResetDamageAfterHittingWall_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as DamageSettingsViewModel).DamageAfterHittingWall = DefaultValues.DamageAfterHittingWall;
        }

        private void ResetDamageAfterHittingOtherCar_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as DamageSettingsViewModel).DamageAfterHittingOtherCar = DefaultValues.DamageAfterHittingOtherCar;
        }

        private void ResetYellowFlags_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as DamageSettingsViewModel).YellowFlagsAfterSeconds = DefaultValues.YellowFlagsForStationaryCarsAfterSeconds;
        }

        private void ResetRemoveCars_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as DamageSettingsViewModel).RemoveCarsAfterSeconds = DefaultValues.RetiredCarsRemovedAfterSeconds;
        }
    }
}
