using System.Linq;
using System.Windows.Media.Imaging;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.MenuImages
{
    public class MenuImageViewModel : BaseViewModel
    {
        public MenuImageViewModel(DriverViewModel parentDriverViewModel)
        {
            Parent = parentDriverViewModel;
        }

        public DriverViewModel Parent { get; }

        public byte[] PixelData { get; set; }


        private BitmapImage _image;

        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                SetProperty(ref _image, value, () => Image);
            }
        }


        private BitmapImage _magnifiedImage;

        public BitmapImage MagnifiedImage
        {
            get { return _magnifiedImage; }
            set
            {
                SetProperty(ref _magnifiedImage, value, () => MagnifiedImage);
            }
        }


        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value, () => IsSelected); }
        }


        public bool IsDefault()
        {
            if (PixelData == null)
            {
                return true;
            }

            return PixelData.All(b => b == DefaultColor);
        }

        // TODO: other default color?
        public const byte DefaultColor = 220;

        public byte[] GetDefault()
        {
            byte[] defaultBytes = new byte[2304];

            for (int i = 0; i < 2304; i++)
            {
                defaultBytes[i] = DefaultColor;
            }

            return defaultBytes;
        }

        public void SetDefault()
        {
            SetFromPixelData(GetDefault());
        }

        public void SetFromPixelData(byte[] pixelData)
        {
            PixelData = pixelData;

            var bitmap = MenuImageConverter.BitmapFromPixelData(pixelData);
            var bitmapMagnified = MenuImageResizer.MagnifyBitmap(bitmap, 4);

            Image = MenuImageConverter.BitmapToBitmapImage(bitmap);
            MagnifiedImage = MenuImageConverter.BitmapToBitmapImage(bitmapMagnified);
        }
    }
}
