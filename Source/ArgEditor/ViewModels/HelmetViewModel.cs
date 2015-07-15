using System.Collections.ObjectModel;

namespace ArgEditor.ViewModels
{
    public class HelmetViewModel : BaseViewModel
    {
        // TODO: if this remains, it should be hidden
        public HelmetViewModel(byte[] colors)
        {
            VisorColorIndex = colors[0];
            VisorSurroundColorIndex = colors[6];
            StripeColorIndices = new ObservableCollection<byte>
            {
                colors[2],
                colors[3],
                colors[4],
                colors[5],
                colors[7],
                colors[8],
                colors[9],
                colors[10],
                colors[11],
                colors[12],
                colors[13],
                colors[14],
                colors[15],
            };
        }

        public HelmetViewModel()
        {
            StripeColorIndices = new ObservableCollection<byte>();
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



        // FUNKAR???

        private ObservableCollection<byte> _stripeColorIndices;

        public ObservableCollection<byte> StripeColorIndices
        {
            get { return _stripeColorIndices; }
            set
            {
                if (value.Equals(_stripeColorIndices)) return;

                _stripeColorIndices = value;
                OnPropertyChanged();
            }
        }
    }
}
