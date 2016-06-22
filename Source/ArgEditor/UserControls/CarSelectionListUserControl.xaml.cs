using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ArgEditor.ViewModels;

namespace ArgEditor.UserControls
{
    /// <summary>
    /// Interaction logic for CarSelectionListUserControl.xaml
    /// </summary>
    public partial class CarSelectionListUserControl : UserControl
    {
        public CarSelectionListUserControl()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var clickedCarUserControl = sender as CarSelectionItemUserControl;

            if (clickedCarUserControl == null) { return; }

            var parentContent = WpfUtils.FindParent<ContentPresenter>(clickedCarUserControl);
            var parentPanel = WpfUtils.FindParent<WrapPanel>(clickedCarUserControl);

            int teamIndex = parentPanel.Children.OfType<ContentPresenter>().ToList().IndexOf(parentContent);

            RaiseEvent(new SelectedTeamEventArgs(SelectedTeamUpdatedEvent, teamIndex));
        }

        public static readonly RoutedEvent SelectedTeamUpdatedEvent =
            EventManager.RegisterRoutedEvent("SelectedTeamUpdated", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(CarSelectionListUserControl));

        public event RoutedEventHandler SelectedTeamUpdated
        {
            add { AddHandler(SelectedTeamUpdatedEvent, value); }
            remove { RemoveHandler(SelectedTeamUpdatedEvent, value); }
        }

        private void CarSelectionCopy_Click(object sender, RoutedEventArgs e)
        {
            var car = GetCarEditingViewModelForContextMenuItem(sender as MenuItem);

            if (car == null)
                return;

            if (App.ClipboardCar == null)
            {
                App.ClipboardCar = new CarEditingViewModel();
            }

            Mapper.MapCarEditingViewModel(car, App.ClipboardCar);
        }

        private void CarSelectionPaste_Click(object sender, RoutedEventArgs e)
        {
            var car = GetCarEditingViewModelForContextMenuItem(sender as MenuItem);

            if (car == null)
                return;

            if (App.ClipboardCar == null)
            {
                App.ClipboardCar = new CarEditingViewModel();
            }

            Mapper.MapCarEditingViewModel(App.ClipboardCar, car);
        }

        private CarEditingViewModel GetCarEditingViewModelForContextMenuItem(MenuItem menuItem)
        {
            ContextMenu cm = menuItem.CommandParameter as ContextMenu;
            if (cm != null)
            {
                var g = cm.PlacementTarget as CarSelectionItemUserControl;

                var team = g.DataContext as TeamViewModel;
                return team.Car;
            }

            return null;
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
