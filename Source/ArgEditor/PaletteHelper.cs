using System.Windows.Media;
using ArgData;

namespace ArgEditor
{
    public static class PaletteHelper
    {
        public static Color GetColor(int index)
        {
            var drawingColor = Palette.CreateDrivingPalette().GetColor((byte)index);
            return Color.FromRgb(drawingColor.R, drawingColor.G, drawingColor.B);
        }
    }
}
