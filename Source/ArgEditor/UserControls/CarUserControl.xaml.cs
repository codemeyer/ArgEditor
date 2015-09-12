using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using ArgEditor.ViewModels;

namespace ArgEditor.UserControls
{
    /// <summary>
    /// Interaction logic for CarUserControl.xaml
    /// </summary>
    public partial class CarUserControl : UserControl
    {
        public CarUserControl()
        {
            InitializeComponent();
        }

        public bool IsEditable { get; set; }

        protected void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        protected void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (!IsEditable) { return; }

            //if ((Keyboard.Modifiers & ModifierKeys.Alt) != 0)
            //    Cursor = Cursors.Cross;
            //else
            //    Cursor = Cursors.Pen;
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

            var paletteTool = PaletteTool.Paint;
            //var paletteTool = ((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)
            //    ? PaletteTool.PickupColor
            //    : PaletteTool.Paint;

            PropertyInfo prop = selectedCar.GetType().GetProperty(bindingPath);
            var property = new ColorPropertyWrapper(prop);

            RaiseEvent(new ClickedPolygonEventArgs(ClickedPolygonUpdatedEvent, property, paletteTool));
        }

        private static readonly RoutedEvent ClickedPolygonUpdatedEvent =
            EventManager.RegisterRoutedEvent("ClickedPolygon", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(CarSelectionItemUserControl));  // ???

        public event RoutedEventHandler ClickedPolygon
        {
            add { AddHandler(ClickedPolygonUpdatedEvent, value); }
            remove { RemoveHandler(ClickedPolygonUpdatedEvent, value); }
        }
    }

    public class ClickedPolygonEventArgs : RoutedEventArgs
    {
        public ClickedPolygonEventArgs(RoutedEvent routedEvent, ColorPropertyWrapper property, PaletteTool paletteTool)
            : base(routedEvent)
        {
            Property = property;
            PaletteTool = paletteTool;
        }

        public ColorPropertyWrapper Property { get; set; }
        public PaletteTool PaletteTool { get; set; }
    }


    public enum PaletteTool
    {
        Paint,
        PickupColor
    }
}

