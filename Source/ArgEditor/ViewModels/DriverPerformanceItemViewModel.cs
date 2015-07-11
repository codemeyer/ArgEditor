using System;
using System.Globalization;

namespace ArgEditor.ViewModels
{
    public class DriverPerformanceItemViewModel
    {
        public string DriverName { get; set; }
        public double RelativePerformance { get; set; }

        public string RelativePerformanceText
        {
            get
            {
                if (RelativePerformance.Equals(1.0))
                    return "";
                else
                {
                    var extracted = (RelativePerformance * 100) - 100;

                    // TODO: always two decimals
                    var ci = new CultureInfo("en-US");
                    return "+" + Math.Round(extracted, 2).ToString(ci) + "%";
                }
            }
        }
    }
}
