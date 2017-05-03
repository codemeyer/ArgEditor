using ArgEditor.Mappers;
using ArgEditor.ViewModels;

namespace ArgEditor.Commands
{
    public class CopyCarToClipboardCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var team = parameter as TeamViewModel;

            if (team == null)
                return;

            var car = team.Car;

            if (App.ClipboardCar == null)
            {
                App.ClipboardCar = new CarEditingViewModel();
            }

            Mapper.MapCarEditingViewModel(car, App.ClipboardCar);
        }
    }
}
