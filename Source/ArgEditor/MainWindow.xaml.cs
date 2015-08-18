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
            HelmetPaintingTab.DataContext = defaultData;

            _mainViewModel = defaultData;
        }

        private readonly MainViewModel _mainViewModel;



        // menu items

        private void FileOpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialog.SelectArgEditorFileToOpen();

            if (string.IsNullOrEmpty(path)) { return; }

            // TODO: must set focus somewhere that isn't a textbox,
            // otherwise it will not update data for the field you're in

            var loader = new CarSetLoader();
            loader.Load(_mainViewModel, path);
        }

        private void FileSaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialog.SelectArgEditorFileToSave();

            if (string.IsNullOrEmpty(path)) { return; }

            var saver = new CarSetSaver();
            saver.Save(_mainViewModel, path);
        }

        private void FileImportFromGpExeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialog.SelectGpExe();

            if (string.IsNullOrEmpty(path)) { return; }

            var fileImporter = new GpExeFileReader();
            fileImporter.UpdateViewModelFromExe(_mainViewModel, path);
        }

        private void FileImportFromNamesFileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialog.SelectAnyFile();

            if (string.IsNullOrEmpty(path)) { return; }

            var nameFileLoader = new NameFileLoader();
            nameFileLoader.Load(_mainViewModel, path);
        }

        private void FileExportToGpExeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialog.SelectGpExe();

            if (string.IsNullOrEmpty(path)) { return; }

            var fileExporter = new GpExeFileWriter();
            fileExporter.WriteViewModelToExe(_mainViewModel, path);
        }

        private void FileExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void HelpAboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var about = new AboutWindow
            {
                Owner = this
            };

            about.ShowDialog();
        }
    }
}
