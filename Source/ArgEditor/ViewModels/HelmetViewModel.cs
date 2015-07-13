using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ArgEditor.ViewModels
{
    public class HelmetViewModel : INotifyPropertyChanged
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
                OnPropertyChanged("VisorColorIndex");
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
                OnPropertyChanged("VisorSurroundColorIndex");
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
                OnPropertyChanged("StripeColorIndices");
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


    public class DesignerHelmetViewModel : HelmetViewModel
    {
        public DesignerHelmetViewModel()
            : base(new byte[] { 0, 1, 111, 111, 111, 111, 6, 79, 79, 111, 111, 95, 111, 111, 111, 111 })
        {
        }
    }
}
