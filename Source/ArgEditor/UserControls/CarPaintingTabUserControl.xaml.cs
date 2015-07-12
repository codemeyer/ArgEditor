using System.Reflection;
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

        private void PaintCarUserControl_OnClickedPolygon(object sender, RoutedEventArgs e)
        {
            var clickedPolygonEvent = e as ClickedPolygonEventArgs;
            var selectedCar = DataContextViewModel.SelectedTeam.Car;
            PropertyInfo prop = selectedCar.GetType().GetProperty(clickedPolygonEvent.PolygonName);
            prop.SetValue(selectedCar, DataContextViewModel.Palette.SelectedColor, null);
        }

        private void PaintPitCrewUserControl_OnClickedPolygon(object sender, RoutedEventArgs e)
        {
            var clickedPolygonEvent = e as ClickedPolygonEventArgs;
            var selectedPitCrew = DataContextViewModel.SelectedTeam.PitCrew;
            PropertyInfo prop = selectedPitCrew.GetType().GetProperty(clickedPolygonEvent.PolygonName);
            prop.SetValue(selectedPitCrew, DataContextViewModel.Palette.SelectedColor, null);
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
