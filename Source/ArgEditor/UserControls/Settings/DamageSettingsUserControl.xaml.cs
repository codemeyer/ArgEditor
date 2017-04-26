using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ArgEditor.ViewModels;

namespace ArgEditor.UserControls.Settings
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
            (DataContext as DamageSettingsViewModel).RetireAfterHittingWall = 7424;
        }

        private void ResetRetireAfterHittingOtherCar_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as DamageSettingsViewModel).RetireAfterHittingOtherCar = 8192;
        }

        private void ResetDamageAfterHittingWall_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as DamageSettingsViewModel).DamageAfterHittingWall = 1792;
        }

        private void ResetDamageAfterHittingOtherCar_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as DamageSettingsViewModel).DamageAfterHittingOtherCar = 1792;
        }

        private void ResetYellowFlags_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as DamageSettingsViewModel).YellowFlagsAfterSeconds = 20;
        }

        private void ResetRemoveCars_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as DamageSettingsViewModel).RemoveCarsAfterSeconds = 15;
        }
    }
}
