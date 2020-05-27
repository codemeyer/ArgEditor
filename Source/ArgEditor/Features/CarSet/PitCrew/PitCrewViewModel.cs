using System.Windows.Media;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.PitCrew
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
                OnPropertyChanged(nameof(ShirtPrimaryColorIndex));
            }
        }

        public byte ShirtSecondaryColorIndex
        {
            get { return _shirtSecondaryColorIndex; }
            set
            {
                if (value.Equals(_shirtSecondaryColorIndex)) return;

                _shirtSecondaryColorIndex = value;
                OnPropertyChanged(nameof(ShirtSecondaryColorIndex));
            }
        }

        public byte PantsPrimaryColorIndex
        {
            get { return _pantsPrimaryColorIndex; }
            set
            {
                if (value.Equals(_pantsPrimaryColorIndex)) return;

                _pantsPrimaryColorIndex = value;
                OnPropertyChanged(nameof(PantsPrimaryColorIndex));
            }
        }

        public byte PantsSecondaryColorIndex
        {
            get { return _pantsSecondaryColorIndex; }
            set
            {
                if (value.Equals(_pantsSecondaryColorIndex)) return;

                _pantsSecondaryColorIndex = value;
                OnPropertyChanged(nameof(PantsSecondaryColorIndex));
            }
        }

        public byte SocksColorIndex
        {
            get { return _socksColorIndex; }
            set
            {
                if (value.Equals(_socksColorIndex)) return;

                _socksColorIndex = value;
                OnPropertyChanged(nameof(SocksColorIndex));
            }
        }



        // only used in Browse window

        private Brush _backgroundColor;

        public Brush BackgroundColor
        {
            get { return _backgroundColor; }
            set { SetProperty(ref _backgroundColor, value, () => BackgroundColor); }
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
