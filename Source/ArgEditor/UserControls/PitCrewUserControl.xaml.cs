using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using ArgEditor.ViewModels;

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

            var selectedPitCrew = DataContext as PitCrewViewModel;

            var paletteTool = PaletteTool.Paint;
            //var paletteTool = ((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)
            //    ? PaletteTool.PickupColor
            //    : PaletteTool.Paint;

            PropertyInfo prop = selectedPitCrew.GetType().GetProperty(bindingPath);
            var property = new ColorPropertyWrapper(prop);

            RaiseEvent(new ClickedPolygonEventArgs(ClickedPolygonUpdatedEvent, property, paletteTool));
        }

        private static readonly RoutedEvent ClickedPolygonUpdatedEvent =
            EventManager.RegisterRoutedEvent("ClickedPitCrewPolygon", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(CarSelectionItemUserControl));   // ?

        public event RoutedEventHandler ClickedPitCrewPolygon
        {
            add { AddHandler(ClickedPolygonUpdatedEvent, value); }
            remove { RemoveHandler(ClickedPolygonUpdatedEvent, value); }
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            //if ((Keyboard.Modifiers & ModifierKeys.Alt) != 0)
            //    Cursor = Cursors.Cross;
            //else
            //    Cursor = Cursors.Pen;
        }
    }
}
