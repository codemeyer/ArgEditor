using System.Collections.Generic;
using System.Windows;

namespace ArgEditor.ViewModels
{
    public class TeamViewModel : BaseViewModel
    {
        private string _name;
        private string _engine;
        private int _horsepower;
        private bool _enabled;

        public TeamViewModel()
        {
            Drivers = new List<DriverViewModel>();
            Car = new CarEditingViewModel();
            Enabled = true;
        }

        public TeamViewModel(int index, string name, string engine, DriverViewModel driver1, DriverViewModel driver2)
        {
            Index = index;
            Name = name;
            Engine = engine;

            Drivers = new List<DriverViewModel>();
            Drivers.Add(driver1);
            Drivers.Add(driver2);

            Car = new CarEditingViewModel();
            PitCrew = new PitCrewViewModel();

            Enabled = false;
        }

        public int Index { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Equals(_name)) { return; }
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Engine
        {
            get { return _engine; }
            set
            {
                if (value.Equals(_engine)) { return; }
                _engine = value;
                OnPropertyChanged(nameof(Engine));
            }
        }

        public int Horsepower
        {
            get { return _horsepower; }
            set
            {
                if (value.Equals(_horsepower)) { return; }
                _horsepower = value;
                OnPropertyChanged(nameof(Horsepower));
            }
        }


        public void UpdateEnabledFlag()
        {
            if (Drivers == null)
                Enabled = false;

            Enabled = Drivers[0].Number > 0 || Drivers[1].Number > 0;
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                OnPropertyChanged(nameof(Enabled));
                OnPropertyChanged(nameof(Visibility));    // hacky
            }
        }

        public Visibility Visibility
        {
            get
            {
                if (_enabled)
                    return Visibility.Visible;
                else
                {
                    return Visibility.Hidden;
                }
            }
        }

        public CarEditingViewModel Car { get; set; }

        public PitCrewViewModel PitCrew { get; set; }

        public List<DriverViewModel> Drivers { get; private set; }


        public List<DriverNumber> AvailableDriverNumbers
        {
            get
            {
                var list = new List<DriverNumber>();

                list.Add(new DriverNumber(0, ""));

                for (byte i = 1; i <= 40; i++)
                {
                    list.Add(new DriverNumber(i, i.ToString()));
                }
                return list;

            }
        }
    }

    public class DriverNumber
    {
        public DriverNumber(byte value, string displayValue)
        {
            Value = value;
            DisplayValue = displayValue;
        }

        public byte Value { get; set; }
        public string DisplayValue { get; set; }
    }
}
