using ArgEditor.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
