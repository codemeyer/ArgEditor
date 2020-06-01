using ArgEditor.Features.Main;
using ArgEditor.Features.Persistence;
using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSet.HelmetColors
{
    public class LoadHelmetFileCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public LoadHelmetFileCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var helmetToUpdate = parameter as HelmetViewModel;

            if (helmetToUpdate == null) return;

            var path = _fileDialog.SelectLegacyHelmetFileToOpen();

            if (path == string.Empty)
                return;

            var helmetFromFile = LegacyHelmetFiles.Load(path);

            var mappedEditingViewModel = new HelmetViewModel(null);
            Mapper.MapDataHelmetToViewModelHelmet(helmetFromFile, mappedEditingViewModel);

            var colorChangeList = HelmetColorChangeCreator.CreateColorChangeListForHelmetPasteOperation(helmetToUpdate, mappedEditingViewModel);

            int index = MainViewModelPasserArounder.MainViewModel.Drivers.IndexOf(helmetToUpdate.Parent);
            App.HelmetColorUndoStacks[index].Push(colorChangeList);
            App.HelmetColorRedoStacks[index].Clear();

            Mapper.MapDataHelmetToViewModelHelmet(helmetFromFile, helmetToUpdate);
        }
    }
}
