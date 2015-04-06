using System.Windows.Media;

namespace ArgEditor
{
    public static class PaletteHelper
    {
        public static Color GetColor(int index)
        {
            var drawingColor = ArgData.Palette.GetColor(index);
            return Color.FromRgb(drawingColor.R, drawingColor.G, drawingColor.B);
        }
    }
}
