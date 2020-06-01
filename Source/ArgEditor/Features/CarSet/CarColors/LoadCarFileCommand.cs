using ArgEditor.Features.Persistence;
using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSet.CarColors
{
    public class LoadCarFileCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public LoadCarFileCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var team = parameter as TeamViewModel;

            if (team == null)
                return;

            var carToUpdate = team.Car;

            var path = _fileDialog.SelectLegacyCarFileToOpen();

            if (path == string.Empty)
                return;

            var carFromFile = LegacyCarFiles.Load(path);

            var mappedEditingViewModel = new CarEditingViewModel();
            Mapper.MapDataCarToViewModelCar(carFromFile, mappedEditingViewModel);

            var colorChangeList = ColorChangeListCreator.CreateColorChangeListForCarPasteOperation(carToUpdate, mappedEditingViewModel);
            App.CarColorUndoStacks[team.Index].Push(colorChangeList);
            App.CarColorRedoStacks[team.Index].Clear();

            Mapper.MapDataCarToViewModelCar(carFromFile, carToUpdate);
        }
    }
}
