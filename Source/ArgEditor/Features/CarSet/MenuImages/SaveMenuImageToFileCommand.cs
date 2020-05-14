using System.Drawing.Imaging;
using ArgEditor.Features.Persistence;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.MenuImages
{
    public class SaveMenuImageToFileCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public SaveMenuImageToFileCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var menuImage = parameter as MenuImageViewModel;

            if (menuImage == null)
            {
                return;
            }

            var path = _fileDialog.SelectImageFileToSave();

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            var png = MenuImageConverter.BitmapFromPixelData(menuImage.PixelData);

            png.Save(path, ImageFormat.Png);
        }
    }
}
