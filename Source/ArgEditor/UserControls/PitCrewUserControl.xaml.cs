using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace ArgEditor.UserControls
{
    /// <summary>
    /// Interaction logic for PitCrewUserControl.xaml
    /// </summary>
    public partial class PitCrewUserControl : UserControl
    {
        public PitCrewUserControl()
        {
            InitializeComponent();
        }

        protected void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (!IsEditable) { return; }

            var polygon = sender as Polygon;

            if (polygon == null) { return; }

            var bindingExpression = polygon.GetBindingExpression(Shape.FillProperty);
            string bindingPath = bindingExpression.ParentBinding.Path.Path;

            RaiseEvent(new ClickedPolygonEventArgs(ClickedPolygonUpdatedEvent, bindingPath));
        }

        private static readonly RoutedEvent ClickedPolygonUpdatedEvent =
            EventManager.RegisterRoutedEvent("ClickedPitCrewPolygon", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(CarSelectionUserControl));

        public event RoutedEventHandler ClickedPitCrewPolygon
        {
            add { AddHandler(ClickedPolygonUpdatedEvent, value); }
            remove { RemoveHandler(ClickedPolygonUpdatedEvent, value); }
        }
    }
}
