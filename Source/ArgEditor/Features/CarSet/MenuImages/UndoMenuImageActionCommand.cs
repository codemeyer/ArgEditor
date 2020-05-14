using ArgEditor.Features.Main;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.MenuImages
{
    public class UndoMenuImageActionCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            int index = GetIndex(viewModel);

            if (App.MenuImageUndoStacks[index].Count == 0)
            {
                return;
            }

            var latestChange = App.MenuImageUndoStacks[index].Pop();
            viewModel.SelectedMenuImage.SetFromPixelData(latestChange.OldValue);
            App.MenuImageRedoStacks[index].Push(latestChange);
        }

        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return false;

            int index = GetIndex(viewModel);

            if (App.MenuImageUndoStacks[index].Count == 0)
                return false;

            return true;
        }

        // TODO: also in Redo
        private int GetIndex(MainViewModel viewModel)
        {
            int index = -1;
            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                if (viewModel.Drivers[i].MenuImage == viewModel.SelectedMenuImage)
                {
                    index = i;
                }
            }

            return index;
        }
    }
}
