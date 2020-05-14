using System.IO;
using System.Linq;
using System.Windows;
using ArgData;
using ArgData.Entities;
using ArgEditor.Features.Persistence;

namespace ArgEditor.Features.ImportExport.ExportTo
{
    /// <summary>
    /// Interaction logic for ExportWindow.xaml
    /// </summary>
    public partial class ExportWindow : Window
    {
        public ExportWindow()
        {
            InitializeComponent();
        }

        private void BrowseExeFile_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ExportViewModel;

            var path = new FileDialog().SelectGpExeFile();

            if (!string.IsNullOrEmpty(path))
            {
                vm.SelectedExeFilePath = path;
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: place elsewhere!

            var writer = new GpExeFileWriter();
            writer.WriteViewModelToExe(ViewModel.Parent, ViewModel.SelectedExeFilePath, ViewModel);

            if (ViewModel.ApplyNameFile)
            {
                var basePath = Path.GetDirectoryName(ViewModel.SelectedExeFilePath);
                var nameFilePath = Path.Combine(basePath, ViewModel.SelectedNameFilePath);

                new NameFileSaver().Save(ViewModel.Parent, nameFilePath);

                var prefsPath = Path.Combine(basePath, "F1PREFS.DAT");

                if (!File.Exists(prefsPath))
                    return;

                var prefsFile = PreferencesFile.At(prefsPath);
                var prefsWriter = PreferencesWriter.For(prefsFile);
                prefsWriter.SetAutoLoadedNameFile(ViewModel.SelectedNameFilePath);
            }

            if (ViewModel.ApplyMenuImages)
            {
                var containerReader = new MediaContainerFileReader();
                var container = containerReader.Read(ViewModel.SelectedMenuImageFilePath);

                for (int i = 0; i < container.Items.Count; i++)
                {
                    int driverNumber = i + 1;

                    var driver = ViewModel.Parent.Drivers.FirstOrDefault(d => d.Number == driverNumber);

                    if (driver == null)
                    {
                        continue;
                    }

                    var item = container.Items[i] as ImageItem1774;
                    item.SetPixelData(driver.MenuImage.PixelData);
                }

                var containerWriter = new MediaContainerFileWriter();
                containerWriter.Write(ViewModel.SelectedMenuImageFilePath, container);
            }

            App.LatestExportViewModel = ViewModel;

            this.Close();
        }

        private void CarSetCheckAllButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SetAllCarSetCheckBoxes(true);
        }

        private void CarSetCheckNoneButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SetAllCarSetCheckBoxes(false);
        }

        private void GameSettingsCheckAllButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SetAllGameSettingsCheckBoxes(true);
        }

        private void GameSettingsCheckNoneButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SetAllGameSettingsCheckBoxes(false);
        }


        private void BrowseMenuImagesFile_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ExportViewModel;

            var path = new FileDialog().SelectDatFileToOpen();

            if (!string.IsNullOrEmpty(path))
            {
                vm.SelectedMenuImageFilePath = path;
                vm.ApplyMenuImages = true;
            }
        }


        private ExportViewModel ViewModel => (ExportViewModel)DataContext;


        private void BrowseNameFile_Click(object sender, RoutedEventArgs e)
        {
            var path = new FileDialog().SelectNameFileToSave();

            if (!string.IsNullOrEmpty(path))
            {
                var basePath = Path.GetDirectoryName(ViewModel.SelectedExeFilePath).ToLowerInvariant();
                var thisPath = path.ToLowerInvariant();

                if (ViewModel.AutoLoadNameFile)
                {
                    if (thisPath.StartsWith(basePath))
                    {
                        // OK!
                        thisPath = thisPath.Replace(basePath, string.Empty);
                        thisPath = thisPath.TrimStart('/');
                        thisPath = thisPath.TrimStart('\\');

                        ViewModel.SelectedNameFilePath = thisPath;
                    }
                    else
                    {
                        ViewModel.SelectedNameFilePath = string.Empty;
                        // warn!(?)
                    }
                }
                else
                {
                    ViewModel.SelectedNameFilePath = thisPath;
                }
            }
        }
    }
}
