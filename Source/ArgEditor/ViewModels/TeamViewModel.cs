using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ArgEditor.ViewModels
{
    public class TeamViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _engine;
        private int _horsepower;

        public TeamViewModel()
        {
            Drivers = new List<DriverViewModel>();
            Car = new CarEditingViewModel();
        }

        public TeamViewModel(string name, string engine, DriverViewModel driver1, DriverViewModel driver2)
        {
            Name = name;
            Engine = engine;

            Drivers = new List<DriverViewModel>();
            Drivers.Add(driver1);
            Drivers.Add(driver2);

            Car = new CarEditingViewModel();
            PitCrew = new PitCrewViewModel();
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Equals(_name)) { return; }
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Engine
        {
            get { return _engine; }
            set
            {
                if (value.Equals(_engine)) { return; }
                _engine = value;
                OnPropertyChanged("Engine");
            }
        }

        public int Horsepower
        {
            get { return _horsepower; }
            set
            {
                if (value.Equals(_horsepower)) { return; }
                _horsepower = value;
                OnPropertyChanged("Horsepower");
            }
        }

        public CarEditingViewModel Car { get; set; }

        public PitCrewViewModel PitCrew { get; set; }

        // TODO: striktare lista!
        public List<DriverViewModel> Drivers { get; private set; }



        // TODO: somewhere else
        //public List<int> AvailableDriverNumbers
        public ObservableCollection<byte> AvailableDriverNumbers
        {
            get
            {
                var list = new ObservableCollection<byte>();
                for (byte i = 1; i <= 40; i++)
                {
                    list.Add(i);
                }
                return list;
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
    }
}
