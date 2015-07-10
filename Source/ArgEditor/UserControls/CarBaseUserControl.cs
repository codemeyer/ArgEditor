using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

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

            RaiseEvent(new ClickedPolygonEventArgs(ClickedPolygonUpdatedEvent, bindingPath));
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
        public ClickedPolygonEventArgs(RoutedEvent routedEvent, string polygonName)
            : base(routedEvent)
        {
            PolygonName = polygonName;
        }
        public string PolygonName { get; set; }
    }
}
