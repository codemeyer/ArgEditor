using System.Collections.Generic;
using System.Linq;
using ArgEditor.ViewModels;

namespace ArgEditor.Interactors
{
    public class DriverPerformanceCalculator
    {
        //public IList<DriverPerformanceItemViewModel> Calculate(MainViewModel viewModel)
        public IList<DriverPerformanceItemViewModel> Calculate(List<TeamViewModel> teams)
        {
            var originalDriverPerformanceList = new List<DriverPerformanceData>();

            foreach (var team in teams)
            {
                if (team.Drivers[0].Enabled)
                {
                    var driver = new DriverPerformanceData(team.Drivers[0], team.Horsepower);
                    originalDriverPerformanceList.Add(driver);
                }
                if (team.Drivers[1].Enabled)
                {
                    var driver = new DriverPerformanceData(team.Drivers[1], team.Horsepower);
                    originalDriverPerformanceList.Add(driver);
                }
            }

            var list = new List<DriverPerformanceItemViewModel>();

            foreach (var item in originalDriverPerformanceList)
            {
                list.Add(new DriverPerformanceItemViewModel
                {
                    DriverName = item.Name,
                    RelativePerformance = item.GetRelativePerformance(716, 1)
                });
            }

            var bestDriverViewModel = list.OrderBy(d => d.RelativePerformance).First();
            var bestDriver = originalDriverPerformanceList.Single(d => d.Name.Equals(bestDriverViewModel.DriverName));

            var updatedList = new List<DriverPerformanceItemViewModel>();

            foreach (var item in originalDriverPerformanceList)
            {
                updatedList.Add(new DriverPerformanceItemViewModel
                {
                    DriverName = item.Name,
                    RelativePerformance = item.GetRelativePerformance(bestDriver.Horsepower, bestDriver.GripLevel)
                });
            }

            return updatedList.OrderBy(d => d.RelativePerformance).ToList();
        }
    }

    public class DriverPerformanceData
    {
        public DriverPerformanceData(DriverViewModel driver, int horsepower)
        {
            Name = driver.Name;
            GripLevel = driver.RaceGripLevel;
            Horsepower = horsepower;
        }

        public string Name { get; set; }
        public int Horsepower { get; set; }
        public int GripLevel { get; set; }

        public double GetRelativePerformance(int baseHorsepower, int baseGripLevel)
        {
            double horsepower = (1 + ((baseHorsepower - Horsepower) * 0.0262) / 100);
            double grip = (1 + ((GripLevel - baseGripLevel) * 0.08895) / 100);

            var full = horsepower * grip;

            return full;
        }
    }
}
