using ArgData;
using ArgData.Entities;
using ArgEditor.Features.CarSet.PitCrew;
using ArgEditor.Features.Main;
using ArgEditor.Features.Persistence;
using ArgEditor.Features.Persistence.Common.CarSets;
using ArgEditor.Features.Persistence.LoadCarSet;
using ArgEditor.Infrastructure;
using ArgEditor.Mappers;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace ArgEditor.Features.CarSet.CarColors
{
    public class BrowseCarColorsViewModel : BaseViewModel
    {
        private readonly IFileDialog _fileDialog;

        public BrowseCarColorsViewModel(IFileDialog fileDialog)
        {
            Cars = new ObservableCollection<CarEditingViewModel>();

            _fileDialog = fileDialog;

            BrowseCommand = new ViewModelCommand
            {
                CanExecuteFunc = obj => true,
                ExecuteFunc = Browse
            };
        }

        private void Browse(object parameter)
        {
            var path = _fileDialog.SelectBrowseCarColorsFileToOpen();
            FilePath = path;

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            SelectedCar = null;

            LoadReload(path);
        }

        public void LoadReload(string path)
        {
            // global state...
            bool isSpecialShape = MainViewModelPasserArounder.MainViewModel.SelectedTeam.Car.IsSpecialShape;

            var fileType = Path.GetExtension(path).ToLowerInvariant();

            Tuple<ObservableCollection<CarEditingViewModel>, ObservableCollection<PitCrewViewModel>> readResult = null;

            if (fileType == ".arged")
            {
                try
                {
                    readResult = LoadFromCarSetFile(path, isSpecialShape);
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
                    readResult = LoadFromExeFile(path, isSpecialShape);
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
                    readResult = LoadFromF1EdFile(path, isSpecialShape);
                }
                catch
                {
                    MessageBox.Show("An error occurred when loading data from an F1Ed carset file.", "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (fileType == ".car")
            {
                try
                {
                    readResult = LoadFromCarFile(path, isSpecialShape);
                }
                catch
                {
                    MessageBox.Show("An error occurred when loading data from a CAR file.", "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (readResult != null)
            {
                Cars = readResult.Item1;
                PitCrews = readResult.Item2;
            }
            else
            {
                FilePath = string.Empty;
            }
        }

        private Tuple<ObservableCollection<CarEditingViewModel>, ObservableCollection<PitCrewViewModel>> LoadFromCarSetFile(string path, bool isSpecialShape)
        {
            var cars = new ObservableCollection<CarEditingViewModel>();
            var pitCrews = new ObservableCollection<PitCrewViewModel>();

            string fileData = File.ReadAllText(path);
            var carSet = JsonConvert.DeserializeObject<CarSetFile>(fileData);

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                var fileTeam = carSet.Teams[i];

                var car = new CarEditingViewModel();

                Mapper.MapCarSetCarColorsToCarEditingViewModel(fileTeam.CarColors, car);
                car.IsSpecialShape = isSpecialShape;
                cars.Add(car);

                var pitCrew = new PitCrewViewModel();

                Mapper.MapCarSetPitCrewColorsToPitCrewViewModel(fileTeam.PitCrewColors, pitCrew);
                pitCrews.Add(pitCrew);
            }

            return new Tuple<ObservableCollection<CarEditingViewModel>, ObservableCollection<PitCrewViewModel>>(cars, pitCrews);
        }

        private Tuple<ObservableCollection<CarEditingViewModel>, ObservableCollection<PitCrewViewModel>> LoadFromExeFile(string path, bool isSpecialShape)
        {
            var cars = new ObservableCollection<CarEditingViewModel>();
            var pitCrews = new ObservableCollection<PitCrewViewModel>();

            var exe = GpExeFile.At(path);
            var carColorReader = CarColorReader.For(exe);

            var carColors = carColorReader.ReadCarColors();

            foreach (Car carColor in carColors)
            {
                var car = new CarEditingViewModel();
                Mapper.MapDataCarToViewModelCar(carColor, car);
                car.IsSpecialShape = isSpecialShape;

                cars.Add(car);
            }

            var pitCrewColorReader = PitCrewColorReader.For(exe);
            var pitCrewColors = pitCrewColorReader.ReadPitCrewColors();

            foreach (ArgData.Entities.PitCrew pitCrew in pitCrewColors)
            {
                var pitCrewVM = new PitCrewViewModel();
                Mapper.MapDataPitCrewToViewModelPitCrew(pitCrew, pitCrewVM);

                pitCrews.Add(pitCrewVM);
            }

            return new Tuple<ObservableCollection<CarEditingViewModel>, ObservableCollection<PitCrewViewModel>>(cars, pitCrews);
        }

        private Tuple<ObservableCollection<CarEditingViewModel>, ObservableCollection<PitCrewViewModel>> LoadFromF1EdFile(string path, bool isSpecialShape)
        {
            var cars = new ObservableCollection<CarEditingViewModel>();
            var pitCrews = new ObservableCollection<PitCrewViewModel>();

            var result = LegacyCarSetLoader.Load(path);

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                var team = result.Teams[i];

                var car = new CarEditingViewModel();

                var carcar = new Car(team.CarColors);
                car.IsSpecialShape = isSpecialShape;
                Mapper.MapDataCarToViewModelCar(carcar, car);

                cars.Add(car);

                var pitcrew = new ArgData.Entities.PitCrew(team.PitCrewColors);
                var pitCrewVM = new PitCrewViewModel();
                Mapper.MapDataPitCrewToViewModelPitCrew(pitcrew, pitCrewVM);

                pitCrews.Add(pitCrewVM);
            }

            return new Tuple<ObservableCollection<CarEditingViewModel>, ObservableCollection<PitCrewViewModel>>(cars, pitCrews);
        }

        private Tuple<ObservableCollection<CarEditingViewModel>, ObservableCollection<PitCrewViewModel>> LoadFromCarFile(string path, bool isSpecialShape)
        {
            var cars = new ObservableCollection<CarEditingViewModel>();
            var pitCrews = new ObservableCollection<PitCrewViewModel>();

            var carcar = LegacyCarFiles.Load(path);
            var car = new CarEditingViewModel();
            car.IsSpecialShape = isSpecialShape;
            Mapper.MapDataCarToViewModelCar(carcar, car);

            cars.Add(car);

            return new Tuple<ObservableCollection<CarEditingViewModel>, ObservableCollection<PitCrewViewModel>>(cars, pitCrews);
        }



        private ObservableCollection<CarEditingViewModel> _cars;

        public ObservableCollection<CarEditingViewModel> Cars
        {
            get { return _cars; }
            set { SetProperty(ref _cars, value, () => Cars); }
        }

        private ObservableCollection<PitCrewViewModel> _pitCrews;

        public ObservableCollection<PitCrewViewModel> PitCrews
        {
            get { return _pitCrews; }
            set { SetProperty(ref _pitCrews, value, () => PitCrews); }
        }



        private CarEditingViewModel _selectedCar;

        public CarEditingViewModel SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                SetProperty(ref _selectedCar, value, () => SelectedCar);

                foreach (var car in Cars)
                {
                    car.BackgroundColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                }

                CalculateCanClickOk();

                if (SelectedCar != null)
                {
                    SelectedCar.BackgroundColor = new SolidColorBrush(Color.FromRgb(160, 160, 160));
                }
            }
        }

        private PitCrewViewModel _selectedPitCrew;

        public PitCrewViewModel SelectedPitCrew
        {
            get { return _selectedPitCrew; }
            set
            {
                SetProperty(ref _selectedPitCrew, value, () => SelectedPitCrew);

                foreach (var pitCrew in PitCrews)
                {
                    pitCrew.BackgroundColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                }

                CalculateCanClickOk();

                if (SelectedPitCrew != null)
                {
                    SelectedPitCrew.BackgroundColor = new SolidColorBrush(Color.FromRgb(160, 160, 160));
                }
            }
        }



        public ViewModelCommand BrowseCommand { get; }



        private void CalculateCanClickOk()
        {
            CanClickOk = SelectedCar != null || SelectedPitCrew != null;
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
