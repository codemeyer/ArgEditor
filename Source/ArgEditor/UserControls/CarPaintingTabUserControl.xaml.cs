using ArgEditor.ViewModels;
using System.Windows;
using System.Windows.Controls;

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

            DataContextViewModel.SelectTeamByIndex(teamIndex);
        }

        private void PaintCarUserControl_OnClickedPolygon(object sender, RoutedEventArgs e)
        {
            var clickedPolygonEvent = e as ClickedPolygonEventArgs;
            if (clickedPolygonEvent == null) return;

            var selectedCar = DataContextViewModel.SelectedTeam.Car;

            var activePaletteTool = DataContextViewModel.Palette.ActivePaletteTool;
            // LOL

            PaletteActionService.PerformPaletteAction(DataContextViewModel, activePaletteTool, clickedPolygonEvent.Property, selectedCar, PaintedElement.Car);
        }

        private void PaintPitCrewUserControl_OnClickedPolygon(object sender, RoutedEventArgs e)
        {
            var clickedPolygonEvent = e as ClickedPolygonEventArgs;
            if (clickedPolygonEvent == null) return;

            var selectedPitCrew = DataContextViewModel.SelectedTeam.PitCrew;

            var activePaletteTool = DataContextViewModel.Palette.ActivePaletteTool;

            PaletteActionService.PerformPaletteAction(DataContextViewModel, activePaletteTool, clickedPolygonEvent.Property, selectedPitCrew, PaintedElement.PitCrew);
        }

        private MainViewModel DataContextViewModel => DataContext as MainViewModel;
    }
}
