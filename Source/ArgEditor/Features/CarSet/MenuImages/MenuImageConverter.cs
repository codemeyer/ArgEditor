using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using ColorMine.ColorSpaces;
using ColorMine.ColorSpaces.Comparisons;

namespace ArgEditor.Features.CarSet.MenuImages
{
    public static class MenuImageConverter
    {
        public static Bitmap BitmapFromPixelData(byte[] pixelData)
        {
            var bitmap = new Bitmap(48, 48);

            var menuPalette = ArgData.Palette.CreateMenuPalette();

            for (int i = 0; i < pixelData.Length; i++)
            {
                int x = i % 48;
                int y = i / 48;

                byte colorIndex = pixelData[i];
                var color = menuPalette.GetColor(colorIndex);

                bitmap.SetPixel(x, y, color);
            }

            return bitmap;
        }

        /// <summary>
        /// Takes a list of Colors and maps each to the closest color in the palette.
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public static byte[] MapColorsToClosestInPalette(List<Color> colors)
        {
            byte[] bytes = new byte[colors.Count];

            var menuPalette = ArgData.Palette.CreateMenuPalette();
            var comparison = new Cie1976Comparison();

            for (int i = 0; i < colors.Count; i++)
            {
                var color = colors[i];
                bytes[i] = GetClosestColorIndex(color, menuPalette, comparison);
            }

            return bytes;
        }

        private static byte GetClosestColorIndex(Color color, ArgData.Palette menuPalette, IColorSpaceComparison comparison)
        {
            if (color.A < 255)
            {
                return MenuImageViewModel.DefaultColor;
            }

            var originalColorRgb = new Rgb { R = color.R, G = color.G, B = color.B };

            byte bestIndex = 0;
            double smallestDifferenceYet = 999;

            for (int i = 0; i <= 255; i++)
            {
                var paletteColor = menuPalette.GetColor((byte)i);
                var paletteColorRgb = new Rgb { R = paletteColor.R, G = paletteColor.G, B = paletteColor.B };

                var difference = originalColorRgb.Compare(paletteColorRgb, comparison);

                if (difference < smallestDifferenceYet)
                {
                    smallestDifferenceYet = difference;
                    bestIndex = (byte)i;
                }
            }

            return bestIndex;
        }

        /// <summary>
        /// Gets all pixel colors from the image specified in the path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<Color> BitmapToColors(string path)
        {
            var bitmap = new Bitmap(path);
            Bitmap useBitmap;

            if (bitmap.Width != 48 || bitmap.Height != 48)
            {
                // resize
                useBitmap = MenuImageResizer.ResizeImage(bitmap, 48, 48);
            }
            else
            {
                useBitmap = bitmap;
            }

            var colors = new List<Color>();

            for (int y = 0; y < useBitmap.Height; y++)
            {
                for (int x = 0; x < useBitmap.Width; x++)
                {
                    colors.Add(useBitmap.GetPixel(x, y));
                }
            }

            return colors;
        }

        public static BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }
}
