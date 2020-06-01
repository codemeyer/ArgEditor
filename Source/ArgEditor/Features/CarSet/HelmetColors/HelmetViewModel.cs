using System.Linq;
using System.Windows;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.HelmetColors
{
    public class HelmetViewModel : BaseViewModel
    {
        public HelmetViewModel(DriverViewModel parentDriverViewModel)
        {
            Parent = parentDriverViewModel;
            VisorColorIndex = 0;
            VisorSurroundColorIndex = 6;
            Stripe1ColorIndex = 8;
            Stripe2ColorIndex = 8;
            Stripe3ColorIndex = 8;
            Stripe4ColorIndex = 8;
            Stripe5ColorIndex = 8;
            Stripe6ColorIndex = 8;
            Stripe7ColorIndex = 8;
            Stripe8ColorIndex = 8;
            Stripe9ColorIndex = 8;
            Stripe10ColorIndex = 8;
            Stripe11ColorIndex = 8;
            Stripe12ColorIndex = 8;
            Stripe13ColorIndex = 8;
            
            UpdateSpecialHelmetWarningFlag();
            UpdateHelmetInactiveDriverWarningFlag();
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


        public DriverViewModel Parent { get; }


        private byte _visorColorIndex;

        public byte VisorColorIndex
        {
            get { return _visorColorIndex; }
            set
            {
                if (value.Equals(_visorColorIndex)) return;

                _visorColorIndex = value;
                OnPropertyChanged(nameof(VisorColorIndex));
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
                OnPropertyChanged(nameof(VisorSurroundColorIndex));
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
                OnPropertyChanged(nameof(Stripe1ColorIndex));
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
                OnPropertyChanged(nameof(Stripe2ColorIndex));
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
                OnPropertyChanged(nameof(Stripe3ColorIndex));
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
                OnPropertyChanged(nameof(Stripe4ColorIndex));
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
                OnPropertyChanged(nameof(Stripe5ColorIndex));
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
                OnPropertyChanged(nameof(Stripe6ColorIndex));
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
                OnPropertyChanged(nameof(Stripe7ColorIndex));
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
                OnPropertyChanged(nameof(Stripe8ColorIndex));
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
                OnPropertyChanged(nameof(Stripe9ColorIndex));
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
                OnPropertyChanged(nameof(Stripe10ColorIndex));
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
                OnPropertyChanged(nameof(Stripe11ColorIndex));
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
                OnPropertyChanged(nameof(Stripe12ColorIndex));
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
                OnPropertyChanged(nameof(Stripe13ColorIndex));
            }
        }



        private Visibility _showDecompressedExeMessage;

        public Visibility ShowDecompressedExeMessage
        {
            get { return _showDecompressedExeMessage; }
            set
            {
                if (value.Equals(_showDecompressedExeMessage)) return;
                _showDecompressedExeMessage = value;
                OnPropertyChanged(nameof(ShowDecompressedExeMessage));
            }
        }


        private Visibility _showInactiveDriverMessage;

        public Visibility ShowInactiveDriverMessage
        {
            get { return _showInactiveDriverMessage; }
            set { SetProperty(ref _showInactiveDriverMessage, value, () => ShowInactiveDriverMessage); }
        }


        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value, () => IsSelected); }
        }



        public void UpdateSpecialHelmetWarningFlag()
        {
            if (Parent == null)
                return;

            ShowDecompressedExeMessage = _specialHelmetNumbers.Contains(Parent.Number)
                ? Visibility.Visible : Visibility.Hidden;
        }

        public void UpdateHelmetInactiveDriverWarningFlag()
        {
            if (Parent == null)
                return;

            ShowInactiveDriverMessage = Parent.Number > 0 ? Visibility.Hidden : Visibility.Visible;
        }



        private readonly byte[] _specialHelmetNumbers = { 13, 15, 36, 37, 38, 39, 40 };
    }

    public class DesignerHelmetViewModel : HelmetViewModel
    {
        public DesignerHelmetViewModel()
            : base(new byte[] { 0, 1, 111, 111, 111, 111, 6, 79, 79, 111, 111, 95, 111, 111, 111, 111 })
        {
        }
    }
}
