using ArgEditor.Interactors;
using ArgEditor.Mappers;
using ArgEditor.ViewModels;

namespace ArgEditor.Commands
{
    public class LoadHelmetFileCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public LoadHelmetFileCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var helmetToUpdate = parameter as HelmetViewModel;

            if (helmetToUpdate == null) return;

            var path = _fileDialog.SelectLegacyHelmetFileToOpen();

            if (path == string.Empty)
                return;

            var helmetFromFile = LegacyHelmetFileLoader.Load(path);

            // TODO: create undo action

            Mapper.MapDataHelmetToViewModelHelmet(helmetFromFile, helmetToUpdate);
        }
    }
}
