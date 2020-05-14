using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ArgEditor.Features.CarSet.MenuImages
{
    public static class MenuImageResizer
    {
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static Bitmap MagnifyBitmap(Bitmap originalBitmap, int scale)
        {
            var magnifiedBitmap = new Bitmap(originalBitmap.Width * scale, originalBitmap.Height * scale);

            for (int y = 0; y < originalBitmap.Height; y++)
            {
                for (int x = 0; x < originalBitmap.Width; x++)
                {
                    var color = originalBitmap.GetPixel(x, y);

                    for (int py = 0; py < scale; py++)
                    {
                        for (int px = 0; px < scale; px++)
                        {
                            int dox = x * scale + px;
                            int doy = y * scale + py;

                            magnifiedBitmap.SetPixel(dox, doy, color);
                        }
                    }
                }
            }

            return magnifiedBitmap;
        }
    }
}
