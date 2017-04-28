using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArgEditor.Interactors;
using ArgEditor.ViewModels;

namespace ArgEditor.Commands
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

            // or just do stuff in here?
            new SetupFileLoader().Load(viewModel, path);
        }
    }
}
