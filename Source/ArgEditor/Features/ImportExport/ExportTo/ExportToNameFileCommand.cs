using ArgEditor.Features.Main;
using ArgEditor.Features.Persistence;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.ImportExport.ExportTo
{
    public class ExportToNameFileCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public ExportToNameFileCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            string path = _fileDialog.SelectNameFileToSave();

            if (string.IsNullOrEmpty(path)) { return; }

            var fileExporter = new NameFileSaver();
            fileExporter.Save(viewModel, path);
        }
    }
}
