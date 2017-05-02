using ArgEditor.Interactors;
using ArgEditor.ViewModels;
using System;

namespace ArgEditor.Commands.Setups
{
    public class LoadSingleSetupFileCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public LoadSingleSetupFileCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var viewModel = parameter as SetupViewModel;

            if (viewModel == null) { return; }

            string path = _fileDialog.SelectAnyFileToOpen();

            if (string.IsNullOrEmpty(path))
                return;

            // or just do stuff in here?
            try
            {
                new SetupFileLoader().Load(viewModel, path);

            }
            catch (Exception)
            {
                // inject cmd instead?
                var msg = new ShowErrorMessageCommand();
                msg.Execute("The specified file does not appear to be a setup file!");
            }
        }
    }
}
