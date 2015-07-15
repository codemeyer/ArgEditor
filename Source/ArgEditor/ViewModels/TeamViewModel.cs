using System.Collections.Generic;

namespace ArgEditor.ViewModels
{
    public class TeamViewModel : BaseViewModel
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
                OnPropertyChanged();
            }
        }

        public string Engine
        {
            get { return _engine; }
            set
            {
                if (value.Equals(_engine)) { return; }
                _engine = value;
                OnPropertyChanged();
            }
        }

        public int Horsepower
        {
            get { return _horsepower; }
            set
            {
                if (value.Equals(_horsepower)) { return; }
                _horsepower = value;
                OnPropertyChanged();
            }
        }

        public CarEditingViewModel Car { get; set; }

        public PitCrewViewModel PitCrew { get; set; }


        public List<DriverViewModel> Drivers { get; private set; }



        public List<byte> AvailableDriverNumbers
        {
            get
            {
                var list = new List<byte>();
                for (byte i = 1; i <= 40; i++)
                {
                    list.Add(i);
                }
                return list;
            }
        }
    }
}
