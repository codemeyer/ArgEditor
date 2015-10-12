using System.Collections.Generic;
using System.Linq;
using ArgEditor.ViewModels;

namespace ArgEditor.Interactors
{
    public class DriverPerformanceCalculator
    {
        public IList<DriverPerformanceItemViewModel> Calculate(List<TeamViewModel> teams, PerformanceMetric metric)
        {
            var originalDriverPerformanceList = new List<DriverPerformanceData>();

            foreach (var team in teams)
            {
                if (team.Drivers[0].Enabled && team.Drivers[0].Name.Trim().Length > 0)
                {
                    var driver = new DriverPerformanceData(team.Drivers[0], team.Horsepower, metric);
                    originalDriverPerformanceList.Add(driver);
                }
                if (team.Drivers[1].Enabled && team.Drivers[1].Name.Trim().Length > 0)
                {
                    var driver = new DriverPerformanceData(team.Drivers[1], team.Horsepower, metric);
                    originalDriverPerformanceList.Add(driver);
                }
            }

            var list = new List<DriverPerformanceItemViewModel>();

            foreach (var item in originalDriverPerformanceList)
            {
                list.Add(new DriverPerformanceItemViewModel
                {
                    DriverName = item.Name,
                    RelativePerformance = item.GetRelativePerformance(716, 1),
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
                    RelativePerformance = item.GetRelativePerformance(bestDriver.Horsepower, bestDriver.GripLevel),
                });
            }

            var finalList = updatedList.OrderBy(d => d.RelativePerformance).ToList();

            foreach (var driver in finalList)
            {
                driver.Rank = finalList.IndexOf(driver) + 1;
            }

            return finalList;
        }
    }

    public class DriverPerformanceData
    {
        public DriverPerformanceData(DriverViewModel driver, int horsepower, PerformanceMetric metric)
        {
            Name = driver.Name;
            GripLevel = (metric == PerformanceMetric.Race)
                ? driver.RaceGripLevel : driver.QualifyingGripLevel;
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
