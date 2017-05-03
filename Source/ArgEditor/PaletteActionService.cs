using ArgData;
using ArgEditor.UserControls;
using ArgEditor.ViewModels;

namespace ArgEditor
{
    public static class PaletteActionService
    {
        // TODO:
        // keep track of palette tool
        // keep track of selected color
        // when click occurs, the service knows what to do, i.e.
        //   what color to apply to which panel
        // add to undo/redo stack?

        // right now: Helper stuff for user controls...

        public static void PerformPaletteAction(MainViewModel mainViewModel, PaletteTool activePaletteTool, ColorPropertyWrapper property, object viewModel, PaintedElement elementType)
        {
            if (activePaletteTool == PaletteTool.Paint)
            {
                PerformPaintAction(mainViewModel, property, viewModel, elementType, mainViewModel.Palette.SelectedColor);
            }
            else if (activePaletteTool == PaletteTool.PickupColor)
            {
                byte colorIndex = property.GetValue(viewModel);
                mainViewModel.Palette.SelectedColor = colorIndex;
            }
            else if (activePaletteTool == PaletteTool.Darker)
            {
                byte colorIndex = property.GetValue(viewModel);
                int darker = Palette.GetDarkerColor(colorIndex);
                PerformPaintAction(mainViewModel, property, viewModel, elementType, (byte)darker);
            }
            else if (activePaletteTool == PaletteTool.Brighter)
            {
                byte colorIndex = property.GetValue(viewModel);
                int brighter = Palette.GetBrighterColor(colorIndex);
                PerformPaintAction(mainViewModel, property, viewModel, elementType, (byte)brighter);
            }
        }

        private static void PerformPaintAction(MainViewModel mainViewModel, ColorPropertyWrapper property, object viewModel, PaintedElement paintedElement, byte newColor)
        {
            byte currentColor = property.GetValue(viewModel);

            property.SetValue(viewModel, newColor);

            if (paintedElement == PaintedElement.Car || paintedElement == PaintedElement.PitCrew)
            {
                int index = mainViewModel.Teams.IndexOf(mainViewModel.SelectedTeam);
                var change = new ColorChange
                {
                    OldValue = currentColor,
                    NewValue = newColor,
                    Property = property,
                    PaintedElement = paintedElement
                };
                var changeList = new ColorChangeList { change };

                if (newColor != currentColor)
                {
                    App.CarColorUndoStacks[index].Push(changeList);
                    App.CarColorRedoStacks[index].Clear();
                }
            }

            if (paintedElement == PaintedElement.Helmet)
            {
                int index = -1;
                for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
                {
                    if (mainViewModel.Drivers[i].Helmet == mainViewModel.SelectedHelmet)
                    {
                        index = i;
                    }
                }
                if (index == -1)
                {
                    return;
                }

                var changeList = new ColorChangeList();
                var change = new ColorChange
                {
                    OldValue = currentColor,
                    NewValue = newColor,
                    Property = property,
                    PaintedElement = paintedElement
                };
                changeList.Add(change);

                if (newColor != currentColor)
                {
                    App.HelmetColorUndoStacks[index].Push(changeList);
                    App.HelmetColorRedoStacks[index].Clear();
                }
            }
        }
    }
}
