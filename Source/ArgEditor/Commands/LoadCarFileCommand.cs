using ArgEditor.Interactors;
using ArgEditor.Mappers;
using ArgEditor.ViewModels;

namespace ArgEditor.Commands
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

            var carFromFile = LegacyCarFileLoader.Load(path);

            // TODO: create undo action

            Mapper.MapDataCarToViewModelCar(carFromFile, carToUpdate);
        }
    }
}
