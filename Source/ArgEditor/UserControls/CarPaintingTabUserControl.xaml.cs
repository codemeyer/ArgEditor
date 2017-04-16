using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ArgData;
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

            DataContextViewModel.SelectTeamByIndex(teamIndex);
        }

        private void PaintCarUserControl_OnClickedPolygon(object sender, RoutedEventArgs e)
        {
            var clickedPolygonEvent = e as ClickedPolygonEventArgs;
            var selectedCar = DataContextViewModel.SelectedTeam.Car;

            var activePaletteTool = DataContextViewModel.Palette.ActivePaletteTool;
            // LOL

            if (activePaletteTool == PaletteTool.Paint)
            {
                AddUndoAction(clickedPolygonEvent.Property, selectedCar, PaintedElement.Car, DataContextViewModel.Palette.SelectedColor);
            }
            else if (activePaletteTool == PaletteTool.PickupColor)
            {
                byte colorIndex = clickedPolygonEvent.Property.GetValue(selectedCar);
                DataContextViewModel.Palette.SelectedColor = colorIndex;
            }
            else if (activePaletteTool == PaletteTool.Darker)
            {
                byte colorIndex = clickedPolygonEvent.Property.GetValue(selectedCar);
                int darker = Palette.GetDarkerColor(colorIndex);
                //clickedPolygonEvent.Property.SetValue(selectedCar, (byte)darker);
                AddUndoAction(clickedPolygonEvent.Property, selectedCar, PaintedElement.Car, (byte)darker);
            }
            else if (activePaletteTool == PaletteTool.Brighter)
            {
                byte colorIndex = clickedPolygonEvent.Property.GetValue(selectedCar);
                int brighter = Palette.GetBrighterColor(colorIndex);
                //clickedPolygonEvent.Property.SetValue(selectedCar, (byte)brighter);
                AddUndoAction(clickedPolygonEvent.Property, selectedCar, PaintedElement.Car, (byte)brighter);
            }
        }

        private void PaintPitCrewUserControl_OnClickedPolygon(object sender, RoutedEventArgs e)
        {
            var clickedPolygonEvent = e as ClickedPolygonEventArgs;
            var selectedPitCrew = DataContextViewModel.SelectedTeam.PitCrew;

            var activePaletteTool = DataContextViewModel.Palette.ActivePaletteTool;

            if (activePaletteTool == PaletteTool.Paint)
            {
                AddUndoAction(clickedPolygonEvent.Property, selectedPitCrew, PaintedElement.PitCrew, DataContextViewModel.Palette.SelectedColor);
            }
            else if (activePaletteTool == PaletteTool.PickupColor)
            {
                byte colorIndex = clickedPolygonEvent.Property.GetValue(selectedPitCrew);
                DataContextViewModel.Palette.SelectedColor = colorIndex;
            }
            else if (activePaletteTool == PaletteTool.Darker)
            {
                byte colorIndex = clickedPolygonEvent.Property.GetValue(selectedPitCrew);
                int darker = Palette.GetDarkerColor(colorIndex);
                AddUndoAction(clickedPolygonEvent.Property, selectedPitCrew, PaintedElement.PitCrew, (byte)darker);
            }
            else if (activePaletteTool == PaletteTool.Brighter)
            {
                byte colorIndex = clickedPolygonEvent.Property.GetValue(selectedPitCrew);
                int brighter = Palette.GetBrighterColor(colorIndex);
                AddUndoAction(clickedPolygonEvent.Property, selectedPitCrew, PaintedElement.PitCrew, (byte)brighter);
            }
        }

        private void AddUndoAction(ColorPropertyWrapper property, object viewModel, PaintedElement paintedElement, byte newColor)
        {
            byte currentColor = property.GetValue(viewModel);

            property.SetValue(viewModel, newColor);

            int index = DataContextViewModel.Teams.IndexOf(DataContextViewModel.SelectedTeam);
            var change = new ColorChange
            {
                OldValue = currentColor,
                NewValue = newColor,
                Property = property,
                PaintedElement = paintedElement
            };
            var changeList = new ColorChangeList { change };

            App.CarColorUndoStacks[index].Push(changeList);
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
            // TODO: use proper WPF commands instead?
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                if (e.Key == Key.Z)
                {
                    PerformUndo();
                }

                if (e.Key == Key.Y)
                {
                    PerformRedo();
                }
            }
        }

        // TODO: put somewhere else, yeah?
        public void PerformUndo()
        {
            int index = DataContextViewModel.Teams.IndexOf(DataContextViewModel.SelectedTeam);

            if (App.CarColorUndoStacks[index].Count == 0) { return; }

            ProcessColorChangeStacks(App.CarColorUndoStacks[index], App.CarColorRedoStacks[index]);
        }

        public void PerformRedo()
        {
            int index = DataContextViewModel.Teams.IndexOf(DataContextViewModel.SelectedTeam);

            if (App.CarColorRedoStacks[index].Count == 0) { return; }

            ProcessColorChangeStacks(App.CarColorRedoStacks[index], App.CarColorUndoStacks[index]);
        }

        private void ProcessColorChangeStacks(Stack<ColorChangeList> popStack, Stack<ColorChangeList> pushStack)
        {
            var latestChanges = popStack.Pop();
            var reverseChanges = new ColorChangeList();

            foreach (var latestChange in latestChanges)
            {
                var viewModel = GetViewModelForChange(DataContextViewModel.SelectedTeam, latestChange.PaintedElement);

                latestChange.Property.SetValue(viewModel, latestChange.OldValue);

                var reverseChange = new ColorChange
                {
                    NewValue = latestChange.OldValue,
                    OldValue = latestChange.NewValue,
                    Property = latestChange.Property,
                    PaintedElement = latestChange.PaintedElement
                };
                reverseChanges.Add(reverseChange);
            }

            pushStack.Push(reverseChanges);
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
