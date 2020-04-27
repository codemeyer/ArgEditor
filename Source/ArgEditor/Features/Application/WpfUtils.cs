using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ArgEditor.Features.Application
{
    public static class WpfUtils
    {
        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindParent<T>(parentObject);
        }
    }


    [ContentProperty("Icon")]
    public class ImageSourceFromIconExtension : MarkupExtension
    {
        public Icon Icon { get; set; }

        public ImageSourceFromIconExtension()
        {
        }

        public ImageSourceFromIconExtension(Icon icon)
        {
            Icon = icon;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Imaging.CreateBitmapSourceFromHIcon(Icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
