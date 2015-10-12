using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ArgEditor.Interactors;

namespace ArgEditor.ViewModels
{
    public class MainViewModel : BaseViewModel
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

            _driverPerformanceList = new ObservableCollection<DriverPerformanceItemViewModel>();
            PlayerHorsepower = 716;
        }

        private void SetupDrivers()
        {
            Drivers = new List<DriverViewModel>();
            for (int driverIndex = 0; driverIndex < ArgEditorConstants.DriverCount; driverIndex++)
            {
                byte number = Convert.ToByte(driverIndex + 1);

                if (driverIndex >= ArgEditorConstants.DriverCountSupported)
                    number = 0;

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
            if (propertyChangedEventArgs.PropertyName.Equals("RaceGripLevel") ||
                propertyChangedEventArgs.PropertyName.Equals("Name"))
            {
                UpdateDriverPerformanceList();
            }
        }

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
                    OnPropertyChanged();
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
            set
            {
                {
                    if (value.Equals(_selectedHelmet)) { return; }
                    _selectedHelmet = value;
                    OnPropertyChanged();
                }
            }
        }


        public int PlayerHorsepower
        {
            get
            {
                return _playerHorsepower;
            }
            set
            {
                if (value.Equals(_playerHorsepower)) { return; }
                _playerHorsepower = value;
                OnPropertyChanged();
            }
        }


        public PaletteViewModel Palette { get; private set; }


        private void UpdateDriverPerformanceList()
        {
            _driverPerformanceList.Clear();

            var performanceCalculator = new DriverPerformanceCalculator();
            var performanceItems = performanceCalculator.Calculate(Teams, DriverPerformanceMetric);

            foreach (var item in performanceItems)
            {
                _driverPerformanceList.Add(item);
            }

            OnPropertyChanged("DriverPerformanceList");
        }


        private readonly ObservableCollection<DriverPerformanceItemViewModel> _driverPerformanceList;
        private int _playerHorsepower;
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
                OnPropertyChanged();
                UpdateDriverPerformanceList();
            }
        }
    }

    public enum PerformanceMetric
    {
        Race = 0,
        Qualifying = 1
    }
}
