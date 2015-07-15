using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ArgEditor.ViewModels
{
    public class CarEditingViewModel : INotifyPropertyChanged
    {
        // TODO: if this remains, it should be hidden
        public CarEditingViewModel(byte[] colors)
            : this()
        {
            EngineCoverColorIndex = colors[0];
            CockpitFrontColorIndex = colors[1];
            FrontWingEndplateColorIndex = colors[2];
            RearWingSideColorIndex = colors[3];
            NoseSideColorIndex = colors[4];
            SidepodColorIndex = colors[5];
            FrontAndRearWingColorIndex = colors[6];
            NoseTopColorIndex = colors[7];
            NoseAngleColorIndex = colors[8];
            CockpitSideColorIndex = colors[9];
            EngineCoverSideColorIndex = colors[10];
            EngineCoverRearColorIndex = colors[11];
            SidepodTopColorIndex = colors[12];
        }

        public CarEditingViewModel()
        {
            _opacity = 1.0;
        }

        private double _opacity;
        private bool _disabled;

        private byte _frontAndRearWingColorIndex;
        private byte _frontWingEndplateColorIndex;
        private byte _engineCoverColorIndex;
        private byte _rearWingSideColorIndex;
        private byte _cockpitFrontColorIndex;
        private byte _cockpitSideColorIndex;
        private byte _noseTopColorIndex;
        private byte _noseSideColorIndex;
        private byte _noseAngleColorIndex;
        private byte _sidepodTopColorIndex;
        private byte _sidepodColorIndex;
        private byte _engineCoverSideColorIndex;
        private byte _engineCoverRearColorIndex;

        public byte FrontAndRearWingColorIndex
        {
            get { return _frontAndRearWingColorIndex; }
            set
            {
                if (value.Equals(_frontAndRearWingColorIndex)) return;

                _frontAndRearWingColorIndex = value;
                OnPropertyChanged("FrontAndRearWingColorIndex");
            }
        }

        public byte FrontWingEndplateColorIndex
        {
            get { return _frontWingEndplateColorIndex; }
            set
            {
                if (value.Equals(_frontWingEndplateColorIndex)) return;

                _frontWingEndplateColorIndex = value;
                OnPropertyChanged("FrontWingEndplateColorIndex");
            }
        }

        public byte RearWingSideColorIndex
        {
            get { return _rearWingSideColorIndex; }
            set
            {
                if (value == _rearWingSideColorIndex) return;
                _rearWingSideColorIndex = value;
                OnPropertyChanged("RearWingSideColorIndex");
            }
        }

        public byte EngineCoverColorIndex
        {
            get { return _engineCoverColorIndex; }
            set
            {
                if (value == _engineCoverColorIndex) return;
                _engineCoverColorIndex = value;
                OnPropertyChanged("EngineCoverColorIndex");
            }
        }

        public byte CockpitFrontColorIndex
        {
            get { return _cockpitFrontColorIndex; }
            set
            {
                if (value == _cockpitFrontColorIndex) return;
                _cockpitFrontColorIndex = value;
                OnPropertyChanged("CockpitFrontColorIndex");
            }
        }

        public byte CockpitSideColorIndex
        {
            get { return _cockpitSideColorIndex; }
            set
            {
                if (value == _cockpitSideColorIndex) return;
                _cockpitSideColorIndex = value;
                OnPropertyChanged("CockpitSideColorIndex");
            }
        }

        public byte NoseTopColorIndex
        {
            get { return _noseTopColorIndex; }
            set
            {
                if (value == _noseTopColorIndex) return;
                _noseTopColorIndex = value;
                OnPropertyChanged("NoseTopColorIndex");
            }
        }

        public byte NoseSideColorIndex
        {
            get { return _noseSideColorIndex; }
            set
            {
                if (value == _noseSideColorIndex) return;
                _noseSideColorIndex = value;
                OnPropertyChanged("NoseSideColorIndex");
            }
        }

        public byte NoseAngleColorIndex
        {
            get { return _noseAngleColorIndex; }
            set
            {
                if (value == _noseAngleColorIndex) return;
                _noseAngleColorIndex = value;
                OnPropertyChanged("NoseAngleColorIndex");
            }
        }

        public byte SidepodTopColorIndex
        {
            get { return _sidepodTopColorIndex; }
            set
            {
                if (value == _sidepodTopColorIndex) return;
                _sidepodTopColorIndex = value;
                OnPropertyChanged("SidepodTopColorIndex");
            }
        }

        public byte SidepodColorIndex
        {
            get { return _sidepodColorIndex; }
            set
            {
                if (value == _sidepodColorIndex) return;
                _sidepodColorIndex = value;
                OnPropertyChanged("SidepodColorIndex");
            }
        }

        public byte EngineCoverSideColorIndex
        {
            get { return _engineCoverSideColorIndex; }
            set
            {
                if (value == _engineCoverSideColorIndex) return;
                _engineCoverSideColorIndex = value;
                OnPropertyChanged("EngineCoverSideColorIndex");
            }
        }

        public byte EngineCoverRearColorIndex
        {
            get { return _engineCoverRearColorIndex; }
            set
            {
                if (value == _engineCoverRearColorIndex) return;
                _engineCoverRearColorIndex = value;
                OnPropertyChanged("EngineCoverRearColorIndex");
            }
        }

        public bool Disabled
        {
            get { return _disabled; }
            set
            {
                if (value.Equals(_disabled)) return;

                _disabled = value;
                Opacity = (_disabled) ? 0.2 : 1.0;
            }
        }


        public double Opacity
        {
            get { return _opacity; }
            set
            {
                _opacity = value;
                OnPropertyChanged("Opacity");
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

    public class DesignerCarEditingViewModel : CarEditingViewModel
    {
        public DesignerCarEditingViewModel()
            : base(new byte[] { 78, 78, 78, 78, 78, 78, 78, 78, 78, 78, 78, 78, 78 })
        {
        }
    }




    public class ColorPropertyWrapper
    {
        private PropertyInfo _propertyInfo;

        public ColorPropertyWrapper(PropertyInfo propertyInfo)
        {
            _propertyInfo = propertyInfo;
        }

        public byte GetValue(object viewModel)
        {
            return (byte)_propertyInfo.GetValue(viewModel);
        }

        public void SetValue(object viewModel, byte value)
        {
            _propertyInfo.SetValue(viewModel, value, null);
        }
    }
}
