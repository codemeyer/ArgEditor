using System;
using System.Windows;
using ArgEditor.Features.Main;
using ArgEditor.Features.Persistence;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.ImportExport.ImportFrom
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

            // TODO: handle not being a name file
            var nameFileLoader = new NameFileLoader();
            try
            {
                nameFileLoader.Load(viewModel, path);

            }
            catch (Exception ex)
            {
                // TODO: via IMessageSomething
                MessageBox.Show("Failed to load the specified file. Make sure it is of the correct type and try again!",
                    "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
