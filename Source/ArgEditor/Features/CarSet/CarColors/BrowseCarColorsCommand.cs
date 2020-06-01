using ArgEditor.Features.Persistence;
using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSet.CarColors
{
    public class BrowseCarColorsCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public BrowseCarColorsCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var team = parameter as TeamViewModel;

            if (team == null)
                return;

            var viewModel = new BrowseCarColorsViewModel(_fileDialog);

            if (App.LatestBrowseCarColorsViewModel != null)
            {
                viewModel = App.LatestBrowseCarColorsViewModel;
                viewModel.LoadReload(viewModel.FilePath);
            }

            var window = new BrowseCarColorsWindow
            {
                Owner = System.Windows.Application.Current.MainWindow,
                DataContext = viewModel
            };

            var result = window.ShowDialog();

            if (result == true)
            {
                if (viewModel.SelectedCar != null)
                {
                    var colorChangeList = ColorChangeListCreator.CreateColorChangeListForCarPasteOperation(team.Car, viewModel.SelectedCar);
                    App.CarColorUndoStacks[team.Index].Push(colorChangeList);
                    App.CarColorRedoStacks[team.Index].Clear();

                    Mapper.MapCarEditingViewModel(viewModel.SelectedCar, team.Car);
                }

                if (viewModel.SelectedPitCrew != null)
                {
                    // TODO: undo
                    Mapper.MapPitCrewViewModel(viewModel.SelectedPitCrew, team.PitCrew);
                }
            }

            if (!string.IsNullOrEmpty(viewModel.FilePath))
            {
                // remember this
                App.LatestBrowseCarColorsViewModel = viewModel;
            }
        }
    }
}
