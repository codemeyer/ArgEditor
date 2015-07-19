using System.Collections.Generic;
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

            if (clickedPolygonEvent.PaletteTool == PaletteTool.Paint)
            {
                AddUndoAction(clickedPolygonEvent.Property, selectedCar, PaintedElement.Car);
            }
            else if (clickedPolygonEvent.PaletteTool == PaletteTool.PickupColor)
            {
                byte colorIndex = clickedPolygonEvent.Property.GetValue(selectedCar);
                DataContextViewModel.Palette.SelectedColor = colorIndex;
            }
        }

        private void PaintPitCrewUserControl_OnClickedPolygon(object sender, RoutedEventArgs e)
        {
            var clickedPolygonEvent = e as ClickedPolygonEventArgs;
            var selectedPitCrew = DataContextViewModel.SelectedTeam.PitCrew;

            if (clickedPolygonEvent.PaletteTool == PaletteTool.Paint)
            {
                AddUndoAction(clickedPolygonEvent.Property, selectedPitCrew, PaintedElement.PitCrew);
            }
            else if (clickedPolygonEvent.PaletteTool == PaletteTool.PickupColor)
            {
                byte colorIndex = clickedPolygonEvent.Property.GetValue(selectedPitCrew);
                DataContextViewModel.Palette.SelectedColor = colorIndex;
            }
        }

        private void AddUndoAction(ColorPropertyWrapper property, object viewModel, PaintedElement paintedElement)
        {
            byte currentColor = property.GetValue(viewModel);

            property.SetValue(viewModel, DataContextViewModel.Palette.SelectedColor);

            int index = DataContextViewModel.Teams.IndexOf(DataContextViewModel.SelectedTeam);
            var change = new ColorChange
            {
                OldValue = currentColor,
                NewValue = DataContextViewModel.Palette.SelectedColor,
                Property = property,
                PaintedElement = paintedElement
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
                int index = DataContextViewModel.Teams.IndexOf(DataContextViewModel.SelectedTeam);

                if (e.Key == Key.Z)
                {
                    if (App.CarColorUndoStacks[index].Count == 0) { return; }

                    ProcessColorChangeStacks(App.CarColorUndoStacks[index], App.CarColorRedoStacks[index]);
                }

                if (e.Key == Key.Y)
                {
                    if (App.CarColorRedoStacks[index].Count == 0) { return; }

                    ProcessColorChangeStacks(App.CarColorRedoStacks[index], App.CarColorUndoStacks[index]);
                }
            }
        }

        private void ProcessColorChangeStacks(Stack<ColorChange> popStack, Stack<ColorChange> pushStack)
        {
            var latestChange = popStack.Pop();
            var viewModel = GetViewModelForChange(DataContextViewModel.SelectedTeam, latestChange.PaintedElement);

            latestChange.Property.SetValue(viewModel, latestChange.OldValue);

            var reverseChange = new ColorChange
            {
                NewValue = latestChange.OldValue,
                OldValue = latestChange.NewValue,
                Property = latestChange.Property,
                PaintedElement = latestChange.PaintedElement
            };
            pushStack.Push(reverseChange);
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
