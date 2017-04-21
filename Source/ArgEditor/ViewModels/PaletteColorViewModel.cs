using System.Windows.Input;
using System.Windows.Media;
using ArgEditor.Commands;

namespace ArgEditor.ViewModels
{
    public class PaletteColorViewModel : BaseViewModel
    {
        private Color _color;
        private byte _colorIndex;
        private bool _isSelected;

        public Color Color
        {
            get { return _color; }
            set
            {
                if (value.Equals(_color)) { return; }
                _color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        public byte ColorIndex
        {
            get { return _colorIndex; }
            set
            {
                if (value.Equals(_colorIndex)) { return; }
                _colorIndex = value;
                OnPropertyChanged(nameof(ColorIndex));
            }
        }

        public PaletteViewModel Parent { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value.Equals(_isSelected)) { return; }
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public ICommand SelectPaletteColorCommand { get; } = new SelectPaletteColorCommand();
    }
}
