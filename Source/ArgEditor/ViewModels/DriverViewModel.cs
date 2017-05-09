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
                OnPropertyChanged(nameof(Number));

                DisplayNumber = value > 0 ? $"#{value}" : "";

                UpdateEnabledFlag();
                UpdateHelmetWarningFlag();
                UpdateHelmetInactiveDriverWarningFlag();
            }
        }


        private string _displayNumber;

        public string DisplayNumber
        {
            get { return _displayNumber; }
            set { SetProperty(ref _displayNumber, value, () => DisplayNumber); }
        }

        private void UpdateHelmetWarningFlag()
        {
            Helmet?.UpdateSpecialHelmetWarningFlag();
        }

        private void UpdateHelmetInactiveDriverWarningFlag()
        {
            Helmet?.UpdateHelmetInactiveDriverWarningFlag();
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Equals(_name)) { return; }
                _name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(ShortName));
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
                OnPropertyChanged(nameof(RaceGripLevel));
            }
        }

        public byte QualifyingGripLevel
        {
            get { return _qualifyingGripLevel; }
            set
            {
                if (value.Equals(_qualifyingGripLevel)) { return; }
                _qualifyingGripLevel = value;
                OnPropertyChanged(nameof(QualifyingGripLevel));
            }
        }


        private void UpdateEnabledFlag()
        {
            Enabled = Number > 0;
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (value.Equals(_enabled)) return;
                _enabled = value;
                OnPropertyChanged(nameof(Enabled));
                OnPropertyChanged(nameof(Visibility));    // hacky

                Team?.UpdateEnabledFlag();
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



        private bool _hasSameNumberAsOtherDriver;

        public bool HasSameNumberAsOtherDriver
        {
            get { return _hasSameNumberAsOtherDriver; }
            set
            {
                if (value.Equals(_hasSameNumberAsOtherDriver)) return;
                _hasSameNumberAsOtherDriver = value;
                OnPropertyChanged(nameof(HasSameNumberAsOtherDriver));
            }
        }


        private bool _hasNumberWithoutName;

        public bool HasNumberWithoutName
        {
            get { return _hasNumberWithoutName; }
            set { SetProperty(ref _hasNumberWithoutName, value, () => HasNumberWithoutName); }
        }

    }
}
