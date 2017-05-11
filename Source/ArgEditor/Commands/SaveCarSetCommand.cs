using ArgEditor.Interactors.CarSets;
using ArgEditor.Interactors.LegacyCarSets;
using ArgEditor.Mappers;
using ArgEditor.ViewModels;

namespace ArgEditor.Commands
{
    public class SaveCarSetCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public SaveCarSetCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            string path = _fileDialog.SelectCarSetFileToSave();

            if (string.IsNullOrEmpty(path)) { return; }

            if (path.ToLowerInvariant().EndsWith("arged"))
            {
                // TODO: interface based?
                var saver = new CarSetSaver();
                saver.Save(viewModel, path);
            }
            else
            {
                var carset = Mapper.LegacyCarSetFromMainViewModel(viewModel);
                // TODO: interface based?
                LegacyCarSetSaver.Save(carset, path);
            }
        }
    }
}
