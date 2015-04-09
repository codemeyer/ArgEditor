using System.Windows;

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

            var defaultData = ViewModels.Utils.DefaultViewModelFactory.DefaultData();
            TeamsAndDriversTab.DataContext = defaultData;
            PerformanceTab.DataContext = defaultData;
            CarPaintingTab.DataContext = defaultData;
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
