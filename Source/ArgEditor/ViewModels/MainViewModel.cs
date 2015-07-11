using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ArgEditor.Interactors;

namespace ArgEditor.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private TeamViewModel _selectedTeam;
        private byte _selectedColor;

        public MainViewModel()
        {
            Drivers = new List<DriverViewModel>();
            for (int driverIndex = 0; driverIndex < 40; driverIndex++)
            {
                byte number = Convert.ToByte(driverIndex + 1);

                if (driverIndex >= 36)
                    number = 0;

                string driverName = string.Format("Driver {0}", driverIndex + 1);
                var driverViewModel = new DriverViewModel(number, driverName, number, number);
                driverViewModel.PropertyChanged += DriverViewModelOnPropertyChanged;
                Drivers.Add(driverViewModel);
            }

            Teams = new List<TeamViewModel>();
            for (int teamIndex = 0; teamIndex < 20; teamIndex++)
            {
                string teamName = string.Format("Team {0}", teamIndex + 1);
                string engineName = string.Format("Engine {0}", teamIndex + 1);
                int driverStartIndex = teamIndex * 2;
                var teamViewModel = new TeamViewModel(teamName, engineName, Drivers[driverStartIndex], Drivers[driverStartIndex + 1]);
                teamViewModel.PropertyChanged += TeamViewModelOnPropertyChanged;
                Teams.Add(teamViewModel);
            }

            SelectedTeam = Teams[0];

            _driverPerformanceList = new ObservableCollection<DriverPerformanceItemViewModel>();
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
            if (propertyChangedEventArgs.PropertyName.Equals("RaceGripLevel"))
            {
                UpdateDriverPerformanceList();
            }
        }

        // TODO: stricter list?
        public List<DriverViewModel> Drivers { get; private set; }

        // TODO: stricter list?
        public List<TeamViewModel> Teams { get; private set; }

        public TeamViewModel SelectedTeam
        {
            get { return _selectedTeam; }
            set
            {
                {
                    if (value.Equals(_selectedTeam)) { return; }
                    _selectedTeam = value;
                    OnPropertyChanged("SelectedTeam");
                }
            }
        }

        public void SelectTeamByIndex(int teamIndex)
        {
            SelectedTeam = Teams[teamIndex];
        }

        public byte SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                if (value.Equals(_selectedColor)) { return; }
                _selectedColor = value;
                OnPropertyChanged("SelectedColor");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }



        private void UpdateDriverPerformanceList()
        {
            _driverPerformanceList.Clear();

            var performanceCalculator = new DriverPerformanceCalculator();
            var performanceItems = performanceCalculator.Calculate(this);

            foreach (var item in performanceItems)
            {
                _driverPerformanceList.Add(item);
            }

            OnPropertyChanged("DriverPerformanceList");
        }


        private readonly ObservableCollection<DriverPerformanceItemViewModel> _driverPerformanceList;

        public ObservableCollection<DriverPerformanceItemViewModel> DriverPerformanceList
        {
            get
            {
                return _driverPerformanceList;
            }
        }
    }
}
