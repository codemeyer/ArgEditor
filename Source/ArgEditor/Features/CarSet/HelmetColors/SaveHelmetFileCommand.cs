using ArgEditor.Features.Persistence;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.HelmetColors
{
    public class SaveHelmetFileCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public SaveHelmetFileCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var helmetToSave = parameter as HelmetViewModel;

            if (helmetToSave == null) return;

            var path = _fileDialog.SelectLegacyHelmetFileToSave();

            if (path == string.Empty)
                return;

            LegacyHelmetFiles.Save(helmetToSave, path);
        }
    }
}
