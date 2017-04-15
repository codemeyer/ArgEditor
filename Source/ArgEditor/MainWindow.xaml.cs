using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ArgEditor.Interactors;
using ArgEditor.Interactors.CarSets;
using ArgEditor.Interactors.LegacyCarSets;
using ArgEditor.UserControls;
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
            PointsSystemTab.DataContext = defaultMainViewModel.PointsSystem;
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

            if (path.ToLowerInvariant().EndsWith(".arged"))
            {
                var loader = new CarSetLoader();
                loader.Load(_mainViewModel, path);
            }
            if (path.ToLowerInvariant().EndsWith(".1ed"))
            {
                LegacyCarSetLoader.IntoViewModel(_mainViewModel, path);
            }

            // TODO: unknown file? try to read as arged?
        }

        private void FileSaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialog.SelectArgEditorFileToSave();

            if (string.IsNullOrEmpty(path)) { return; }

            var saver = new CarSetSaver();
            saver.Save(_mainViewModel, path);
        }

        private void FileSaveF1edMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialog.SelectF1edFileToSave();

            if (string.IsNullOrEmpty(path)) { return; }

            var carset = Mapper.LegacyCarSetFromMainViewModel(_mainViewModel);
            LegacyCarSetSaver.Save(carset, path);
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
            try
            {
                fileExporter.WriteViewModelToExe(_mainViewModel, path);
            }
            catch (Exception ex)
            {
                // TODO: log?
                MessageBox.Show("An error occurred when exporting data. Please try again!", "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateExport()
        {
            // TODO: move this code away from .xaml file

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

            var activeCount = _mainViewModel.Drivers.Count(d => d.Enabled);

            if (activeCount < 26)
            {
                MessageBox.Show("Cannot export! There must be at least 26 active drivers", "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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

        private void HelpCheckForUpdate_Click(object sender, RoutedEventArgs e)
        {
            var checkUpdates = new CheckVersionWindow
            {
                Owner = this
            };

            checkUpdates.ShowDialog();
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
