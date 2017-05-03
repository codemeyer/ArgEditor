using ArgEditor.ViewModels.Utils;
using System.Windows;

namespace ArgEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var defaultMainViewModel = DefaultViewModelFactory.DefaultData();
            // really needed to set these DataContext variables?
            TeamsAndDriversTab.DataContext = defaultMainViewModel;
            PerformanceTab.DataContext = defaultMainViewModel;
            CarPaintingTab.DataContext = defaultMainViewModel;
            HelmetPaintingTab.DataContext = defaultMainViewModel;
            PointsSystemTab.DataContext = defaultMainViewModel.PointsSystem;
            SettingsTab.DataContext = defaultMainViewModel;

            // HACK: world class hack!
            MainViewModelPasserArounder.MainViewModel = defaultMainViewModel;

            this.DataContext = defaultMainViewModel;
        }
    }
}
