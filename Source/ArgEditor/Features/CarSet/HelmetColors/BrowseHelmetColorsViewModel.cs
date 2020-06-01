using ArgEditor.Features.Persistence;
using ArgEditor.Infrastructure;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Media;
using ArgData;
using ArgData.Entities;
using ArgEditor.Features.Main;
using ArgEditor.Features.Persistence.Common.CarSets;
using ArgEditor.Features.Persistence.LoadCarSet;
using ArgEditor.Mappers;
using Newtonsoft.Json;

namespace ArgEditor.Features.CarSet.HelmetColors
{
    public class BrowseHelmetColorsViewModel : BaseViewModel
    {
        private readonly IFileDialog _fileDialog;

        public BrowseHelmetColorsViewModel(IFileDialog fileDialog)
        {
            Helmets = new ObservableCollection<HelmetViewModel>();
            // or remember?

            _fileDialog = fileDialog;

            BrowseCommand = new ViewModelCommand
            {
                CanExecuteFunc = obj => true,
                ExecuteFunc = Browse
            };
        }

        private void Browse(object parameter)
        {
            var path = _fileDialog.SelectBrowseHelmetColorsFileToOpen();
            FilePath = path;

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            SelectedHelmet = null;

            var fileType = Path.GetExtension(path).ToLowerInvariant();

            ObservableCollection<HelmetViewModel> readResult = null;

            if (fileType == ".arged")
            {
                try
                {
                    readResult = LoadFromCarSetFile(path);
                }
                catch
                {
                    MessageBox.Show("An error occurred when loading data from an ArgEditor carset file.", "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (fileType == ".exe")
            {
                try
                {
                    readResult = LoadFromExeFile(path);
                }
                catch
                {
                    MessageBox.Show("An error occurred when loading data from an F1GP EXE file.", "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (fileType == ".1ed")
            {
                try
                {
                    readResult = LoadFromF1EdFile(path);
                }
                catch
                {
                    MessageBox.Show("An error occurred when loading data from an F1Ed carset file.", "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (fileType == ".hel")
            {
                try
                {
                    readResult = LoadFromHelFile(path);
                }
                catch
                {
                    MessageBox.Show("An error occurred when loading data from a HEL file.", "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (readResult != null)
            {
                Helmets = readResult;
            }
            else
            {
                FilePath = string.Empty;
            }
        }

        private ObservableCollection<HelmetViewModel> LoadFromCarSetFile(string path)
        {
            var helmets = new ObservableCollection<HelmetViewModel>();

            string fileData = File.ReadAllText(path);
            var carSet = JsonConvert.DeserializeObject<CarSetFile>(fileData);

            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                var fileHelmet = carSet.Drivers[i].HelmetColors;
                var helmet = new HelmetViewModel(null);

                Mapper.MapCarSetHelmetToHelmetViewModel(fileHelmet, helmet);

                helmets.Add(helmet);
            }

            return helmets;
        }

        private ObservableCollection<HelmetViewModel> LoadFromExeFile(string path)
        {
            var helmets = new ObservableCollection<HelmetViewModel>();

            var exe = GpExeFile.At(path);
            var helmetColorReader = HelmetColorReader.For(exe);

            var helmetColors = helmetColorReader.ReadHelmetColors();

            foreach (Helmet helmetColor in helmetColors)
            {
                var helmet = new HelmetViewModel(null);
                Mapper.MapDataHelmetToViewModelHelmet(helmetColor, helmet);
                helmets.Add(helmet);
            }

            return helmets;
        }

        private ObservableCollection<HelmetViewModel> LoadFromF1EdFile(string path)
        {
            var helmets = new ObservableCollection<HelmetViewModel>();

            var result = LegacyCarSetLoader.Load(path);

            // correct end?
            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                var driver = result.Drivers[i];

                var helmetViewModel = new HelmetViewModel(null);

                var helmet = new Helmet(driver.HelmetColors);

                Mapper.MapDataHelmetToViewModelHelmet(helmet, helmetViewModel);

                helmets.Add(helmetViewModel);
            }

            return helmets;
        }

        private ObservableCollection<HelmetViewModel> LoadFromHelFile(string path)
        {
            var helmets = new ObservableCollection<HelmetViewModel>();

            var helmet = LegacyHelmetFiles.Load(path);

            var helmetViewModel = new HelmetViewModel(null);

            Mapper.MapDataHelmetToViewModelHelmet(helmet, helmetViewModel);

            helmets.Add(helmetViewModel);

            return helmets;
        }



        private ObservableCollection<HelmetViewModel> _helmets;

        public ObservableCollection<HelmetViewModel> Helmets
        {
            get { return _helmets; }
            set { SetProperty(ref _helmets, value, () => Helmets); }
        }


        private HelmetViewModel _selectedCar;

        public HelmetViewModel SelectedHelmet
        {
            get { return _selectedCar; }
            set
            {
                SetProperty(ref _selectedCar, value, () => SelectedHelmet);

                foreach (var helmet in Helmets)
                {
                    helmet.BackgroundColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                }

                CalculateCanClickOk();

                if (SelectedHelmet != null)
                {
                    SelectedHelmet.BackgroundColor = new SolidColorBrush(Color.FromRgb(160, 160, 160));
                }
            }
        }




        public ViewModelCommand BrowseCommand { get; }



        private void CalculateCanClickOk()
        {
            CanClickOk = SelectedHelmet != null;
        }


        private bool _canClickOk = false;

        public bool CanClickOk
        {
            get { return _canClickOk; }
            set
            {
                SetProperty(ref _canClickOk, value, () => CanClickOk);
            }
        }


        private string _filePath;

        public string FilePath
        {
            get { return _filePath; }
            set
            {
                SetProperty(ref _filePath, value, () => FilePath);
                UpdateHasPath(!string.IsNullOrEmpty(value));
            }
        }



        private void UpdateHasPath(bool val)
        {
            if (val)
            {
                ShowPath = Visibility.Visible;
            }
            else
            {
                ShowPath = Visibility.Hidden;
            }
        }


        private Visibility _showPath = Visibility.Hidden;

        public Visibility ShowPath
        {
            get { return _showPath; }
            set
            {
                SetProperty(ref _showPath, value, () => ShowPath);
            }
        }






        // TODO: later
        //public ICommand HelpDocsCommand { get; } = new HelpDocsCommand("carset-screen/#menu-images-tab");
    }
}
