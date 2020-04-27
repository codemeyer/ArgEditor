using ArgData;
using ArgData.Entities;
using ArgEditor.Features.Persistence;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSetupEditing
{
    public class SaveSingleSetupFileCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public SaveSingleSetupFileCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var viewModel = parameter as SetupViewModel;

            if (viewModel == null) { return; }

            string path = _fileDialog.SelectAnyFileToSave();

            if (string.IsNullOrWhiteSpace(path))
                return;

            var data = new Setup();

            Mappers.Mapper.MapCarSetupToData(viewModel, data);

            new SetupWriter().WriteSingle(data, path);
        }

        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as SetupViewModel;

            if (viewModel == null) { return false; }

            return viewModel.IsValid;
        }
    }
}
