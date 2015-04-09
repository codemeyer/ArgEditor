using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ArgEditor.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private TeamViewModel _selectedTeam;

        public MainViewModel()
        {
            Drivers = new List<DriverViewModel>();
            for (int driverIndex = 0; driverIndex < 36; driverIndex++)
            {
                byte number = Convert.ToByte(driverIndex + 1);
                string driverName = string.Format("Driver {0}", driverIndex + 1);
                Drivers.Add(new DriverViewModel(number, driverName, number, number));
            }

            Teams = new List<TeamViewModel>();
            for (int teamIndex = 0; teamIndex < 18; teamIndex++)
            {
                string teamName = string.Format("Team {0}", teamIndex + 1);
                string engineName = string.Format("Engine {0}", teamIndex + 1);
                int driverStartIndex = teamIndex * 2;
                Teams.Add(new TeamViewModel(teamName, engineName, Drivers[driverStartIndex], Drivers[driverStartIndex + 1]));
            }

            SelectedTeam = Teams[0];
        }

        // TODO: striktare lista!
        public List<DriverViewModel> Drivers { get; private set; }

        // TODO: striktare lista!
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


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
