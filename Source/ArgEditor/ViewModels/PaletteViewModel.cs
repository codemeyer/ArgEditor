using System;
using System.Collections.ObjectModel;
using ArgEditor.UserControls;

namespace ArgEditor.ViewModels
{
    public class PaletteViewModel : BaseViewModel
    {
        private byte _selectedColor;
        private ObservableCollection<PaletteColorViewModel> _colors;
        private PaletteTool _activePaletteTool;

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
                OnPropertyChanged(nameof(SelectedColor));

                foreach (var color in _colors)
                {
                    color.IsSelected = (color.ColorIndex == _selectedColor);
                }
            }
        }

        public PaletteTool ActivePaletteTool
        {
            get { return _activePaletteTool; }
            set
            {
                IsPaletteToolFill = false;
                IsPaletteToolPickup = false;
                IsPaletteToolBrighter = false;
                IsPaletteToolDarker = false;
                _activePaletteTool = value;
                UpdatePaletteToolProps();
            }
        }

        private void UpdatePaletteToolProps()
        {
            switch (ActivePaletteTool)
            {
                case PaletteTool.Paint:
                    IsPaletteToolFill = true;
                    break;
                case PaletteTool.PickupColor:
                    IsPaletteToolPickup = true;
                    break;
                case PaletteTool.Darker:
                    IsPaletteToolDarker = true;
                    break;
                case PaletteTool.Brighter:
                    IsPaletteToolBrighter = true;
                    break;
            }
        }

        private bool _isPaletteToolFill;

        public bool IsPaletteToolFill
        {
            get { return _isPaletteToolFill; }
            set
            {
                if (value.Equals(_isPaletteToolFill)) return;

                _isPaletteToolFill = value;
                OnPropertyChanged(nameof(IsPaletteToolFill));
            }
        }

        private bool _isPaletteToolPickup;

        public bool IsPaletteToolPickup
        {
            get { return _isPaletteToolPickup; }
            set
            {
                if (value.Equals(_isPaletteToolPickup)) return;

                _isPaletteToolPickup = value;
                OnPropertyChanged(nameof(IsPaletteToolPickup));
            }
        }

        private bool _isPaletteToolDarker;

        public bool IsPaletteToolDarker
        {
            get { return _isPaletteToolDarker; }
            set
            {
                if (value.Equals(_isPaletteToolDarker)) return;

                _isPaletteToolDarker = value;
                OnPropertyChanged(nameof(IsPaletteToolDarker));
            }
        }

        private bool _isPaletteToolBrighter;

        public bool IsPaletteToolBrighter
        {
            get { return _isPaletteToolBrighter; }
            set
            {
                if (value.Equals(_isPaletteToolBrighter)) return;

                _isPaletteToolBrighter = value;
                OnPropertyChanged(nameof(IsPaletteToolBrighter));
            }
        }

    }
}
