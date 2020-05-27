using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSet.CarColors
{
    public class PasteCarFromClipboardCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var team = parameter as TeamViewModel;

            if (team == null)
                return;

            var car = team.Car;

            if (App.ClipboardCar == null)
            {
                return;
            }

            var colorChangeList = ColorChangeListCreator.CreateColorChangeListForCarPasteOperation(car, App.ClipboardCar);

            App.CarColorUndoStacks[team.Index].Push(colorChangeList);
            App.CarColorRedoStacks[team.Index].Clear();

            Mapper.MapCarEditingViewModel(App.ClipboardCar, car);
        }

        public override bool CanExecute(object parameter)
        {
            return App.ClipboardCar != null;
        }
    }
}
