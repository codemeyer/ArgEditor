using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

            byte currentColor = clickedPolygonEvent.Property.GetValue(selectedCar);

            clickedPolygonEvent.Property.SetValue(selectedCar, DataContextViewModel.Palette.SelectedColor);

            int index = DataContextViewModel.Teams.IndexOf(DataContextViewModel.SelectedTeam);
            var change = new ColorChange
            {
                OldValue = currentColor,
                NewValue = DataContextViewModel.Palette.SelectedColor,
                Property = clickedPolygonEvent.Property,
                PaintedElement = PaintedElement.Car
            };
            App.CarColorUndoStacks[index].Push(change);
            App.CarColorRedoStacks[index].Clear();
        }

        private void PaintPitCrewUserControl_OnClickedPolygon(object sender, RoutedEventArgs e)
        {
            var clickedPolygonEvent = e as ClickedPolygonEventArgs;
            var selectedPitCrew = DataContextViewModel.SelectedTeam.PitCrew;
            //PropertyInfo prop = selectedPitCrew.GetType().GetProperty(clickedPolygonEvent.PolygonName);
            //prop.SetValue(selectedPitCrew, DataContextViewModel.Palette.SelectedColor, null);

            byte currentColor = clickedPolygonEvent.Property.GetValue(selectedPitCrew);

            clickedPolygonEvent.Property.SetValue(selectedPitCrew, DataContextViewModel.Palette.SelectedColor);

            int index = DataContextViewModel.Teams.IndexOf(DataContextViewModel.SelectedTeam);
            var change = new ColorChange
            {
                OldValue = currentColor,
                NewValue = DataContextViewModel.Palette.SelectedColor,
                Property = clickedPolygonEvent.Property,
                PaintedElement = PaintedElement.PitCrew
            };
            App.CarColorUndoStacks[index].Push(change);
            App.CarColorRedoStacks[index].Clear();
        }

        private MainViewModel DataContextViewModel
        {
            get
            {
                return DataContext as MainViewModel;
            }
        }

        private void CarPaintingTab_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                if (e.Key == Key.Z)
                {
                    int index = DataContextViewModel.Teams.IndexOf(DataContextViewModel.SelectedTeam);

                    if (App.CarColorUndoStacks[index].Count == 0)
                        return;

                    var latestChange = App.CarColorUndoStacks[index].Pop();
                    var viewModel = GetViewModelForChange(DataContextViewModel.SelectedTeam, latestChange.PaintedElement);

                    latestChange.Property.SetValue(viewModel, latestChange.OldValue);

                    var reverseChange = new ColorChange
                    {
                        NewValue = latestChange.OldValue,
                        OldValue = latestChange.NewValue,
                        Property = latestChange.Property,
                        PaintedElement = latestChange.PaintedElement
                    };
                    App.CarColorRedoStacks[index].Push(reverseChange);
                }
                // TODO: refactor until you drop!
                if (e.Key == Key.Y)
                {
                    int index = DataContextViewModel.Teams.IndexOf(DataContextViewModel.SelectedTeam);

                    if (App.CarColorRedoStacks[index].Count == 0)
                        return;

                    var latestChange = App.CarColorRedoStacks[index].Pop();
                    var viewModel = GetViewModelForChange(DataContextViewModel.SelectedTeam, latestChange.PaintedElement);

                    latestChange.Property.SetValue(viewModel, latestChange.OldValue);

                    var reverseChange = new ColorChange
                    {
                        NewValue = latestChange.OldValue,
                        OldValue = latestChange.NewValue,
                        Property = latestChange.Property,
                        PaintedElement = latestChange.PaintedElement
                    };
                    App.CarColorUndoStacks[index].Push(reverseChange);
                }
            }
        }

        private object GetViewModelForChange(TeamViewModel selectedTeam, PaintedElement paintedElement)
        {
            if (paintedElement == PaintedElement.Car)
                return selectedTeam.Car;
            else
                return selectedTeam.PitCrew;
        }
    }
}
