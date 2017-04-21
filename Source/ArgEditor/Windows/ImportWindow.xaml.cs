using System.IO;
using System.Windows;
using System.Windows.Input;
using ArgEditor.Interactors;
using ArgEditor.ViewModels;

namespace ArgEditor.Windows
{
    /// <summary>
    /// Interaction logic for ImportWindow.xaml
    /// </summary>
    public partial class ImportWindow : Window
    {
        public ImportWindow()
        {
            InitializeComponent();
        }

        // TODO: same shit as in ExportWindow


        private void BrowseExeFile_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ImportViewModel;

            var path = new FileDialog().SelectGpExeFile();

            if (!string.IsNullOrEmpty(path))
            {
                vm.SelectedExeFilePath = path;
            }
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ImportViewModel;

            var reader = new GpExeFileReader();
            reader.UpdateViewModelFromExe(vm.Parent, vm.SelectedExeFilePath, vm);

            if (vm.ApplyNameFile)
            {
                if (!File.Exists(vm.SelectedNameFilePath)) { return; }

                var nameFileLoader = new NameFileLoader();
                nameFileLoader.Load(vm.Parent, vm.SelectedNameFilePath);
            }

            this.Close();
        }

        private void CarSetCheckAllButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ImportViewModel;
            vm.SetAllCarSetCheckBoxes(true);
        }

        private void CarSetCheckNoneButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ImportViewModel;
            vm.SetAllCarSetCheckBoxes(false);
        }

        private void GameSettingsCheckAllButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ImportViewModel;
            vm.SetAllGameSettingsCheckBoxes(true);
        }

        private void GameSettingsCheckNoneButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ImportViewModel;
            vm.SetAllGameSettingsCheckBoxes(false);
        }


        private void BrowseNameFile_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ImportViewModel;

            var path = new FileDialog().SelectAnyFile();

            if (!string.IsNullOrEmpty(path))
            {
                vm.SelectedNameFilePath = path;
                vm.ApplyNameFile = true;
            }
        }
    }
}
