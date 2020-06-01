using ArgEditor.Features.Persistence;
using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSet.CarColors
{
    public class SaveCarFileCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public SaveCarFileCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var team = parameter as TeamViewModel;

            if (team == null)
                return;

            var carToSave = team.Car;

            var path = _fileDialog.SelectLegacyCarFileToSave();

            if (path == string.Empty)
                return;

            LegacyCarFiles.Save(carToSave, path);
        }
    }
}
