using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using ArgEditor.ViewModels;

namespace ArgEditor.UserControls
{
    /// <summary>
    /// Interaction logic for HelmetUserControl.xaml
    /// </summary>
    public partial class HelmetUserControl : UserControl
    {
        public HelmetUserControl()
        {
            InitializeComponent();
        }

        public bool IsEditable { get; set; }

        protected void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsEditable) { return; }

            var polygon = sender as Polygon;

            if (polygon == null) { return; }

            var bindingExpression = polygon.GetBindingExpression(Shape.FillProperty);
            string bindingPath = bindingExpression.ParentBinding.Path.Path;

            var selectedHelmet = DataContext as HelmetViewModel;

            var paletteTool = PaletteTool.Paint;
            //var paletteTool = ((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)
            //    ? PaletteTool.PickupColor
            //    : PaletteTool.Paint;

            PropertyInfo prop = selectedHelmet.GetType().GetProperty(bindingPath);

            var property = new ColorPropertyWrapper(prop);

            //RaiseEvent(new ClickedPolygonEventArgs(ClickedPolygonUpdatedEvent, property, paletteTool));
            RaiseEvent(new ClickedPolygonEventArgs(ClickedPolygonUpdatedEvent, property));
        }

        private static readonly RoutedEvent ClickedPolygonUpdatedEvent =
            EventManager.RegisterRoutedEvent("ClickedPolygon", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(HelmetUserControl));

        public event RoutedEventHandler ClickedHelmetPolygon
        {
            add { AddHandler(ClickedPolygonUpdatedEvent, value); }
            remove { RemoveHandler(ClickedPolygonUpdatedEvent, value); }
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (!IsEditable) { return; }

            //if ((Keyboard.Modifiers & ModifierKeys.Alt) != 0)
            //    Cursor = Cursors.Cross;
            //else
            //    Cursor = Cursors.Pen;
        }
    }
}
