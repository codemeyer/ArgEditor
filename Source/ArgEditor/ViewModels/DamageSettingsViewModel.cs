using System.ComponentModel;

namespace ArgEditor.ViewModels
{
    public class DamageSettingsViewModel : BaseViewModel, IDataErrorInfo
    {
        private short _retireAfterHittingWall = 7424;

        public short RetireAfterHittingWall
        {
            get { return _retireAfterHittingWall; }
            set { SetProperty(ref _retireAfterHittingWall, value, () => RetireAfterHittingWall); }
        }

        private short _retireAfterHittingOtherCar = 8192;

        public short RetireAfterHittingOtherCar
        {
            get { return _retireAfterHittingOtherCar; }
            set { SetProperty(ref _retireAfterHittingOtherCar, value, () => RetireAfterHittingOtherCar); }
        }

        private short _damageAfterHittingWall = 1792;

        public short DamageAfterHittingWall
        {
            get { return _damageAfterHittingWall; }
            set { SetProperty(ref _damageAfterHittingWall, value, () => DamageAfterHittingWall); }
        }

        private short _damageAfterHittingOtherCar = 1792;

        public short DamageAfterHittingOtherCar
        {
            get { return _damageAfterHittingOtherCar; }
            set { SetProperty(ref _damageAfterHittingOtherCar, value, () => DamageAfterHittingOtherCar); }
        }

        private byte _yellowFlagsAfterSeconds = 20;

        public byte YellowFlagsAfterSeconds
        {
            get { return _yellowFlagsAfterSeconds; }
            set { SetProperty(ref _yellowFlagsAfterSeconds, value, () => YellowFlagsAfterSeconds); }
        }

        private byte _removeCarsAfterSeconds = 15;

        public byte RemoveCarsAfterSeconds
        {
            get { return _removeCarsAfterSeconds; }
            set { SetProperty(ref _removeCarsAfterSeconds, value, () => RemoveCarsAfterSeconds); }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(RetireAfterHittingWall))
                {
                    if (RetireAfterHittingWall < 0 || RetireAfterHittingWall > 32767)
                    {
                        return "Value must be between 0 and 32767";
                    }
                }
                if (columnName == nameof(RetireAfterHittingOtherCar))
                {
                    if (RetireAfterHittingOtherCar < 0 || RetireAfterHittingOtherCar > 32767)
                    {
                        return "Value must be between 0 and 32767";
                    }
                }
                if (columnName == nameof(DamageAfterHittingWall))
                {
                    if (DamageAfterHittingWall < 0 || DamageAfterHittingWall > 32767)
                    {
                        return "Value must be between 0 and 32767";
                    }
                }
                if (columnName == nameof(DamageAfterHittingOtherCar))
                {
                    if (DamageAfterHittingOtherCar < 0 || DamageAfterHittingOtherCar > 32767)
                    {
                        return "Value must be between 0 and 32767";
                    }
                }
                if (columnName == nameof(YellowFlagsAfterSeconds))
                {
                    if (YellowFlagsAfterSeconds < 1 || YellowFlagsAfterSeconds > 60)
                    {
                        return "Value must be between 1 and 60";
                    }
                }
                if (columnName == nameof(RemoveCarsAfterSeconds))
                {
                    if (RemoveCarsAfterSeconds < 1 || RemoveCarsAfterSeconds > 60)
                    {
                        return "Value must be between 1 and 60";
                    }
                }

                return string.Empty;
            }
        }

        public string Error { get; }
    }
}
