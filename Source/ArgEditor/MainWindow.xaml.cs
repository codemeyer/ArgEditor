using System.Linq;
using System.Windows;
using System.Windows.Input;
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

            var defaultMainViewModel = DefaultViewModelFactory.DefaultData();
            TeamsAndDriversTab.DataContext = defaultMainViewModel;
            PerformanceTab.DataContext = defaultMainViewModel;
            CarPaintingTab.DataContext = defaultMainViewModel;
            HelmetPaintingTab.DataContext = defaultMainViewModel;
            SettingsTab.DataContext = defaultMainViewModel;

            _mainViewModel = defaultMainViewModel;
        }

        private readonly MainViewModel _mainViewModel;



        // menu items

        private void FileOpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialog.SelectArgEditorFileToOpen();

            if (string.IsNullOrEmpty(path)) { return; }

            // HACK: stupid temporary workaround to avoid not updating a textbox that currently has focus
            HiddenTextElement.Focus();

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
            bool valid = ValidateExport();
            if (!valid)
            {
                return;
            }

            string path = FileDialog.SelectGpExe();

            if (string.IsNullOrEmpty(path)) { return; }

            var fileExporter = new GpExeFileWriter();
            fileExporter.WriteViewModelToExe(_mainViewModel, path);
        }

        private bool ValidateExport()
        {
            var groupBys = _mainViewModel.Drivers
                .Where(d => d.Enabled)
                .GroupBy(d => d.Number)
                .Where(grp => grp.Count() > 1 && grp.Key > 0);
            var groupedNumbers = groupBys.ToList();

            if (groupedNumbers.Count > 0)
            {
                MessageBox.Show("Cannot export! Each driver must have a unique number.", "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            return true;
        }

        private void FileExportToNameFileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialog.SelectNameFileToSave();

            if (string.IsNullOrEmpty(path)) { return; }

            var fileExporter = new NameFileSaver();
            fileExporter.Save(_mainViewModel, path);
        }

        private void FileExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void HelpViewHelpMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenDocsInBrowser();
        }

        private void HelpAboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var about = new AboutWindow
            {
                Owner = this
            };

            about.ShowDialog();
        }

        private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                OpenDocsInBrowser();
            }
        }

        private void OpenDocsInBrowser()
        {
            System.Diagnostics.Process.Start(@"http://manicomio.se/argeditor/");
        }
    }
}
