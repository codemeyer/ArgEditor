using System;
using System.Collections.ObjectModel;

namespace ArgEditor.ViewModels
{
    public class PaletteViewModel : BaseViewModel
    {
        private byte _selectedColor;
        private ObservableCollection<PaletteColorViewModel> _colors;

        public PaletteViewModel()
        {
            _colors = new ObservableCollection<PaletteColorViewModel>();

            for (int i = 0; i <= 255; i++)
            {
                _colors.Add(
                    new PaletteColorViewModel
                    {
                        Color = PaletteHelper.GetColor(i),
                        ColorIndex = Convert.ToByte(i)
                    });
            }

            _colors[0].IsSelected = true;
        }

        public ObservableCollection<PaletteColorViewModel> Colors
        {
            get { return _colors; }
            private set { _colors = value; }
        }

        public byte SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                if (value.Equals(_selectedColor)) { return; }
                _selectedColor = value;
                OnPropertyChanged();

                foreach (var color in _colors)
                {
                    color.IsSelected = (color.ColorIndex == _selectedColor);
                }
            }
        }
    }
}
