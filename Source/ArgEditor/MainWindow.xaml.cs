using System.Windows;
using ArgEditor.Interactors;
using ArgEditor.ViewModels;
using ArgEditor.ViewModels.Utils;

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

            var defaultData = DefaultViewModelFactory.DefaultData();
            TeamsAndDriversTab.DataContext = defaultData;
            PerformanceTab.DataContext = defaultData;
            CarPaintingTab.DataContext = defaultData;

            _mainViewModel = defaultData;
        }

        private readonly MainViewModel _mainViewModel;

        private void FileImportMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var fileImporter = new GpExeFileReader();
            string path = SelectGpExe();

            fileImporter.UpdateViewModelFromExe(_mainViewModel, path);
        }

        private void FileExportMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var fileExporter = new GpExeFileWriter();
            string path = SelectGpExe();

            fileExporter.WriteViewModelToExe(_mainViewModel, path);
        }

        private string SelectGpExe()
        {
            return @"C:\Games\gprix\gpARG.exe";
        }

        private void FileExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
