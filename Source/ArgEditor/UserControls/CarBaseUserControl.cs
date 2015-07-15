using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using ArgEditor.ViewModels;

namespace ArgEditor.UserControls
{
    public class CarBaseUserControl : UserControl
    {
        public bool IsEditable { get; set; }

        protected void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        protected void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
        }

        protected void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
        }

        protected void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsEditable) { return; }

            var polygon = sender as Polygon;

            if (polygon == null) { return; }

            var bindingExpression = polygon.GetBindingExpression(Shape.FillProperty);
            string bindingPath = bindingExpression.ParentBinding.Path.Path;

            var selectedCar = DataContext as CarEditingViewModel;

            PropertyInfo prop = selectedCar.GetType().GetProperty(bindingPath);
            var property = new ColorPropertyWrapper(prop);

            RaiseEvent(new ClickedPolygonEventArgs(ClickedPolygonUpdatedEvent, bindingPath, property));
        }

        private static readonly RoutedEvent ClickedPolygonUpdatedEvent =
            EventManager.RegisterRoutedEvent("ClickedPolygon", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(CarSelectionUserControl));

        public event RoutedEventHandler ClickedPolygon
        {
            add { AddHandler(ClickedPolygonUpdatedEvent, value); }
            remove { RemoveHandler(ClickedPolygonUpdatedEvent, value); }
        }
    }

    public class ClickedPolygonEventArgs : RoutedEventArgs
    {
        public ClickedPolygonEventArgs(RoutedEvent routedEvent, string polygonName, ColorPropertyWrapper property)
            : base(routedEvent)
        {
            PolygonName = polygonName;
            Property = property;
        }

        public ColorPropertyWrapper Property { get; set; }
        public string PolygonName { get; set; }
    }
}
