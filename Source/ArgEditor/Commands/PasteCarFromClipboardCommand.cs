using ArgEditor.Mappers;
using ArgEditor.ViewModels;

namespace ArgEditor.Commands
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

            var colorChangeList = CreateColorChangeListForCarPasteOperation(car, App.ClipboardCar);

            App.CarColorUndoStacks[team.Index].Push(colorChangeList);

            Mapper.MapCarEditingViewModel(App.ClipboardCar, car);
        }

        private ColorChangeList CreateColorChangeListForCarPasteOperation(CarEditingViewModel car, CarEditingViewModel sourceCar)
        {
            var colorChangeList = new ColorChangeList();

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.CockpitFrontColorIndex))),
                NewValue = sourceCar.CockpitFrontColorIndex,
                OldValue = car.CockpitFrontColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.CockpitSideColorIndex))),
                NewValue = sourceCar.CockpitSideColorIndex,
                OldValue = car.CockpitSideColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.EngineCoverColorIndex))),
                NewValue = sourceCar.EngineCoverColorIndex,
                OldValue = car.EngineCoverColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.EngineCoverRearColorIndex))),
                NewValue = sourceCar.EngineCoverRearColorIndex,
                OldValue = car.EngineCoverRearColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.EngineCoverSideColorIndex))),
                NewValue = sourceCar.EngineCoverSideColorIndex,
                OldValue = car.EngineCoverSideColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.FrontAndRearWingColorIndex))),
                NewValue = sourceCar.FrontAndRearWingColorIndex,
                OldValue = car.FrontAndRearWingColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.FrontWingEndplateColorIndex))),
                NewValue = sourceCar.FrontWingEndplateColorIndex,
                OldValue = car.FrontWingEndplateColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.NoseAngleColorIndex))),
                NewValue = sourceCar.NoseAngleColorIndex,
                OldValue = car.NoseAngleColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.NoseSideColorIndex))),
                NewValue = sourceCar.NoseSideColorIndex,
                OldValue = car.NoseSideColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.NoseTopColorIndex))),
                NewValue = sourceCar.NoseTopColorIndex,
                OldValue = car.NoseTopColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.RearWingSideColorIndex))),
                NewValue = sourceCar.RearWingSideColorIndex,
                OldValue = car.RearWingSideColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.SidepodTopColorIndex))),
                NewValue = sourceCar.SidepodTopColorIndex,
                OldValue = car.SidepodTopColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.SidepodColorIndex))),
                NewValue = sourceCar.SidepodColorIndex,
                OldValue = car.SidepodColorIndex
            });

            return colorChangeList;
        }

        public override bool CanExecute(object parameter)
        {
            return App.ClipboardCar != null;
        }
    }
}
