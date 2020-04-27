using System.Windows;
using ArgEditor.Features.Persistence.LoadCarSet;

namespace ArgEditor.Features.Main
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

            // HACK: put somewhere else...
            if (MainViewModelPasserArounder.LoadingQueued)
            {
                var path = MainViewModelPasserArounder.LoadPath;

                try
                {
                    var viewModel = defaultMainViewModel;
                
                    if (path.ToLowerInvariant().EndsWith(".arged"))
                    {
                        var loader = new CarSetLoader();
                        loader.Load(viewModel, path);
                    }
                    if (path.ToLowerInvariant().EndsWith(".1ed"))
                    {
                        LegacyCarSetLoader.IntoViewModel(viewModel, path);
                    }
                }
                catch
                {
                    MessageBox.Show($"Failed to load carset '{path}'", "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            this.DataContext = defaultMainViewModel;
        }
    }
}
