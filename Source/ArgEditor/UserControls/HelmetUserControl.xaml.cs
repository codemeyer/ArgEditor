using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

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

            RaiseEvent(new ClickedHelmetPolygonEventArgs(ClickedHelmetPolygonUpdatedEvent, bindingPath));
        }

        private static readonly RoutedEvent ClickedHelmetPolygonUpdatedEvent =
            EventManager.RegisterRoutedEvent("ClickedHelmetPolygon", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(CarSelectionUserControl));

        public event RoutedEventHandler ClickedHelmetPolygon
        {
            add { AddHandler(ClickedHelmetPolygonUpdatedEvent, value); }
            remove { RemoveHandler(ClickedHelmetPolygonUpdatedEvent, value); }
        }
    }

    public class ClickedHelmetPolygonEventArgs : RoutedEventArgs
    {
        public ClickedHelmetPolygonEventArgs(RoutedEvent routedEvent, string polygonName)
            : base(routedEvent)
        {
            PolygonName = polygonName;
        }
        public string PolygonName { get; set; }
    }
}
