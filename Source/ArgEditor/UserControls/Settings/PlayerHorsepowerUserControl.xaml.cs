using ArgEditor.ViewModels;
using System.Windows;
using System.Windows.Controls;
using ArgData;

namespace ArgEditor.UserControls.Settings
{
    /// <summary>
    /// Interaction logic for PlayerHorsepowerUserControl.xaml
    /// </summary>
    public partial class PlayerHorsepowerUserControl : UserControl
    {
        public PlayerHorsepowerUserControl()
        {
            InitializeComponent();
        }

        private void SetDefaultHorsepower_OnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).PlayerHorsepower = DefaultValues.PlayerHorsepowerValue;
        }
    }
}
