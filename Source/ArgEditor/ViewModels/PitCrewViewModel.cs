namespace ArgEditor.ViewModels
{
    public class PitCrewViewModel : BaseViewModel
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
                OnPropertyChanged();
            }
        }

        public byte ShirtSecondaryColorIndex
        {
            get { return _shirtSecondaryColorIndex; }
            set
            {
                if (value.Equals(_shirtSecondaryColorIndex)) return;

                _shirtSecondaryColorIndex = value;
                OnPropertyChanged();
            }
        }

        public byte PantsPrimaryColorIndex
        {
            get { return _pantsPrimaryColorIndex; }
            set
            {
                if (value.Equals(_pantsPrimaryColorIndex)) return;

                _pantsPrimaryColorIndex = value;
                OnPropertyChanged();
            }
        }

        public byte PantsSecondaryColorIndex
        {
            get { return _pantsSecondaryColorIndex; }
            set
            {
                if (value.Equals(_pantsSecondaryColorIndex)) return;

                _pantsSecondaryColorIndex = value;
                OnPropertyChanged();
            }
        }

        public byte SocksColorIndex
        {
            get { return _socksColorIndex; }
            set
            {
                if (value.Equals(_socksColorIndex)) return;

                _socksColorIndex = value;
                OnPropertyChanged();
            }
        }
    }
}
