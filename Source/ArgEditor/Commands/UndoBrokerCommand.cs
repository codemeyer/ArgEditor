using ArgEditor.ViewModels;

namespace ArgEditor.Commands
{
    public class UndoBrokerCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            if (viewModel.SelectedMainTabIndex == 0 && viewModel.SelectedCarSetTabIndex == 2)
            {
                var command = new UndoCarPitCrewPaintingActionCommand();
                command.Execute(parameter);
            }

            if (viewModel.SelectedMainTabIndex == 0 && viewModel.SelectedCarSetTabIndex == 3)
            {
                var command = new UndoHelmetPaintingActionCommand();
                command.Execute(parameter);
            }
        }

        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return false;

            if (viewModel.SelectedMainTabIndex == 0 && viewModel.SelectedCarSetTabIndex == 2)
            {
                var command = new UndoCarPitCrewPaintingActionCommand();
                return command.CanExecute(parameter);
            }

            if (viewModel.SelectedMainTabIndex == 0 && viewModel.SelectedCarSetTabIndex == 3)
            {
                var command = new UndoHelmetPaintingActionCommand();
                return command.CanExecute(parameter);
            }

            return false;
        }
    }
}
