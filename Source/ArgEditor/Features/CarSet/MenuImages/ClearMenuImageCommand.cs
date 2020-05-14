using System.Linq;
using ArgEditor.Features.Main;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.MenuImages
{
    public class ClearMenuImageCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var menuImage = parameter as MenuImageViewModel;

            if (menuImage == null)
            {
                return;
            }

            int index = MainViewModelPasserArounder.MainViewModel.Drivers.Select(t => t.MenuImage).ToList().IndexOf(menuImage);
            var pixelChange = new PixelDataChange
            {
                OldValue = menuImage.PixelData,
                NewValue = menuImage.GetDefault()
            };
            App.MenuImageUndoStacks[index].Push(pixelChange);
            App.MenuImageRedoStacks[index].Clear();

            menuImage.SetDefault();
        }
    }
}
