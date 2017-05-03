using ArgEditor.ViewModels;

namespace ArgEditor.Commands
{
    public class UndoHelmetPaintingActionCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            int index = GetIndex(viewModel);

            if (App.HelmetColorUndoStacks[index].Count == 0)
            {
                return;
            }

            UndoRedoService.ProcessColorChangeStacks(viewModel.SelectedHelmet, App.HelmetColorUndoStacks[index], App.HelmetColorRedoStacks[index]);
        }

        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return false;

            int index = GetIndex(viewModel);

            if (App.HelmetColorUndoStacks[index].Count == 0)
                return false;

            return true;
        }

        // TODO: also in Redo
        private int GetIndex(MainViewModel viewModel)
        {
            int index = -1;
            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                if (viewModel.Drivers[i].Helmet == viewModel.SelectedHelmet)
                {
                    index = i;
                }
            }

            return index;
        }
    }
}
