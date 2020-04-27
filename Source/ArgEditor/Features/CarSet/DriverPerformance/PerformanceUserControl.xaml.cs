using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ArgEditor.Features.Main;

namespace ArgEditor.Features.CarSet.DriverPerformance
{
    /// <summary>
    /// Interaction logic for TeamDriverPerformanceUserControl.xaml
    /// </summary>
    public partial class TeamDriverPerformanceUserControl : UserControl
    {
        public TeamDriverPerformanceUserControl()
        {
            InitializeComponent();
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!IsValidKey(e.Key))
            {
                e.Handled = true;
                return;
            }

            // TODO: check ranges min-max?

            var textbox = (TextBox)sender;
            string currentTextValue = textbox.Text;
            int value;

            if (!int.TryParse(currentTextValue, out value))
                return;

            if (e.Key == Key.OemPlus)
            {
                if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                {
                    value += 10;
                }
                else
                    value++;

                e.Handled = true;
            }

            if (e.Key == Key.OemMinus && value > 0)
            {
                if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                {
                    value -= 10;
                }
                else
                    value--;


                if (value < 1)
                {
                    value = 1;
                }

                e.Handled = true;
            }

            textbox.Text = value.ToString();
        }

        private Key[] _validKeys = new Key[]
        {
            Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9,
            Key.OemPlus, Key.OemMinus, Key.Delete, Key.Tab
        };

        private bool IsValidKey(Key key)
        {
            return (_validKeys.Contains(key));
        }

        private void Driver1SkillQ_GotFocus(object sender, RoutedEventArgs e)
        {
            var x = DataContext as TeamViewModel;
            ResetDriver();
            MainViewModelPasserArounder.MainViewModel.IsEditingIgnoreMetric = false;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverType = PerformanceMetric.Qualifying;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverIndex1 = x.Drivers[0].Number;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverIndex2 = x.Drivers[0].Number;
        }

        private void Driver1SkillR_GotFocus(object sender, RoutedEventArgs e)
        {
            var x = DataContext as TeamViewModel;
            ResetDriver();
            MainViewModelPasserArounder.MainViewModel.IsEditingIgnoreMetric = false;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverType = PerformanceMetric.Race;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverIndex1 = x.Drivers[0].Number;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverIndex2 = x.Drivers[0].Number;
        }

        private void Driver2SkillQ_GotFocus(object sender, RoutedEventArgs e)
        {
            var x = DataContext as TeamViewModel;
            ResetDriver();
            MainViewModelPasserArounder.MainViewModel.IsEditingIgnoreMetric = false;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverType = PerformanceMetric.Qualifying;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverIndex1 = x.Drivers[1].Number;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverIndex2 = x.Drivers[1].Number;
        }

        private void Driver2SkillR_GotFocus(object sender, RoutedEventArgs e)
        {
            var x = DataContext as TeamViewModel;
            ResetDriver();
            MainViewModelPasserArounder.MainViewModel.IsEditingIgnoreMetric = false;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverType = PerformanceMetric.Race;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverIndex1 = x.Drivers[1].Number;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverIndex2 = x.Drivers[1].Number;
        }

        private void DriverSkill_LostFocus(object sender, RoutedEventArgs e)
        {
            ResetDriver();
        }

        private void ResetDriver()
        {
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverIndex1 = 99;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverIndex2 = 99;
        }

        private void Team_GotFocus(object sender, RoutedEventArgs e)
        {
            var x = DataContext as TeamViewModel;
            MainViewModelPasserArounder.MainViewModel.IsEditingIgnoreMetric = true;
            ResetDriver();
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverIndex1 = x.Drivers[0].Number;
            MainViewModelPasserArounder.MainViewModel.IsEditingDriverIndex2 = x.Drivers[1].Number;
        }

        private void Team_LostFocus(object sender, RoutedEventArgs e)
        {
            ResetDriver();
        }
    }
}
