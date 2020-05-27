using ArgEditor.Features.UndoRedo;

namespace ArgEditor.Features.CarSet.CarColors
{
    public static class ColorChangeListCreator
    {
        public static ColorChangeList CreateColorChangeListForCarPasteOperation(CarEditingViewModel currentCar, CarEditingViewModel updatedCar)
        {
            var colorChangeList = new ColorChangeList();

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(updatedCar.CockpitFrontColorIndex))),
                NewValue = updatedCar.CockpitFrontColorIndex,
                OldValue = currentCar.CockpitFrontColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(updatedCar.CockpitSideColorIndex))),
                NewValue = updatedCar.CockpitSideColorIndex,
                OldValue = currentCar.CockpitSideColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(updatedCar.EngineCoverColorIndex))),
                NewValue = updatedCar.EngineCoverColorIndex,
                OldValue = currentCar.EngineCoverColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(updatedCar.EngineCoverRearColorIndex))),
                NewValue = updatedCar.EngineCoverRearColorIndex,
                OldValue = currentCar.EngineCoverRearColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(updatedCar.EngineCoverSideColorIndex))),
                NewValue = updatedCar.EngineCoverSideColorIndex,
                OldValue = currentCar.EngineCoverSideColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(updatedCar.FrontAndRearWingColorIndex))),
                NewValue = updatedCar.FrontAndRearWingColorIndex,
                OldValue = currentCar.FrontAndRearWingColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(updatedCar.FrontWingEndplateColorIndex))),
                NewValue = updatedCar.FrontWingEndplateColorIndex,
                OldValue = currentCar.FrontWingEndplateColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(updatedCar.NoseAngleColorIndex))),
                NewValue = updatedCar.NoseAngleColorIndex,
                OldValue = currentCar.NoseAngleColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(updatedCar.NoseSideColorIndex))),
                NewValue = updatedCar.NoseSideColorIndex,
                OldValue = currentCar.NoseSideColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(updatedCar.NoseTopColorIndex))),
                NewValue = updatedCar.NoseTopColorIndex,
                OldValue = currentCar.NoseTopColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(updatedCar.RearWingSideColorIndex))),
                NewValue = updatedCar.RearWingSideColorIndex,
                OldValue = currentCar.RearWingSideColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(updatedCar.SidepodTopColorIndex))),
                NewValue = updatedCar.SidepodTopColorIndex,
                OldValue = currentCar.SidepodTopColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(updatedCar.SidepodColorIndex))),
                NewValue = updatedCar.SidepodColorIndex,
                OldValue = currentCar.SidepodColorIndex
            });

            return colorChangeList;
        }

        // TODO: PitCrew ?
    }
}
