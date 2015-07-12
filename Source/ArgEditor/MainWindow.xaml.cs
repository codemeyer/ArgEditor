using System;
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



        // menu items

        private void FileOpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialog.SelectArgEditorFileToOpen();

            if (string.IsNullOrEmpty(path)) { return; }

            var loader = new SavedGameLoader();
            loader.Load(_mainViewModel, path);
        }

        private void FileSaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialog.SelectArgEditorFileToSave();

            if (string.IsNullOrEmpty(path)) { return; }

            var saver = new SavedGameSaver();
            saver.DoSaveisch(_mainViewModel, path);
        }

        private void FileImportMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialog.SelectGpExe();

            if (string.IsNullOrEmpty(path)) { return; }

            var fileImporter = new GpExeFileReader();
            fileImporter.UpdateViewModelFromExe(_mainViewModel, path);
        }

        private void FileExportMenuItem_Click(object sender, RoutedEventArgs e)
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
    }
}
