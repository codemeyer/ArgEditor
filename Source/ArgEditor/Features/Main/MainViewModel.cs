using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ArgData;
using ArgEditor.Features.Application.About;
using ArgEditor.Features.Application.Shared;
using ArgEditor.Features.CarSet;
using ArgEditor.Features.CarSet.CarColors;
using ArgEditor.Features.CarSet.DriverPerformance;
using ArgEditor.Features.CarSet.HelmetColors;
using ArgEditor.Features.CarSet.MenuImages;
using ArgEditor.Features.CarSet.PointsSystem;
using ArgEditor.Features.CarSetupEditing;
using ArgEditor.Features.GameSettings;
using ArgEditor.Features.ImportExport.ExportTo;
using ArgEditor.Features.ImportExport.ImportFrom;
using ArgEditor.Features.Palette;
using ArgEditor.Features.Persistence;
using ArgEditor.Features.Persistence.LoadCarSet;
using ArgEditor.Features.Persistence.SaveCarSet;
using ArgEditor.Features.UndoRedo;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.Main
{
    public class MainViewModel : BaseViewModel, IDataErrorInfo
    {
        public MainViewModel()
        {
            // TODO: put CarSet stuff in separate CarSetViewModel ?

            SetupDrivers();
            SetupTeams();

            SelectedTeam = Teams[0];
            SelectedHelmet = Drivers[0].Helmet;
            SelectedMenuImage = Drivers[0].MenuImage;

            Palette = new PaletteViewModel();
            Palette.ActivePaletteTool = PaletteTool.Paint;

            _driverPerformanceList = new ObservableCollection<DriverPerformanceItemViewModel>();

            PlayerHorsepower = DefaultValues.PlayerHorsepowerValue;
            GeneralGripLevel = DefaultValues.GeneralGripLevel;
            ChanceOfRainPercent = DefaultValues.ChanceOfRain;
            RainAtFirstTrack = DefaultValues.RainAtFirstTrack;

            PointsSystem = new PointsSystemViewModel();
            DamageSettings = new DamageSettingsViewModel();
            SetupTabViewModel = new SetupTabViewModel();
            AboutTabViewModel = new AboutTabViewModel();

            SelectedCarSetTabIndex = 0;
            UpdateActionButtonsVisibility();

            // hack?
            UpdateSelectedCar(0);
            Teams[0].NotifyIsSelected();

            // LOLSOB
            SelectedTeam = Teams[1];
            SelectedTeam = Teams[0];

            //SelectedTrackType
        }

        private void SetupDrivers()
        {
            Drivers = new List<DriverViewModel>();

            for (int driverIndex = 0; driverIndex < ArgEditorConstants.DriverCountSupported; driverIndex++)
            {
                byte number = Convert.ToByte(driverIndex + 1);

                string driverName = $"Driver {driverIndex + 1}";
                var driverViewModel = new DriverViewModel(number, driverName, number, number);

                if (driverIndex == 0)
                {
                    driverViewModel.Helmet.IsSelected = true;
                    driverViewModel.MenuImage.IsSelected = true;
                }

                //driverViewModel.MenuImage.Image = MenuImageLoader.GetDefault();
                driverViewModel.MenuImage.SetDefault();
                //driverViewModel.MenuImage.MagnifiedImage = MenuImageLoader.GetDefault();

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
                var teamViewModel = new TeamViewModel(teamIndex, teamName, engineName, Drivers[driverStartIndex],
                    Drivers[driverStartIndex + 1]);
                Drivers[driverStartIndex].Team = teamViewModel;
                Drivers[driverStartIndex + 1].Team = teamViewModel;
                teamViewModel.PropertyChanged += TeamViewModelOnPropertyChanged;

                if (teamIndex == 0)
                {
                    teamViewModel.Car.IsSpecialShape = true;
                    teamViewModel.IsSelected = true;
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

            if (propertyChangedEventArgs.PropertyName.Equals("Name") ||
                propertyChangedEventArgs.PropertyName.Equals("Number"))
            {
                foreach (var driver in Drivers)
                {
                    if (driver.Number == 0)
                    {
                        driver.HasNumberWithoutName = false;
                        continue;
                    }

                    driver.HasNumberWithoutName = string.IsNullOrWhiteSpace(driver.Name);
                }
            }
        }



        //public bool PerformDriverNumberCheck { get; set; } = false; //true;


        public List<DriverViewModel> Drivers { get; private set; }

        public List<TeamViewModel> Teams { get; private set; }

        private TeamViewModel _selectedTeam;

        public TeamViewModel SelectedTeam
        {
            get { return _selectedTeam; }
            set
            {
                {
                    if (value.Equals(_selectedTeam)) { return; }
                    _selectedTeam = value;
                    OnPropertyChanged(nameof(SelectedTeam));
                    UpdateSelectedCar(value.Index);
                }
            }
        }

        private void UpdateSelectedCar(int selectedIndex)
        {
            foreach (var team in Teams)
            {
                team.IsSelected = team.Index == selectedIndex;
                team.NotifyIsSelected();
            }

            var x = Teams[0].IsSelected;
        }

        public void SelectTeamByIndex(int teamIndex)
        {
            SelectedTeam = Teams[teamIndex];
        }


        private HelmetViewModel _selectedHelmet;

        public HelmetViewModel SelectedHelmet
        {
            get { return _selectedHelmet; }
            set {
                if (SetProperty(ref _selectedHelmet, value, () => SelectedHelmet))
                {
                    UpdateSelectedHelmet(value);
                }
            }
        }

        private void UpdateSelectedHelmet(HelmetViewModel helmet)
        {
            foreach (var driver in Drivers)
            {
                driver.Helmet.IsSelected = false;
            }

            helmet.IsSelected = true;
        }


        private MenuImageViewModel _selectedMenuImage;

        public MenuImageViewModel SelectedMenuImage
        {
            get { return _selectedMenuImage; }
            set {
                if (SetProperty(ref _selectedMenuImage, value, () => SelectedMenuImage))
                {
                    UpdateSelectedMenuImage(value);
                }
            }
        }

        private void UpdateSelectedMenuImage(MenuImageViewModel menuImage)
        {
            foreach (var driver in Drivers)
            {
                driver.MenuImage.IsSelected = false;
            }

            menuImage.IsSelected = true;
        }


        private string _activeDriverCountMessage;

        public string ActiveDriverCountMessage
        {
            get { return _activeDriverCountMessage; }
            set { SetProperty(ref _activeDriverCountMessage, value, () => ActiveDriverCountMessage); }
        }



        // TODO: put these in a SettingsViewModel ??

        private int _playerHorsepower;
        private int _generalGripLevel;
        private int _chanceOfRainPercent;
        private bool _rainAtFirstTrack;

        public int PlayerHorsepower
        {
            get { return _playerHorsepower; }
            set { SetProperty(ref _playerHorsepower, value, () => PlayerHorsepower); }
        }


        public int GeneralGripLevel
        {
            get { return _generalGripLevel; }
            set { SetProperty(ref _generalGripLevel, value, () => GeneralGripLevel); }
        }

        public int ChanceOfRainPercent
        {
            get { return _chanceOfRainPercent; }
            set { SetProperty(ref _chanceOfRainPercent, value, () => ChanceOfRainPercent); }
        }

        public bool RainAtFirstTrack
        {
            get { return _rainAtFirstTrack; }
            set { SetProperty(ref _rainAtFirstTrack, value, () => RainAtFirstTrack); }
        }


        public DamageSettingsViewModel DamageSettings { get; private set; }

        public PaletteViewModel Palette { get; private set; }

        public PointsSystemViewModel PointsSystem { get; private set; }


        public void UpdateDriverPerformanceList()
        {
            _driverPerformanceList.Clear();

            var performanceCalculator = new DriverPerformanceCalculator();
            var performanceItems = performanceCalculator.Calculate(Teams, DriverPerformanceMetric, SelectedTrackType);

            foreach (var item in performanceItems)
            {
                _driverPerformanceList.Add(item);
            }

            OnPropertyChanged(nameof(DriverPerformanceList));
        }


        private readonly ObservableCollection<DriverPerformanceItemViewModel> _driverPerformanceList;

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

        // TODO: same FileDialog injected everywhere?
        // ReSharper disable UnusedMember.Global, since it doesn't seem to find its usage inside the XAML file
        public ICommand OpenCarSetCommand { get; } = new OpenCarSetCommand(new FileDialog());
        public ICommand SaveCarSetCommand { get; } = new SaveCarSetCommand(new FileDialog());

        public ICommand DisplayImportWizardCommand { get; } = new DisplayImportWizardCommand();
        public ICommand ImportFromExeCommand { get; } = new ImportFromExeCommand(new FileDialog());
        public ICommand ImportFromNameFileCommand { get; } = new ImportFromNameFileCommand(new FileDialog());

        public ICommand DisplayExportWizardCommand { get; } = new DisplayExportWizardCommand();
        public ICommand ExportToExeCommand { get; } = new ExportToExeCommand(new FileDialog());
        public ICommand ExportToNameFileCommand { get; } = new ExportToNameFileCommand(new FileDialog());

        public ICommand DisplayGameSettingsImportWizardCommand { get; } = new DisplayGameSettingsImportWizardCommand();
        public ICommand DisplayGameSettingsExportWizardCommand { get; } = new DisplayGameSettingsExportWizardCommand();

        public ICommand ExitApplicationCommand { get; } = new ExitApplicationCommand();

        public ICommand HelpDocsCommand { get; } = new HelpDocsCommand();

        public ICommand PaletteSelectNextBrighterColorCommand { get; } = new PaletteSelectNextBrighterColorCommand();
        public ICommand PaletteSelectNextDarkerColorCommand { get; } = new PaletteSelectNextDarkerColorCommand();

        public ICommand LoadMenuImageCommand { get; } = new LoadMenuImageCommand();
        public ICommand SelectedMenuImageFromDatCommand { get; } = new SelectedMenuImageFromDatCommand();
        public ICommand SaveMenuImageToFileCommand { get; } = new SaveMenuImageToFileCommand(new FileDialog());
        public ICommand ClearMenuImageCommand { get; } = new ClearMenuImageCommand();

        // a test, sort of
        public ICommand ShowWarningMessageCommand { get; } = new ShowWarningMessageCommand();
        public ICommand ShowErrorMessageCommand { get; } = new ShowErrorMessageCommand();
        public ICommand ShowMessageCommand { get; } = new ShowMessageCommand();

        public ICommand UndoCarPitCrewPaintingActionCommand { get; } = new UndoCarPitCrewPaintingActionCommand();
        public ICommand RedoCarPitCrewPaintingActionCommand { get; } = new RedoCarPitCrewPaintingActionCommand();
        public ICommand CopyCarToClipboardCommand { get; } = new CopyCarToClipboardCommand();
        public ICommand PasteCarFromClipboardCommand { get; } = new PasteCarFromClipboardCommand();
        public ICommand LoadCarFileCommand { get; } = new LoadCarFileCommand(new FileDialog());
        public ICommand SaveCarFileCommand { get; } = new SaveCarFileCommand(new FileDialog());
        public ICommand BrowseCarColorsCommand { get; } = new BrowseCarColorsCommand(new FileDialog());

        public ICommand UndoBrokerCommand { get; } = new UndoBrokerCommand();
        public ICommand RedoBrokerCommand { get; } = new RedoBrokerCommand();

        public ICommand UndoHelmetPaintingActionCommand { get; } = new UndoHelmetPaintingActionCommand();
        public ICommand RedoHelmetPaintingActionCommand { get; } = new RedoHelmetPaintingActionCommand();
        public ICommand CopyHelmetToClipboardCommand { get; } = new CopyHelmetToClipboardCommand();
        public ICommand PasteHelmetFromClipboardCommand { get; } = new PasteHelmetFromClipboardCommand();
        public ICommand LoadHelmetFileCommand { get; } = new LoadHelmetFileCommand(new FileDialog());
        public ICommand SaveHelmetFileCommand { get; } = new SaveHelmetFileCommand(new FileDialog());

        public ICommand UndoMenuImageActionCommand { get; } = new UndoMenuImageActionCommand();
        public ICommand RedoMenuImageActionCommand { get; } = new RedoMenuImageActionCommand();
        public ICommand CopyMenuImageToClipboardCommand { get; } = new CopyMenuImageToClipboardCommand();
        public ICommand PasteMenuImageFromClipboardCommand { get; } = new PasteMenuImageFromClipboardCommand();

        public ICommand PerformanceCopyQualifyingToRaceCommand { get; } = new PerformanceCopyQualifyingToRaceCommand();
        public ICommand PerformanceCopyRaceToQualifyingCommand { get; } = new PerformanceCopyRaceToQualifyingCommand();

        // TODO: more commands
        // Palette, set mode?
        // ?


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

        public SetupTabViewModel SetupTabViewModel { get; set; }

        public AboutTabViewModel AboutTabViewModel { get; set; }



        private int _selectedCarSetTabIndex;

        public int SelectedCarSetTabIndex
        {
            get { return _selectedCarSetTabIndex; }
            set
            {
                if (SetProperty(ref _selectedCarSetTabIndex, value, () => SelectedCarSetTabIndex))
                {
                    UpdateActionButtonsVisibility();
                }
            }
        }


        private bool _syncDriverPerformance = true;

        public bool SyncDriverPerformance
        {
            get { return _syncDriverPerformance; }
            set { SetProperty(ref _syncDriverPerformance, value, () => SyncDriverPerformance); }
        }


        private int _selectedMainTabIndex;

        public int SelectedMainTabIndex
        {
            get { return _selectedMainTabIndex; }
            set { SetProperty(ref _selectedMainTabIndex, value, () => SelectedMainTabIndex); }
        }

        private Visibility _showTeamDriverNamesActionButtons;

        public Visibility ShowTeamDriverNamesActionButtons
        {
            get { return _showTeamDriverNamesActionButtons; }
            set { SetProperty(ref _showTeamDriverNamesActionButtons, value, () => ShowTeamDriverNamesActionButtons); }
        }

        private Visibility _showPerformanceActionButtons;

        public Visibility ShowPerformanceActionButtons
        {
            get { return _showPerformanceActionButtons; }
            set { SetProperty(ref _showPerformanceActionButtons, value, () => ShowPerformanceActionButtons); }
        }

        private Visibility _showCarPitCrewActionButtons;

        public Visibility ShowCarPitCrewActionButtons
        {
            get { return _showCarPitCrewActionButtons; }
            set { SetProperty(ref _showCarPitCrewActionButtons, value, () => ShowCarPitCrewActionButtons); }
        }


        private Visibility _showHelmetActionButtons;

        public Visibility ShowHelmetActionButtons
        {
            get { return _showHelmetActionButtons; }
            set { SetProperty(ref _showHelmetActionButtons, value, () => ShowHelmetActionButtons); }
        }


        private Visibility _showMenuImageActionButtons;

        public Visibility ShowMenuImageActionButtons
        {
            get { return _showMenuImageActionButtons; }
            set { SetProperty(ref _showMenuImageActionButtons, value, () => ShowMenuImageActionButtons); }
        }


        private byte _isEditingDriverIndex1 = 99;

        public byte IsEditingDriverIndex1
        {
            get { return _isEditingDriverIndex1; }
            set
            {
                _isEditingDriverIndex1 = value;

                foreach (var drv in DriverPerformanceList)
                {
                    if (IsEditingIgnoreMetric)
                    {
                        drv.IsCurrentlyBeingEdited = (drv.Number == value ||
                                                      drv.Number == IsEditingDriverIndex2);
                    }
                    else
                    {
                        drv.IsCurrentlyBeingEdited = (drv.Number == value ||
                                                      drv.Number == IsEditingDriverIndex2)
                                                     && DriverPerformanceMetric == IsEditingDriverType;
                    }
                }
            }
        }

        private byte _isEditingDriverIndex2 = 99;

        public byte IsEditingDriverIndex2
        {
            get { return _isEditingDriverIndex2; }
            set
            {
                _isEditingDriverIndex2 = value;

                foreach (var drv in DriverPerformanceList)
                {
                    if (IsEditingIgnoreMetric)
                    {
                        drv.IsCurrentlyBeingEdited = (drv.Number == value ||
                                                      drv.Number == IsEditingDriverIndex1);
                    }
                    else
                    {
                        drv.IsCurrentlyBeingEdited = (drv.Number == value ||
                                                      drv.Number == IsEditingDriverIndex1)
                                                     && DriverPerformanceMetric == IsEditingDriverType;
                    }
                }
            }
        }

        public bool IsEditingIgnoreMetric { get; set; } = true;


        private PerformanceMetric _isEditingDriverType = PerformanceMetric.Race;

        public PerformanceMetric IsEditingDriverType
        {
            get { return _isEditingDriverType; }
            set
            {
                _isEditingDriverType = value;
                OnPropertyChanged(nameof(IsEditingDriverType));
                OnPropertyChanged(nameof(IsEditingDriverIndex1));
                OnPropertyChanged(nameof(IsEditingDriverIndex2));
            }
        }


        private void UpdateActionButtonsVisibility()
        {
            ShowTeamDriverNamesActionButtons = SelectedCarSetTabIndex == 0 ? Visibility.Visible : Visibility.Collapsed;
            ShowPerformanceActionButtons = SelectedCarSetTabIndex == 1 ? Visibility.Visible : Visibility.Collapsed;
            ShowCarPitCrewActionButtons = SelectedCarSetTabIndex == 2 ? Visibility.Visible : Visibility.Collapsed;
            ShowHelmetActionButtons = SelectedCarSetTabIndex == 3 ? Visibility.Visible : Visibility.Collapsed;
            ShowMenuImageActionButtons = SelectedCarSetTabIndex == 4 ? Visibility.Visible : Visibility.Collapsed;
        }


        private TrackTypeValue _selectedTrackType = TrackTypeValue.Medium;


        public List<TrackType> AvailableTrackTypes
        {
            get
            {
                var list = new List<TrackType>();

                list.Add(new TrackType("Slow", TrackTypeValue.Slow));
                list.Add(new TrackType("Medium", TrackTypeValue.Medium));
                list.Add(new TrackType("Fast", TrackTypeValue.Fast));

                return list;
            }
        }

        public TrackTypeValue SelectedTrackType
        {
            get { return _selectedTrackType; }
            set
            {
                SetProperty(ref _selectedTrackType, value, () => SelectedTrackType);
                UpdateDriverPerformanceList();
            }
        }

        public bool IsLoading { get; set; }
    }


    public enum PerformanceMetric
    {
        Race = 0,
        Qualifying = 1
    }
}
