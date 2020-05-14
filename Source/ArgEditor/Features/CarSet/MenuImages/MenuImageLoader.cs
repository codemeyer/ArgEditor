using System.Linq;
using ArgData;
using ArgData.Entities;
using ArgEditor.Features.Main;

namespace ArgEditor.Features.CarSet.MenuImages
{
    public class MenuImageLoader
    {
        public void Import(MainViewModel viewModel, string path)
        {
            var reader = new MediaContainerFileReader();
            var file = reader.Read(path);

            MediaContainerToViewModel(file, viewModel);
        }

        private void MediaContainerToViewModel(MediaContainerFile binFile, MainViewModel viewModel)
        {
            int index = 0;

            foreach (var item in binFile.Items)
            {
                if (item.Height == 0)
                {
                    continue;
                }

                var pixelBytes = (item as ImageItem1774).GetPixelData();
                var bitmap = MenuImageConverter.BitmapFromPixelData(pixelBytes);
                var altBitmap = MenuImageResizer.MagnifyBitmap(bitmap, 4);

                int driverNumber = index + 1;

                // index is now driver's number

                var drv = viewModel.Drivers.FirstOrDefault(d => d.Number == driverNumber);

                if (drv != null)
                {
                    drv.MenuImage.PixelData = pixelBytes;
                    drv.MenuImage.Image = MenuImageConverter.BitmapToBitmapImage(bitmap);
                    drv.MenuImage.MagnifiedImage = MenuImageConverter.BitmapToBitmapImage(altBitmap);
                }

                index++;
            }
        }
    }
}
