using System.ComponentModel;
using System.Windows.Media;

namespace ArgEditor.ViewModels
{
    public class PaletteColorViewModel : INotifyPropertyChanged
    {
        private Color _color;
        private bool _isSelected;
        private byte _colorIndex;

        public Color Color
        {
            get { return _color; }
            set
            {
                if (value.Equals(_color)) { return; }
                _color = value;
                OnPropertyChanged("Color");
            }
        }

        public byte ColorIndex
        {
            get { return _colorIndex; }
            set
            {
                if (value.Equals(_colorIndex)) { return; }
                _colorIndex = value;
                OnPropertyChanged("ColorIndex");
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value.Equals(_isSelected)) { return; }
                _isSelected = value;
                OnPropertyChanged("IsSelected");
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
}
