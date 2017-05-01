using ArgEditor.Commands;
using ArgEditor.Interactors;
using ArgEditor.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ArgEditor.ViewModels
{
    public class MainViewModel : BaseViewModel, IDataErrorInfo
    {
        private TeamViewModel _selectedTeam;
        private HelmetViewModel _selectedHelmet;

        public MainViewModel()
        {
            SetupDrivers();
            SetupTeams();

            SelectedTeam = Teams[0];
            SelectedHelmet = Drivers[0].Helmet;

            Palette = new PaletteViewModel();
            Palette.ActivePaletteTool = PaletteTool.Paint;

            _driverPerformanceList = new ObservableCollection<DriverPerformanceItemViewModel>();
            // TODO: default values from ArgData?
            PlayerHorsepower = 716;
            GeneralGripLevel = 1;
            ChanceOfRainPercent = 6;
            RainAtFirstTrack = false;

            PointsSystem = new PointsSystemViewModel();
            DamageSettings = new DamageSettingsViewModel();

            SingleSetupViewModel = new SetupViewModel();

            MultiSetupRaceSetups = MultiSetupSetup.SetupList();
            MultiSetupQualifyingSetups = MultiSetupSetup.SetupList();
            SelectedSetupMultiSetupViewModel = MultiSetupRaceSetups[0];
        }

        private void SetupDrivers()
        {
            Drivers = new List<DriverViewModel>();
            //for (int driverIndex = 0; driverIndex < ArgEditorConstants.DriverNumberMax; driverIndex++)
            for (int driverIndex = 0; driverIndex < ArgEditorConstants.DriverCountSupported; driverIndex++)
            {
                byte number = Convert.ToByte(driverIndex + 1);

                //if (driverIndex >= ArgEditorConstants.DriverCountSupported)
                //    number = 0;

                string driverName = $"Driver {driverIndex + 1}";
                var driverViewModel = new DriverViewModel(number, driverName, number, number);
                driverViewModel.PropertyChanged += DriverViewModelOnPropertyChanged;
                Drivers.Add(driverViewModel);
            }
        }

        private void SetupTeams()
        {
            Teams = new List<TeamViewModel>();
            for (int teamIndex = 0; teamIndex < ArgEditorConstants.TeamCountSupported; teamIndex++)
            {
                string teamName = $"Team {teamIndex + 1}";
                string engineName = $"Engine {teamIndex + 1}";
                int driverStartIndex = teamIndex*2;
                var teamViewModel = new TeamViewModel(teamName, engineName, Drivers[driverStartIndex],
                    Drivers[driverStartIndex + 1]);
                Drivers[driverStartIndex].Team = teamViewModel;
                Drivers[driverStartIndex + 1].Team = teamViewModel;
                teamViewModel.PropertyChanged += TeamViewModelOnPropertyChanged;

                if (teamIndex == 0)
                {
                    teamViewModel.Car.IsSpecialShape = true;
                }

                Teams.Add(teamViewModel);
            }
        }

        private void TeamViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName.Equals("Horsepower"))
            {
                UpdateDriverPerformanceList();
            }
        }

        private void DriverViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName.Equals("QualifyingGripLevel") ||
                propertyChangedEventArgs.PropertyName.Equals("RaceGripLevel") ||
                propertyChangedEventArgs.PropertyName.Equals("Name"))
            {
                UpdateDriverPerformanceList();
            }

            if (propertyChangedEventArgs.PropertyName.Equals("Number"))
            {
                var groupBys = Drivers
                    .GroupBy(d => d.Number)
                    .Where(grp => grp.Count() > 1 && grp.Key > 0);
                var groupedNumbers = groupBys.ToList();

                //if (PerformDriverNumberCheck)
                //{
                    foreach (var driver in Drivers)
                    {
                        driver.HasSameNumberAsOtherDriver = false;
                    }

                    foreach (var number in groupedNumbers)
                    {
                        foreach (var drv in Drivers.Where(d => d.Number == number.Key))
                        {
                            drv.HasSameNumberAsOtherDriver = true;
                        }
                    }
                //}

                var count = Drivers.Count(n => n.Number > 0);

                if (count >= 26)
                    ActiveDriverCountMessage = $"{count} active drivers.";
                else
                    ActiveDriverCountMessage = $"{count} active drivers. You need {26 - count} more driver(s) before you can export.";
            }
        }



        //public bool PerformDriverNumberCheck { get; set; } = false; //true;


        public List<DriverViewModel> Drivers { get; private set; }

        public List<TeamViewModel> Teams { get; private set; }

        public TeamViewModel SelectedTeam
        {
            get { return _selectedTeam; }
            set
            {
                {
                    if (value.Equals(_selectedTeam)) { return; }
                    _selectedTeam = value;
                    OnPropertyChanged(nameof(SelectedTeam));
                }
            }
        }

        public void SelectTeamByIndex(int teamIndex)
        {
            SelectedTeam = Teams[teamIndex];
        }


        public HelmetViewModel SelectedHelmet
        {
            get { return _selectedHelmet; }
            set { SetProperty(ref _selectedHelmet, value, () => SelectedHelmet);
                //if (value.Equals(_selectedHelmet)) { return; }
                //_selectedHelmet = value;
                //OnPropertyChanged(nameof(SelectedHelmet));
            }
        }

        private string _activeDriverCountMessage;

        public string ActiveDriverCountMessage
        {
            get { return _activeDriverCountMessage; }
            set { SetProperty(ref _activeDriverCountMessage, value, () => ActiveDriverCountMessage); }
        }



        // TODO: put these in a SettingsViewModel ??

        public int PlayerHorsepower
        {
            get
            {
                return _playerHorsepower;
            }
            set
            {
                SetProperty(ref _playerHorsepower, value, () => PlayerHorsepower);

                //if (value.Equals(_playerHorsepower)) { return; }
                //_playerHorsepower = value;
                //OnPropertyChanged(nameof(PlayerHorsepower));
            }
        }


        public int GeneralGripLevel
        {
            get
            {
                return _generalGripLevel;
            }
            set
            {
                if (value.Equals(_generalGripLevel)) { return; }
                _generalGripLevel = value;
                OnPropertyChanged(nameof(GeneralGripLevel));
            }
        }

        public int ChanceOfRainPercent
        {
            get
            {
                return _chanceOfRainPercent;
            }
            set
            {
                if (value.Equals(_chanceOfRainPercent)) { return; }
                _chanceOfRainPercent = value;
                OnPropertyChanged(nameof(ChanceOfRainPercent));
            }
        }

        public bool RainAtFirstTrack
        {
            get
            {
                return _rainAtFirstTrack;
            }
            set
            {
                if (value.Equals(_rainAtFirstTrack)) { return; }
                _rainAtFirstTrack = value;
                OnPropertyChanged(nameof(RainAtFirstTrack));
            }
        }


        public DamageSettingsViewModel DamageSettings { get; private set; }



        public PaletteViewModel Palette { get; private set; }

        public PointsSystemViewModel PointsSystem { get; private set; }


        private void UpdateDriverPerformanceList()
        {
            _driverPerformanceList.Clear();

            var performanceCalculator = new DriverPerformanceCalculator();
            var performanceItems = performanceCalculator.Calculate(Teams, DriverPerformanceMetric);

            foreach (var item in performanceItems)
            {
                _driverPerformanceList.Add(item);
            }

            OnPropertyChanged(nameof(DriverPerformanceList));
        }


        private readonly ObservableCollection<DriverPerformanceItemViewModel> _driverPerformanceList;
        private int _playerHorsepower;
        private int _generalGripLevel;
        private int _chanceOfRainPercent;
        private bool _rainAtFirstTrack;
        private PerformanceMetric _driverPerformanceMetric;

        public ObservableCollection<DriverPerformanceItemViewModel> DriverPerformanceList
        {
            get
            {
                return _driverPerformanceList;
            }
        }

        public PerformanceMetric DriverPerformanceMetric
        {
            get { return _driverPerformanceMetric; }
            set
            {
                _driverPerformanceMetric = value;
                OnPropertyChanged(nameof(DriverPerformanceMetric));
                UpdateDriverPerformanceList();
            }
        }


        // Commands!

        // ReSharper disable UnusedMember.Global, since it doesn't seem to find its usage inside the XAML file
        public ICommand OpenCarSetCommand { get; } = new OpenCarSetCommand(new FileDialog());
        public ICommand SaveCarSetCommand { get; } = new SaveCarSetCommand(new FileDialog());
        public ICommand SaveLegacyCarSetCommand { get; } = new SaveLegacyCarSetCommand(new FileDialog());

        public ICommand DisplayImportWizardCommand { get; } = new DisplayImportWizardCommand();
        public ICommand ImportFromExeCommand { get; } = new ImportFromExeCommand(new FileDialog());
        public ICommand ImportFromNameFileCommand { get; } = new ImportFromNameFileCommand(new FileDialog());

        public ICommand DisplayExportWizardCommand { get; } = new DisplayExportWizardCommand();
        public ICommand ExportToExeCommand { get; } = new ExportToExeCommand(new FileDialog());
        public ICommand ExportToNameFileCommand { get; } = new ExportToNameFileCommand(new FileDialog());

        public ICommand ExitApplicationCommand { get; } = new ExitApplicationCommand();

        public ICommand HelpDocsCommand { get; } = new HelpDocsCommand();
        public ICommand ShowCheckForUpdatesWindowCommand { get; } = new ShowCheckForUpdatesWindowCommand();
        public ICommand ShowAboutWindowCommand { get; } = new ShowAboutWindowCommand();

        public ICommand PaletteSelectNextBrighterColorCommand { get; } = new PaletteSelectNextBrighterColorCommand();
        public ICommand PaletteSelectNextDarkerColorCommand { get; } = new PaletteSelectNextDarkerColorCommand();

        // a test, sort of
        public ICommand ShowWarningMessageCommand { get; } = new ShowWarningMessageCommand();
        public ICommand ShowErrorMessageCommand { get; } = new ShowErrorMessageCommand();
        public ICommand ShowMessageCommand { get; } = new ShowMessageCommand();

        public ICommand LoadSingleSetupFileCommand { get; } = new LoadSingleSetupFileCommand(new FileDialog());
        public ICommand SaveSingleSetupFileCommand { get; } = new SaveSingleSetupFileCommand(new FileDialog());

        // TODO: more commands
        // Palette, set mode?
        // UndoCarPainting
        // RedoCarPainting
        // UndoHelmetPainting
        // RedoHelmetPainting
        // ExportNameFile
        // about? checkforupdaes+?
        // ?


        //public ValidationRule ValueRangeValidation { get; } = new ValueRangeValidation();

        // ReSharper restore UnusedMember.Global

        public string Error { get; }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(GeneralGripLevel))
                {
                    if (GeneralGripLevel < 1 || GeneralGripLevel > 100)
                    {
                        return "Value must be between 1 and 100";
                    }
                }
                if (columnName == nameof(PlayerHorsepower))
                {
                    if (PlayerHorsepower < 400 || PlayerHorsepower > 1460)
                    {
                        return "Value must be between 400 and 1460";
                    }
                }
                if (columnName == nameof(ChanceOfRainPercent))
                {
                    if (ChanceOfRainPercent < 0 || ChanceOfRainPercent > 100)
                    {
                        return "Value must be between 0 and 100";
                    }
                }

                return "";
            }
        }



        private SetupViewModel _singleSetupViewModel;

        public SetupViewModel SingleSetupViewModel
        {
            get { return _singleSetupViewModel; }
            set { SetProperty(ref _singleSetupViewModel, value, () => SingleSetupViewModel); }
        }


        private SetupItemViewModel _selectedSetupMultiSetupViewModel;

        public SetupItemViewModel SelectedSetupMultiSetupViewModel
        {
            get { return _selectedSetupMultiSetupViewModel; }
            set { SetProperty(ref _selectedSetupMultiSetupViewModel, value, () => SelectedSetupMultiSetupViewModel); }
        }


        public List<SetupItemViewModel> MultiSetupQualifyingSetups { get; set; }
        public List<SetupItemViewModel> MultiSetupRaceSetups { get; set; }

    }


    public class SetupItemViewModel : BaseViewModel
    {

        private string _description = "";

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value, () => Description); }
        }

        private SetupViewModel _setup = new SetupViewModel();

        public SetupViewModel Setup
        {
            get { return _setup; }
            set { SetProperty(ref _setup, value, () => Setup); }
        }
    }


    public static class MultiSetupSetup
    {
        public static List<SetupItemViewModel> SetupList()
        {
            var list = new List<SetupItemViewModel>();

            for (int i = 0; i <= 15; i++)
            {
                var item = new SetupItemViewModel
                {
                    Description = _trackNames[i],
                    Setup = new SetupViewModel()
                    // TODO: track default setup
                };

                item.Setup.FrontWing = Convert.ToByte(i);

                list.Add(item);
            }

            return list;
        }

        private static readonly string[] _trackNames =
        {
            "Phoenix", "Interlagos", "Imola", "Monaco", "Montreal", "Mexico City", "Magny-Cours", "Silverstone",
            "Hockenheim", "Hungaroring", "Spa-Francorchamps", "Monza", "Estoril", "Barcelona", "Suzuka", "Adelaide"
        };

    }


    public enum PerformanceMetric
    {
        Race = 0,
        Qualifying = 1
    }
}
