using ArgEditor.ViewModels;
using ArgEditor.ViewModels.Utils;
using System.Windows;
using System.Windows.Input;

namespace ArgEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var defaultMainViewModel = DefaultViewModelFactory.DefaultData();
            TeamsAndDriversTab.DataContext = defaultMainViewModel;
            PerformanceTab.DataContext = defaultMainViewModel;
            CarPaintingTab.DataContext = defaultMainViewModel;
            HelmetPaintingTab.DataContext = defaultMainViewModel;
            PointsSystemTab.DataContext = defaultMainViewModel.PointsSystem;
            SettingsTab.DataContext = defaultMainViewModel;
            SingleCarSetupTab.DataContext = defaultMainViewModel.SingleSetupViewModel;

            _mainViewModel = defaultMainViewModel;

            this.DataContext = _mainViewModel;
        }

        private readonly MainViewModel _mainViewModel;



        private void EditUndoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (MainCarSetTab.SelectedIndex == 2)   // cars/pitcrews
            {
                CarPaintingTab.PerformUndo();
            }
            else if (MainCarSetTab.SelectedIndex == 3)  // helmets
            {
                HelmetPaintingTab.PerformUndo();
            }
        }

        private void EditRedoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (MainCarSetTab.SelectedIndex == 2)   // cars/pitcrews
            {
                CarPaintingTab.PerformRedo();
            }
            else if (MainCarSetTab.SelectedIndex == 3)  // helmets
            {
                HelmetPaintingTab.PerformRedo();
            }
        }

        private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) == 0)
            {
                if (e.Key == Key.OemPlus)
                {
                    if (MainCarSetTab.SelectedIndex == 2 || MainCarSetTab.SelectedIndex == 3)
                    {
                        // still a bit weird, perhaps kill this shortcut?
                        _mainViewModel.PaletteSelectNextBrighterColorCommand.Execute(_mainViewModel.Palette);
                        //new PaletteSelectNextBrighterColorCommand().Execute(_mainViewModel.Palette);
                    }
                }

                if (e.Key == Key.OemMinus)
                {
                    if (MainCarSetTab.SelectedIndex == 2 || MainCarSetTab.SelectedIndex == 3)
                    {
                        // still a bit weird, perhaps kill this shortcut?
                        _mainViewModel.PaletteSelectNextBrighterColorCommand.Execute(_mainViewModel.Palette);
                        //new PaletteSelectNextDarkerColorCommand().Execute(_mainViewModel.Palette);
                    }
                }
            }
        }
    }
}
