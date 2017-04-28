using ArgEditor.Interactors;
using ArgEditor.ViewModels;

namespace ArgEditor.Commands
{
    public class ImportFromNameFileCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public ImportFromNameFileCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            string path = _fileDialog.SelectAnyFileToOpen();

            if (string.IsNullOrEmpty(path)) { return; }

            var nameFileLoader = new NameFileLoader();
            nameFileLoader.Load(viewModel, path);
        }
    }
}
