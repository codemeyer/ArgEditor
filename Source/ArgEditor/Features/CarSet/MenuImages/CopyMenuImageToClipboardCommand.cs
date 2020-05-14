using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.MenuImages
{
    public class CopyMenuImageToClipboardCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var menuImage = parameter as MenuImageViewModel;

            if (menuImage == null)
                return;

            App.ClipboardMenuImage = menuImage.PixelData;
        }
    }
}
