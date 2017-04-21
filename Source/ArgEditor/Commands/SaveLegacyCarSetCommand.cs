using ArgEditor.Interactors.LegacyCarSets;
using ArgEditor.Mappers;
using ArgEditor.ViewModels;

namespace ArgEditor.Commands
{
    public class SaveLegacyCarSetCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public SaveLegacyCarSetCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            string path = _fileDialog.SelectLegacyCarSetFileToSave();

            if (string.IsNullOrEmpty(path)) { return; }

            var carset = Mapper.LegacyCarSetFromMainViewModel(viewModel);
            // TODO: interface based?
            LegacyCarSetSaver.Save(carset, path);
        }
    }
}
