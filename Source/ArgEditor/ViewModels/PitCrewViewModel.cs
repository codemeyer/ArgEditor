using System.ComponentModel;

namespace ArgEditor.ViewModels
{
    public class PitCrewViewModel : INotifyPropertyChanged
    {
        // TODO: if this remains, it should be hidden
        public PitCrewViewModel(byte[] colors)
        {
            ShirtPrimaryColorIndex = colors[0];
            ShirtSecondaryColorIndex = colors[1];
            PantsPrimaryColorIndex = colors[2];
            PantsSecondaryColorIndex = colors[3];
            SocksColorIndex = colors[4];
        }

        public PitCrewViewModel()
        {
        }

        private byte _shirtPrimaryColorIndex;
        private byte _shirtSecondaryColorIndex;
        private byte _pantsPrimaryColorIndex;
        private byte _pantsSecondaryColorIndex;
        private byte _socksColorIndex;

        public byte ShirtPrimaryColorIndex
        {
            get { return _shirtPrimaryColorIndex; }
            set
            {
                if (value.Equals(_shirtPrimaryColorIndex)) return;

                _shirtPrimaryColorIndex = value;
                OnPropertyChanged("ShirtPrimaryColorIndex");
            }
        }

        public byte ShirtSecondaryColorIndex
        {
            get { return _shirtSecondaryColorIndex; }
            set
            {
                if (value.Equals(_shirtSecondaryColorIndex)) return;

                _shirtSecondaryColorIndex = value;
                OnPropertyChanged("ShirtSecondaryColorIndex");
            }
        }

        public byte PantsPrimaryColorIndex
        {
            get { return _pantsPrimaryColorIndex; }
            set
            {
                if (value.Equals(_pantsPrimaryColorIndex)) return;

                _pantsPrimaryColorIndex = value;
                OnPropertyChanged("PantsPrimaryColorIndex");
            }
        }

        public byte PantsSecondaryColorIndex
        {
            get { return _pantsSecondaryColorIndex; }
            set
            {
                if (value.Equals(_pantsSecondaryColorIndex)) return;

                _pantsSecondaryColorIndex = value;
                OnPropertyChanged("PantsSecondaryColorIndex");
            }
        }

        public byte SocksColorIndex
        {
            get { return _socksColorIndex; }
            set
            {
                if (value.Equals(_socksColorIndex)) return;

                _socksColorIndex = value;
                OnPropertyChanged("SocksColorIndex");
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

    public class DesignerPitCrewViewModel : PitCrewViewModel
    {
        public DesignerPitCrewViewModel()
            : base(new byte[] { 72, 68, 58, 56, 38 })
        {
        }
    }
}
