using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ArgEditor.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte color = (byte)value;

            return new SolidColorBrush(PaletteHelper.GetColor(color));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
