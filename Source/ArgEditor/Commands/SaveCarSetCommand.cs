using ArgEditor.Interactors.CarSets;
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

            // TODO: interface based?
            var saver = new CarSetSaver();
            saver.Save(viewModel, path);
        }
    }
}
