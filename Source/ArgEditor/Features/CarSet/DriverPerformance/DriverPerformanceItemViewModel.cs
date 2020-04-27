using System;
using System.Globalization;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.DriverPerformance
{
    public class DriverPerformanceItemViewModel : BaseViewModel
    {
        public string DriverName { get; set; }
        public double RelativePerformance { get; set; }


        //private short _retireAfterHittingOtherCar = 8192;

        //public short RetireAfterHittingOtherCar
        //{
        //    get { return _retireAfterHittingOtherCar; }
        //    set { SetProperty(ref _retireAfterHittingOtherCar, value, () => RetireAfterHittingOtherCar); }
        //}


        private bool _isCurrentlyBeingEdited;

        public bool IsCurrentlyBeingEdited
        {
            get { return _isCurrentlyBeingEdited; }
            set { SetProperty(ref _isCurrentlyBeingEdited, value, () => IsCurrentlyBeingEdited); }
        }

        public byte Number { get; set; }

        public double LapTime { get; set; }

        public string RelativePerformanceText
        {
            get
            {
                if (RelativePerformance.Equals(1.0))
                    return "";
                else
                {
                    var extracted = (RelativePerformance * 100) - 100;

                    var ci = new CultureInfo("en-US");
                    var value = string.Format(ci, "{0:F}", Math.Round(extracted, 2));
                    return "+" + value + "%";
                }
            }
        }

        public int Rank { get; set; }
    }
}
