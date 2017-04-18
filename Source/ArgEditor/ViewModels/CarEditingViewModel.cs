namespace ArgEditor.ViewModels
{
    public class CarEditingViewModel : BaseViewModel
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
        }

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
        private bool _isSpecialShape;

        public byte FrontAndRearWingColorIndex
        {
            get { return _frontAndRearWingColorIndex; }
            set
            {
                if (value.Equals(_frontAndRearWingColorIndex)) return;

                _frontAndRearWingColorIndex = value;
                OnPropertyChanged(nameof(FrontAndRearWingColorIndex));
            }
        }

        public byte FrontWingEndplateColorIndex
        {
            get { return _frontWingEndplateColorIndex; }
            set
            {
                if (value.Equals(_frontWingEndplateColorIndex)) return;

                _frontWingEndplateColorIndex = value;
                OnPropertyChanged(nameof(FrontWingEndplateColorIndex));
            }
        }

        public byte RearWingSideColorIndex
        {
            get { return _rearWingSideColorIndex; }
            set
            {
                if (value == _rearWingSideColorIndex) return;
                _rearWingSideColorIndex = value;
                OnPropertyChanged(nameof(RearWingSideColorIndex));
            }
        }

        public byte EngineCoverColorIndex
        {
            get { return _engineCoverColorIndex; }
            set
            {
                if (value == _engineCoverColorIndex) return;
                _engineCoverColorIndex = value;
                OnPropertyChanged(nameof(EngineCoverColorIndex));
            }
        }

        public byte CockpitFrontColorIndex
        {
            get { return _cockpitFrontColorIndex; }
            set
            {
                if (value == _cockpitFrontColorIndex) return;
                _cockpitFrontColorIndex = value;
                OnPropertyChanged(nameof(CockpitFrontColorIndex));
            }
        }

        public byte CockpitSideColorIndex
        {
            get { return _cockpitSideColorIndex; }
            set
            {
                if (value == _cockpitSideColorIndex) return;
                _cockpitSideColorIndex = value;
                OnPropertyChanged(nameof(CockpitSideColorIndex));
            }
        }

        public byte NoseTopColorIndex
        {
            get { return _noseTopColorIndex; }
            set
            {
                if (value == _noseTopColorIndex) return;
                _noseTopColorIndex = value;
                OnPropertyChanged(nameof(NoseTopColorIndex));

                if (IsSpecialShape)
                {
                    NoseAngleColorIndex = value;
                }
            }
        }

        public byte NoseSideColorIndex
        {
            get { return _noseSideColorIndex; }
            set
            {
                if (value == _noseSideColorIndex) return;
                _noseSideColorIndex = value;
                OnPropertyChanged(nameof(NoseSideColorIndex));
            }
        }

        public byte NoseAngleColorIndex
        {
            get { return _noseAngleColorIndex; }
            set
            {
                if (value == _noseAngleColorIndex) return;
                _noseAngleColorIndex = value;
                OnPropertyChanged(nameof(NoseAngleColorIndex));
            }
        }

        public byte SidepodTopColorIndex
        {
            get { return _sidepodTopColorIndex; }
            set
            {
                if (value == _sidepodTopColorIndex) return;
                _sidepodTopColorIndex = value;
                OnPropertyChanged(nameof(SidepodTopColorIndex));
            }
        }

        public byte SidepodColorIndex
        {
            get { return _sidepodColorIndex; }
            set
            {
                if (value == _sidepodColorIndex) return;
                _sidepodColorIndex = value;
                OnPropertyChanged(nameof(SidepodColorIndex));
            }
        }

        public byte EngineCoverSideColorIndex
        {
            get { return _engineCoverSideColorIndex; }
            set
            {
                if (value == _engineCoverSideColorIndex) return;
                _engineCoverSideColorIndex = value;
                OnPropertyChanged(nameof(EngineCoverSideColorIndex));
            }
        }

        public byte EngineCoverRearColorIndex
        {
            get { return _engineCoverRearColorIndex; }
            set
            {
                if (value == _engineCoverRearColorIndex) return;
                _engineCoverRearColorIndex = value;
                OnPropertyChanged(nameof(EngineCoverRearColorIndex));
            }
        }

        public bool IsSpecialShape
        {
            get { return _isSpecialShape; }
            set
            {
                _isSpecialShape = value;
                OnPropertyChanged(nameof(IsSpecialShape));
            }
        }
        public bool IsRegularShape
        {
            get { return !_isSpecialShape; }
        }
    }
}
