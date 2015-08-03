using System.Linq;
using System.Windows;

namespace ArgEditor.ViewModels
{
    public class DriverViewModel : BaseViewModel
    {
        private byte _number;
        private string _name;
        private byte _raceGripLevel;
        private byte _qualifyingGripLevel;
        private bool _enabled;

        public DriverViewModel(byte number, string name, byte raceGripLevel, byte qualifyingGripLevel)
        {
            Number = number;
            Name = name;
            RaceGripLevel = raceGripLevel;
            QualifyingGripLevel = qualifyingGripLevel;

            Helmet = new HelmetViewModel(this);
        }

        public byte Number
        {
            get { return _number; }
            set
            {
                if (value.Equals(_number)) { return; }
                _number = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Equals(_name)) { return; }
                _name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShortName));

                Enabled = !string.IsNullOrEmpty(_name);
            }
        }

        public string ShortName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_name)) { return string.Empty; }

                var nameParts = _name.Split(' ');
                if (nameParts.Length == 1)
                    return _name;

                var namio = nameParts[0].Substring(0, 1) + ". " + string.Join(" ", nameParts.Skip(1));

                return namio;
            }
        }

        public byte RaceGripLevel
        {
            get { return _raceGripLevel; }
            set
            {
                if (value.Equals(_raceGripLevel)) { return; }
                _raceGripLevel = value;
                OnPropertyChanged();
            }
        }

        public byte QualifyingGripLevel
        {
            get { return _qualifyingGripLevel; }
            set
            {
                if (value.Equals(_qualifyingGripLevel)) { return; }
                _qualifyingGripLevel = value;
                OnPropertyChanged();
            }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (value.Equals(_enabled)) return;
                _enabled = value;
                OnPropertyChanged();
                OnPropertyChanged("Visibility");    // hacky
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

        public HelmetViewModel Helmet { get; set; }

        public TeamViewModel Team { get; set; }
    }
}
