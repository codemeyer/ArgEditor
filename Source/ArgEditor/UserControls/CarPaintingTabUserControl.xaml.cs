using System.Windows;
using System.Windows.Controls;
using ArgEditor.ViewModels;

namespace ArgEditor.UserControls
{
    /// <summary>
    /// Interaction logic for CarPaintingTabUserControl.xaml
    /// </summary>
    public partial class CarPaintingTabUserControl : UserControl
    {
        public CarPaintingTabUserControl()
        {
            InitializeComponent();
        }

        private void CarSelectionUserControl_OnSelectedTeamUpdated(object sender, RoutedEventArgs e)
        {
            int teamIndex = (e as SelectedTeamEventArgs).TeamIndex;

            if (teamIndex > 0)
            {
                PaintCarUserControl.Visibility = Visibility.Visible;
                PaintCarAlternativeUserControl.Visibility = Visibility.Hidden;
            }
            else
            {
                PaintCarAlternativeUserControl.Visibility = Visibility.Visible;
                PaintCarUserControl.Visibility = Visibility.Hidden;
            }

            DataContextViewModel.SelectTeamByIndex(teamIndex);
        }

        private MainViewModel DataContextViewModel
        {
            get
            {
                return DataContext as MainViewModel;
            }
        }
    }
}
