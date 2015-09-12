using System.Windows;
using System.Windows.Controls;
using ArgEditor.ViewModels;

namespace ArgEditor.UserControls
{
    /// <summary>
    /// Interaction logic for SettingsTabUserControl.xaml
    /// </summary>
    public partial class SettingsTabUserControl : UserControl
    {
        public SettingsTabUserControl()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).PlayerHorsepower = 716;
        }
    }
}
