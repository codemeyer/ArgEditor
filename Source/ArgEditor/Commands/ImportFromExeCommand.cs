using ArgEditor.Interactors;
using ArgEditor.ViewModels;

namespace ArgEditor.Commands
{
    public class ImportFromExeCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public ImportFromExeCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            string path = _fileDialog.SelectGpExeFile();

            if (string.IsNullOrEmpty(path)) { return; }

            var fileImporter = new GpExeFileReader();
            fileImporter.UpdateViewModelFromExe(viewModel, path);
        }
    }
}
