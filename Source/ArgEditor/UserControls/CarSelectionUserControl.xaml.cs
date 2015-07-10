using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ArgEditor.UserControls
{
    /// <summary>
    /// Interaction logic for CarSelectionUserControl.xaml
    /// </summary>
    public partial class CarSelectionUserControl : UserControl
    {
        public CarSelectionUserControl()
        {
            InitializeComponent();
        }

        private void CarUserControl_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var clickedCarUserControl = sender as ICarUserControl;
            int teamIndex = CarsPanel.Children.OfType<ICarUserControl>().ToList().IndexOf(clickedCarUserControl);

            RaiseEvent(new SelectedTeamEventArgs(SelectedTeamUpdatedEvent, teamIndex));
        }

        public static readonly RoutedEvent SelectedTeamUpdatedEvent =
            EventManager.RegisterRoutedEvent("SelectedTeamUpdated", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(CarSelectionUserControl));

        public event RoutedEventHandler SelectedTeamUpdated
        {
            add { AddHandler(SelectedTeamUpdatedEvent, value); }
            remove { RemoveHandler(SelectedTeamUpdatedEvent, value); }
        }
    }

    public class SelectedTeamEventArgs : RoutedEventArgs
    {
        public SelectedTeamEventArgs(RoutedEvent routedEvent, int teamIndex)
            : base(routedEvent)
        {
            TeamIndex = teamIndex;
        }
        public int TeamIndex { get; set; }
    }
}
