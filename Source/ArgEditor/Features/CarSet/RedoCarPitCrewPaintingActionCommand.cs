using System.Linq;
using ArgEditor.Features.Main;
using ArgEditor.Features.UndoRedo;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet
{
    public class RedoCarPitCrewPaintingActionCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            int index = viewModel.Teams.IndexOf(viewModel.SelectedTeam);

            if (App.CarColorRedoStacks[index].Count == 0) { return; }

            var nextActionItem = App.CarColorRedoStacks[index].Peek();

            object paintedItem = null;

            if (nextActionItem.Any() && nextActionItem.First().PaintedElement == PaintedElement.Car)
            {
                paintedItem = viewModel.Teams[index].Car;
            }
            else
            {
                paintedItem = viewModel.Teams[index].PitCrew;
            }

            UndoRedoService.ProcessColorChangeStacks(paintedItem, App.CarColorRedoStacks[index], App.CarColorUndoStacks[index]);
        }

        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return false;

            int index = viewModel.Teams.IndexOf(viewModel.SelectedTeam);

            if (App.CarColorRedoStacks[index].Count == 0) { return false; }

            return true;
        }
    }
}
