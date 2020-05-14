using System.Linq;
using ArgEditor.Features.Main;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.MenuImages
{
    public class PasteMenuImageFromClipboardCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var menuImage = parameter as MenuImageViewModel;

            if (menuImage == null)
            {
                return;
            }

            var pixelDataChange = new PixelDataChange
            {
                OldValue = menuImage.PixelData,
                NewValue = App.ClipboardMenuImage
            };

            int index = MainViewModelPasserArounder.MainViewModel.Drivers.Select(t => t.MenuImage).ToList().IndexOf(menuImage);
            App.MenuImageUndoStacks[index].Push(pixelDataChange);
            App.MenuImageRedoStacks[index].Clear();

            menuImage.SetFromPixelData(App.ClipboardMenuImage);
        }

        public override bool CanExecute(object parameter)
        {
            return App.ClipboardMenuImage != null;
        }
    }
}
