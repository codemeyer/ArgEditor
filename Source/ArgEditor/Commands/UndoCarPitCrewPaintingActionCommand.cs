using ArgEditor.ViewModels;

namespace ArgEditor.Commands
{
    public class UndoCarPitCrewPaintingActionCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            int index = viewModel.Teams.IndexOf(viewModel.SelectedTeam);

            if (App.CarColorUndoStacks[index].Count == 0) { return; }

            UndoRedoService.ProcessColorChangeStacks(viewModel.Teams[index].Car, App.CarColorUndoStacks[index], App.CarColorRedoStacks[index]);
        }

        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return false;

            int index = viewModel.Teams.IndexOf(viewModel.SelectedTeam);

            if (App.CarColorUndoStacks[index].Count == 0)
                return false;

            return true;
        }
    }
}
