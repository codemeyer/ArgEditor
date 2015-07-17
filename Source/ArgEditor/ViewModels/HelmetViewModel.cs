namespace ArgEditor.ViewModels
{
    public class HelmetViewModel : BaseViewModel
    {
        public HelmetViewModel(DriverViewModel parentDriverViewModel)
        {
            VisorSurroundColorIndex = 6;
            _parentDriverViewModel = parentDriverViewModel;
        }

        protected HelmetViewModel(byte[] colors)
        {
            VisorColorIndex = colors[0];
            VisorSurroundColorIndex = colors[6];
            Stripe1ColorIndex = colors[2];
            Stripe2ColorIndex = colors[3];
            Stripe3ColorIndex = colors[4];
            Stripe4ColorIndex = colors[5];
            Stripe5ColorIndex = colors[7];
            Stripe6ColorIndex = colors[8];
            Stripe7ColorIndex = colors[9];
            Stripe8ColorIndex = colors[10];
            Stripe9ColorIndex = colors[11];
            Stripe10ColorIndex = colors[12];
            Stripe11ColorIndex = colors[13];
            Stripe12ColorIndex = colors[14];
            Stripe13ColorIndex = colors[15];
        }


        private readonly DriverViewModel _parentDriverViewModel;

        public DriverViewModel Parent
        {
            get { return _parentDriverViewModel; }
        }


        private byte _visorColorIndex;

        public byte VisorColorIndex
        {
            get { return _visorColorIndex; }
            set
            {
                if (value.Equals(_visorColorIndex)) return;

                _visorColorIndex = value;
                OnPropertyChanged();
            }
        }


        private byte _visorSurroundColorIndex;

        public byte VisorSurroundColorIndex
        {
            get { return _visorSurroundColorIndex; }
            set
            {
                if (value.Equals(_visorSurroundColorIndex)) return;

                _visorSurroundColorIndex = value;
                OnPropertyChanged();
            }
        }


        private byte _stripe1ColorIndex;

        public byte Stripe1ColorIndex
        {
            get { return _stripe1ColorIndex; }
            set
            {
                if (value.Equals(_stripe1ColorIndex)) return;

                _stripe1ColorIndex = value;
                OnPropertyChanged();
            }
        }

        private byte _stripe2ColorIndex;

        public byte Stripe2ColorIndex
        {
            get { return _stripe2ColorIndex; }
            set
            {
                if (value.Equals(_stripe2ColorIndex)) return;

                _stripe2ColorIndex = value;
                OnPropertyChanged();
            }
        }

        private byte _stripe3ColorIndex;

        public byte Stripe3ColorIndex
        {
            get { return _stripe3ColorIndex; }
            set
            {
                if (value.Equals(_stripe3ColorIndex)) return;

                _stripe3ColorIndex = value;
                OnPropertyChanged();
            }
        }


        private byte _stripe4ColorIndex;

        public byte Stripe4ColorIndex
        {
            get { return _stripe4ColorIndex; }
            set
            {
                if (value.Equals(_stripe4ColorIndex)) return;

                _stripe4ColorIndex = value;
                OnPropertyChanged();
            }
        }


        private byte _stripe5ColorIndex;

        public byte Stripe5ColorIndex
        {
            get { return _stripe5ColorIndex; }
            set
            {
                if (value.Equals(_stripe5ColorIndex)) return;

                _stripe5ColorIndex = value;
                OnPropertyChanged();

                SetBottomStripesIfNeeded(value);
            }
        }


        private byte _stripe6ColorIndex;

        public byte Stripe6ColorIndex
        {
            get { return _stripe6ColorIndex; }
            set
            {
                if (value.Equals(_stripe6ColorIndex)) return;

                _stripe6ColorIndex = value;
                OnPropertyChanged();

                SetBottomStripesIfNeeded(value);
            }
        }


        private byte _stripe7ColorIndex;

        public byte Stripe7ColorIndex
        {
            get { return _stripe7ColorIndex; }
            set
            {
                if (value.Equals(_stripe7ColorIndex)) return;

                _stripe7ColorIndex = value;
                OnPropertyChanged();

                SetBottomStripesIfNeeded(value);
            }
        }


        private byte _stripe8ColorIndex;

        public byte Stripe8ColorIndex
        {
            get { return _stripe8ColorIndex; }
            set
            {
                if (value.Equals(_stripe8ColorIndex)) return;

                _stripe8ColorIndex = value;
                OnPropertyChanged();

                SetBottomStripesIfNeeded(value);
            }
        }


        private byte _stripe9ColorIndex;

        public byte Stripe9ColorIndex
        {
            get { return _stripe9ColorIndex; }
            set
            {
                if (value.Equals(_stripe9ColorIndex)) return;

                _stripe9ColorIndex = value;
                OnPropertyChanged();

                SetBottomStripesIfNeeded(value);
            }
        }


        private byte _stripe10ColorIndex;

        public byte Stripe10ColorIndex
        {
            get { return _stripe10ColorIndex; }
            set
            {
                if (value.Equals(_stripe10ColorIndex)) return;

                _stripe10ColorIndex = value;
                OnPropertyChanged();

                SetBottomStripesIfNeeded(value);
            }
        }


        private byte _stripe11ColorIndex;

        public byte Stripe11ColorIndex
        {
            get { return _stripe11ColorIndex; }
            set
            {
                if (value.Equals(_stripe11ColorIndex)) return;

                _stripe11ColorIndex = value;
                OnPropertyChanged();

                SetBottomStripesIfNeeded(value);
            }
        }


        private byte _stripe12ColorIndex;

        public byte Stripe12ColorIndex
        {
            get { return _stripe12ColorIndex; }
            set
            {
                if (value.Equals(_stripe12ColorIndex)) return;

                _stripe12ColorIndex = value;
                OnPropertyChanged();

                SetBottomStripesIfNeeded(value);
            }
        }


        private byte _stripe13ColorIndex;

        public byte Stripe13ColorIndex
        {
            get { return _stripe13ColorIndex; }
            set
            {
                if (value.Equals(_stripe13ColorIndex)) return;

                _stripe13ColorIndex = value;
                OnPropertyChanged();

                SetBottomStripesIfNeeded(value);
            }
        }


        private void SetBottomStripesIfNeeded(byte colorIndex)
        {
            if (_parentDriverViewModel.Number == 15)
            {
                Stripe5ColorIndex = colorIndex;
                Stripe6ColorIndex = colorIndex;
                Stripe7ColorIndex = colorIndex;
                Stripe8ColorIndex = colorIndex;
                Stripe9ColorIndex = colorIndex;
                Stripe10ColorIndex = colorIndex;
                Stripe11ColorIndex = colorIndex;
                Stripe12ColorIndex = colorIndex;
                Stripe13ColorIndex = colorIndex;
            }
        }
    }
}
