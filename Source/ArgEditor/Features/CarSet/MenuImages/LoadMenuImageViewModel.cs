using System.Drawing;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ArgEditor.Features.Application.Shared;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.MenuImages
{
    public class LoadMenuImageViewModel : BaseViewModel
    {
        public void LoadImage(string path)
        {
            UpdateOriginalImages(path);
            UpdateInGameImages(path);

            CanClickOk = true;
        }

        private void UpdateOriginalImages(string path)
        {
            var image = new Bitmap(path);

            var originalImageResized = MenuImageResizer.ResizeImage(image, 48, 48);
            OriginalImage = MenuImageConverter.BitmapToBitmapImage(originalImageResized);

            Bitmap originalResizedMagnified;

            if (image.Width <= 48)
            {
                originalResizedMagnified = MenuImageResizer.MagnifyBitmap(originalImageResized, 4);
            }
            else
            {
                originalResizedMagnified = MenuImageResizer.ResizeImage(image, 192, 192);
            }

            OriginalMagnifiedImage = MenuImageConverter.BitmapToBitmapImage(originalResizedMagnified);
        }

        private void UpdateInGameImages(string path)
        {
            var pixelColors = MenuImageConverter.BitmapToColors(path);
            var indexes = MenuImageConverter.MapColorsToClosestInPalette(pixelColors);

            var newBitmap = new Bitmap(48, 48);
            int colorIndex = 0;

            var menuPalette = ArgData.Palette.CreateMenuPalette();

            for (int y = 0; y < 48; y++)
            {
                for (int x = 0; x < 48; x++)
                {
                    newBitmap.SetPixel(x, y, menuPalette.GetColor(indexes[colorIndex]));
                    colorIndex++;
                }
            }

            PixelData = indexes;
            InGameImage = MenuImageConverter.BitmapToBitmapImage(newBitmap);
            InGameMagnifiedImage = MenuImageConverter.BitmapToBitmapImage(MenuImageResizer.MagnifyBitmap(newBitmap, 4));
        }


        public byte[] PixelData { get; set; }


        private BitmapImage _originalImage;

        /// <summary>
        /// Gets or sets the original image resized to 48x48 pixels.
        /// </summary>
        public BitmapImage OriginalImage
        {
            get { return _originalImage; }
            set
            {
                SetProperty(ref _originalImage, value, () => OriginalImage);
            }
        }


        private BitmapImage _originalMagnifiedImage;

        /// <summary>
        /// Original image magnified to a larger size.
        /// </summary>
        public BitmapImage OriginalMagnifiedImage
        {
            get { return _originalMagnifiedImage; }
            set
            {
                SetProperty(ref _originalMagnifiedImage, value, () => OriginalMagnifiedImage);
            }
        }


        private BitmapImage _inGameImage;

        public BitmapImage InGameImage
        {
            get { return _inGameImage; }
            set
            {
                SetProperty(ref _inGameImage, value, () => InGameImage);
            }
        }


        private BitmapImage _inGameMagnifiedImage;

        public BitmapImage InGameMagnifiedImage
        {
            get { return _inGameMagnifiedImage; }
            set
            {
                SetProperty(ref _inGameMagnifiedImage, value, () => InGameMagnifiedImage);
            }
        }


        private bool _canClickOk;

        public bool CanClickOk
        {
            get { return _canClickOk; }
            set
            {
                SetProperty(ref _canClickOk, value, () => CanClickOk);
            }
        }


        public ICommand HelpDocsCommand { get; } = new HelpDocsCommand("carset-screen/#menu-images-tab");
    }
}
