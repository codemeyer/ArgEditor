using ArgData;
using ArgData.Entities;
using ArgEditor.ViewModels;

namespace ArgEditor.Commands.Setups
{
    public class SaveMultiSetupFileCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public SaveMultiSetupFileCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var viewModel = parameter as MultiSetupViewModel;

            if (viewModel == null) { return; }

            string path = _fileDialog.SelectAnyFileToSave();

            if (string.IsNullOrWhiteSpace(path))
                return;

            var multiSetup = new SetupList
            {
                SeparateSetups = viewModel.SeparateSetups
            };

            for (int i = 0; i <= 15; i++)
            {
                var dataSetup1 = multiSetup.RaceSetups[i];
                var viewModelSetup = viewModel.SetupPairs[i].RaceSetup;

                Mappers.Mapper.MapCarSetupToData(viewModelSetup, dataSetup1);

                var dataSetup2 = multiSetup.QualifyingSetups[i];
                viewModelSetup = viewModel.SeparateSetups
                    ? viewModel.SetupPairs[i].QualifyingSetup
                    : viewModel.SetupPairs[i].RaceSetup;

                Mappers.Mapper.MapCarSetupToData(viewModelSetup, dataSetup2);
            }

            SetupWriter.WriteMultiple(multiSetup, path);
        }

        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as MultiSetupViewModel;

            if (viewModel == null) { return false; }

            foreach (var s in viewModel.SetupPairs)
            {
                if (!s.RaceSetup.IsValid)
                    return false;

                if (s.SeparateSetups && !s.QualifyingSetup.IsValid)
                    return false;
            }

            return true;
        }
    }
}
