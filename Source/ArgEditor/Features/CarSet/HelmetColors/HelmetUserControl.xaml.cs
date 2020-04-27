using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using ArgEditor.Features.UndoRedo;

namespace ArgEditor.Features.CarSet.HelmetColors
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

            PropertyInfo prop = selectedHelmet.GetType().GetProperty(bindingPath);

            var property = new ColorPropertyWrapper(prop);

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
