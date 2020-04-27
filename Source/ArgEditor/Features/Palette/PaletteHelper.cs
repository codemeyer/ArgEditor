using System.Windows.Media;

namespace ArgEditor.Features.Palette
{
    public static class PaletteHelper
    {
        public static Color GetColor(int index)
        {
            var drawingColor = ArgData.Palette.CreateDrivingPalette().GetColor((byte)index);
            return Color.FromRgb(drawingColor.R, drawingColor.G, drawingColor.B);
        }
    }
}
