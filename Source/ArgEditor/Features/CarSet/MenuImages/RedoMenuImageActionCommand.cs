using ArgEditor.Features.Main;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.MenuImages
{
    public class RedoMenuImageActionCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            int index = GetIndex(viewModel);

            if (App.MenuImageRedoStacks[index].Count == 0)
            {
                return;
            }

            var latestChange = App.MenuImageRedoStacks[index].Pop();
            viewModel.SelectedMenuImage.SetFromPixelData(latestChange.NewValue);
            App.MenuImageUndoStacks[index].Push(latestChange);
        }

        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return false;

            int index = GetIndex(viewModel);

            if (App.MenuImageRedoStacks[index].Count == 0)
            {
                return false;
            }

            return true;
        }

        // TODO: also in Undo
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
