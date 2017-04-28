using System.ComponentModel;

namespace ArgEditor.ViewModels
{
    public class SetupViewModel : BaseViewModel, IDataErrorInfo
    {
        private byte _frontWing = 40;

        public byte FrontWing
        {
            get { return _frontWing; }
            set { SetProperty(ref _frontWing, value, () => FrontWing); }
        }

        private byte _rearWing = 40;

        public byte RearWing
        {
            get { return _rearWing; }
            set { SetProperty(ref _rearWing, value, () => RearWing); }
        }

        private sbyte _brakeBalance = 0;

        public sbyte BrakeBalance
        {
            get { return _brakeBalance; }
            set { SetProperty(ref _brakeBalance, value, () => BrakeBalance); }
        }

        private byte _gearRatio1 = 24;

        public byte GearRatio1
        {
            get { return _gearRatio1; }
            set { SetProperty(ref _gearRatio1, value, () => GearRatio1); }
        }

        private byte _gearRatio2 = 32;

        public byte GearRatio2
        {
            get { return _gearRatio2; }
            set { SetProperty(ref _gearRatio2, value, () => GearRatio2); }
        }

        private byte _gearRatio3 = 39;

        public byte GearRatio3
        {
            get { return _gearRatio3; }
            set { SetProperty(ref _gearRatio3, value, () => GearRatio3); }
        }

        private byte _gearRatio4 = 46;

        public byte GearRatio4
        {
            get { return _gearRatio4; }
            set { SetProperty(ref _gearRatio4, value, () => GearRatio4); }
        }

        private byte _gearRatio5 = 53;

        public byte GearRatio5
        {
            get { return _gearRatio5; }
            set { SetProperty(ref _gearRatio5, value, () => GearRatio5); }
        }

        private byte _gearRatio6 = 61;

        public byte GearRatio6
        {
            get { return _gearRatio6; }
            set { SetProperty(ref _gearRatio6, value, () => GearRatio6); }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(GearRatio1))
                {
                    if (GearRatio1 >= GearRatio2)
                        return "No";
                }

                if (columnName == nameof(GearRatio2))
                {
                    if (GearRatio2 < GearRatio1 + 1)
                        return "No";

                    if (GearRatio2 >= GearRatio3)
                        return "No";
                }

                if (columnName == nameof(GearRatio3))
                {
                    if (GearRatio3 < GearRatio2 + 1)
                        return "No";

                    if (GearRatio3 >= GearRatio4)
                        return "No";
                }

                if (columnName == nameof(GearRatio4))
                {
                    if (GearRatio4 < GearRatio3 + 1)
                        return "No";

                    if (GearRatio4 >= GearRatio5)
                        return "No";
                }

                if (columnName == nameof(GearRatio5))
                {
                    if (GearRatio5 < GearRatio4 + 1)
                        return "No";

                    if (GearRatio5 >= GearRatio6)
                        return "No";
                }

                if (columnName == nameof(GearRatio5))
                {
                    if (GearRatio6 < GearRatio5 + 1)
                        return "No";
                }

                // TODO: other ratios

                return string.Empty;
            }
        }

        public string Error { get; }
    }
}
