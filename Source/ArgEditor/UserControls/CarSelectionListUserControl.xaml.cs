using System.Linq;
using System.Reflection;
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
                // ?
                return;
            }

            var colorChangeList = CreateColorChangeListForCarPasteOperation(car, App.ClipboardCar);

            int index = (DataContext as MainViewModel).Teams.Select(t => t.Car).ToList().IndexOf(car);
            App.CarColorUndoStacks[index].Push(colorChangeList);

            Mapper.MapCarEditingViewModel(App.ClipboardCar, car);
        }

        private ColorChangeList CreateColorChangeListForCarPasteOperation(CarEditingViewModel car, CarEditingViewModel sourceCar)
        {
            var colorChangeList = new ColorChangeList();

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.CockpitFrontColorIndex))),
                NewValue = sourceCar.CockpitFrontColorIndex,
                OldValue = car.CockpitFrontColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.CockpitSideColorIndex))),
                NewValue = sourceCar.CockpitSideColorIndex,
                OldValue = car.CockpitSideColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.EngineCoverColorIndex))),
                NewValue = sourceCar.EngineCoverColorIndex,
                OldValue = car.EngineCoverColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.EngineCoverRearColorIndex))),
                NewValue = sourceCar.EngineCoverRearColorIndex,
                OldValue = car.EngineCoverRearColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.EngineCoverSideColorIndex))),
                NewValue = sourceCar.EngineCoverSideColorIndex,
                OldValue = car.EngineCoverSideColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.FrontAndRearWingColorIndex))),
                NewValue = sourceCar.FrontAndRearWingColorIndex,
                OldValue = car.FrontAndRearWingColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.FrontWingEndplateColorIndex))),
                NewValue = sourceCar.FrontWingEndplateColorIndex,
                OldValue = car.FrontWingEndplateColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.NoseAngleColorIndex))),
                NewValue = sourceCar.NoseAngleColorIndex,
                OldValue = car.NoseAngleColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.NoseSideColorIndex))),
                NewValue = sourceCar.NoseSideColorIndex,
                OldValue = car.NoseSideColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.NoseTopColorIndex))),
                NewValue = sourceCar.NoseTopColorIndex,
                OldValue = car.NoseTopColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.RearWingSideColorIndex))),
                NewValue = sourceCar.RearWingSideColorIndex,
                OldValue = car.RearWingSideColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.SidepodTopColorIndex))),
                NewValue = sourceCar.SidepodTopColorIndex,
                OldValue = car.SidepodTopColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(CarEditingViewModel).GetProperty(nameof(sourceCar.SidepodColorIndex))),
                NewValue = sourceCar.SidepodColorIndex,
                OldValue = car.SidepodColorIndex
            });

            return colorChangeList;
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
