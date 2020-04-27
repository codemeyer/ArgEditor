using System;
using ArgData;
using ArgEditor.Features.Application.Shared;
using ArgEditor.Features.Persistence;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSetupEditing
{
    public class LoadMultiSetupFileCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public LoadMultiSetupFileCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var viewModel = parameter as MultiSetupViewModel;

            if (viewModel == null) { return; }

            string path = _fileDialog.SelectAnyFileToOpen();

            if (string.IsNullOrEmpty(path))
                return;

            try
            {
                var multiSetup = new SetupReader().ReadMultiple(path);

                viewModel.SeparateSetups = multiSetup.SeparateSetups;

                for (int i = 0; i <= 15; i++)
                {
                    var dataSetup1 = multiSetup.RaceSetups[i];
                    var viewModelSetup = viewModel.SetupPairs[i].RaceSetup;

                    Mappers.Mapper.MapCarSetupToViewModel(dataSetup1, viewModelSetup);

                    var dataSetup2 = multiSetup.SeparateSetups
                        ? multiSetup.QualifyingSetups[i]
                        : multiSetup.RaceSetups[i];

                    viewModelSetup = viewModel.SetupPairs[i].QualifyingSetup;

                    Mappers.Mapper.MapCarSetupToViewModel(dataSetup2, viewModelSetup);
                }
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
