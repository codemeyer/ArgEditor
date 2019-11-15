using System;
using System.Collections.Generic;
using System.Linq;
using ArgEditor.ViewModels;

namespace ArgEditor.Interactors
{
    public class DriverPerformanceCalculator
    {
        public IList<DriverPerformanceItemViewModel> Calculate(List<TeamViewModel> teams, PerformanceMetric metric, TrackTypeValue trackType)
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

            // new

            foreach (var item in originalDriverPerformanceList)
            {
                list.Add(new DriverPerformanceItemViewModel
                {
                    DriverName = item.Name,
                    Number = item.Number,
                    //RelativePerformance = item.GetRelativePerformance(716, 1),
                    LapTime = item.CalculateLapTime(trackType)
                });
            }

            var bestDriverViewModel = list.OrderBy(d => d.LapTime).FirstOrDefault();
            if (bestDriverViewModel == null)
            {
                return new List<DriverPerformanceItemViewModel>();
            }

            var bestDriver = originalDriverPerformanceList.First(d => d.Name.Equals(bestDriverViewModel.DriverName));
            // ?

            var updatedList = new List<DriverPerformanceItemViewModel>();

            foreach (var item in originalDriverPerformanceList)
            {
                var model = new DriverPerformanceItemViewModel
                {
                    DriverName = item.Name,
                    Number = item.Number,
                    IsCurrentlyBeingEdited =
                        (MainViewModelPasserArounder.MainViewModel?.IsEditingDriverIndex1 == item.Number ||
                         MainViewModelPasserArounder.MainViewModel?.IsEditingDriverIndex2 == item.Number) &&
                        MainViewModelPasserArounder.MainViewModel?.IsEditingDriverType == metric,
                    RelativePerformance = item.GetRelativePerformanceVsLapTime(bestDriver.CalculateLapTime(trackType), trackType)
                };

                if (model.IsCurrentlyBeingEdited)
                {
                }

                updatedList.Add(model);
            }

            var finalList = updatedList.OrderBy(d => d.RelativePerformance).ToList();

            foreach (var driver in finalList)
            {
                driver.Rank = finalList.IndexOf(driver) + 1;
            }




            // old

            //foreach (var item in originalDriverPerformanceList)
            //{
            //    list.Add(new DriverPerformanceItemViewModel
            //    {
            //        DriverName = item.Name,
            //        RelativePerformance = item.GetRelativePerformance(716, 1),
            //    });
            //}

            //var bestDriverViewModel = list.OrderBy(d => d.RelativePerformance).FirstOrDefault();
            //if (bestDriverViewModel == null)
            //{
            //    return new List<DriverPerformanceItemViewModel>();
            //}

            //var bestDriver = originalDriverPerformanceList.First(d => d.Name.Equals(bestDriverViewModel.DriverName));

            //var updatedList = new List<DriverPerformanceItemViewModel>();

            //foreach (var item in originalDriverPerformanceList)
            //{
            //    updatedList.Add(new DriverPerformanceItemViewModel
            //    {
            //        DriverName = item.Name,
            //        RelativePerformance = item.GetRelativePerformance(bestDriver.Horsepower, bestDriver.GripLevel),
            //    });
            //}

            //var finalList = updatedList.OrderBy(d => d.RelativePerformance).ToList();

            //foreach (var driver in finalList)
            //{
            //    driver.Rank = finalList.IndexOf(driver) + 1;
            //}

            return finalList;
        }
    }

    public class DriverPerformanceData
    {
        public DriverPerformanceData(DriverViewModel driver, int horsepower, PerformanceMetric metric)
        {
            Name = driver.Name;
            Number = driver.Number;
            GripLevel = (metric == PerformanceMetric.Race)
                ? driver.RaceGripLevel : driver.QualifyingGripLevel;
            Horsepower = horsepower;
        }

        public string Name { get; set; }
        public byte Number { get; set; }
        public int Horsepower { get; set; }
        public int GripLevel { get; set; }

        public double GetRelativePerformance(int baseHorsepower, int baseGripLevel)
        {
            double horsepower = (1 + ((baseHorsepower - Horsepower) * 0.0262) / 100);
            double grip = (1 + ((GripLevel - baseGripLevel) * 0.08895) / 100);

            var full = horsepower * grip;

            return full;
        }

        public double GetRelativePerformanceVsLapTime(double referenceLapTime, TrackTypeValue trackType)
        {
            var diff = CalculateLapTime(trackType) - referenceLapTime;

            return 1.0 + diff / referenceLapTime;
        }

        //  4   Monaco	      71.058   168,6
        //  1   UnitedStates  74.096   178,2   SLOW
        // 16   Australia     67.480   201,7
        // 10   Hungary       69.722   204,9
        //  5   Canada        73.640   216,6
        //  2   Brazil        70.138   222,0
        //  7   France        68.864   223,3
        //  6   Mexico        70.594   225,5
        // 13   Portugal      67.998   230,3   MED
        // 14   Spain         71.993   237,4
        // 15   Japan         87.623   240,7
        //  8   Great Britain 75.552   245,5
        //  3   San Marino    73.852   245,7
        // 11   Belgium       98.005   254,9
        //  9   Germany       88.242   277,5   FAST
        // 12   Italy         75.101   278,0

        public double CalculateLapTime(TrackTypeValue trackType)
        {
            int grip = 1;
            int skill = GripLevel;
            int bhp = Horsepower;

            //var grip = 1; //default
            //var skill = 1; // Senna
            //var bhp = 716;

            var handicap = -25 * grip + 4 * skill + 2500;

            // 8: 115912. - 42.3588 x + 0.0159304 x^2 - 24.3641 y + 0.00782616 y^2
            // x = bhp
            // y = handicap
            // 8: 115912. - 42.3588 bhp + 0.0159304 bhp^2 - 24.3641 handi + 0.00782616 handi^2

            //var bhp1 = 42.3588 * bhp;
            var bhp1 = GetBhpFactor1(trackType) * bhp;
            //var bhp2 = 0.0159304 * bhp * bhp;
            var bhp2 = GetBhpFactor2(trackType) * bhp * bhp;

            //var handi1 = 24.3641 * handicap;
            var handi1 = GetHandicapFactor1(trackType) * handicap;
            //var handi2 = 0.00782616 * handicap * handicap;
            var handi2 = GetHandicapFactor2(trackType) * handicap * handicap;

            //var time = 115912.0 - bhp1 + bhp2 - handi1 + handi2;
            var time = GetTrackFactor(trackType) - bhp1 + bhp2 - handi1 + handi2;

            return time;
        }


        private double GetTrackFactor(TrackTypeValue trackType)
        {
            // 13   MED  102085.0 − 37.2884·x + 0.0142299·x2 − 21.0229·y + 0.00697829·y2
            // 1    SLOW  99059.9 −  29.845·x + 0.0112486·x2 − 15.6459·y + 0.00603023·y2
            //  9   FAST 136416.0 − 67.6269·x + 0.0253316·x2 − 12.63·y   + 0.00453705·y2

            // Silverstone 115912.0

            switch (trackType)
            {
                case TrackTypeValue.Medium:
                    return 102085.0;
                case TrackTypeValue.Slow:
                    return 99059.9;
                case TrackTypeValue.Fast:
                    return 136416.0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(trackType), trackType, null);
            }
        }

        private double GetBhpFactor1(TrackTypeValue trackType)
        {
            // 13   MED  102085.0 − 37.2884·x + 0.0142299·x2 − 21.0229·y + 0.00697829·y2
            // 1    SLOW  99059.9 −  29.845·x + 0.0112486·x2 − 15.6459·y + 0.00603023·y2
            //  9   FAST 136416.0 − 67.6269·x + 0.0253316·x2 − 12.63·y   + 0.00453705·y2

            // Silverstone 42.3588

            switch (trackType)
            {
                case TrackTypeValue.Medium:
                    return 37.2884;
                case TrackTypeValue.Slow:
                    return 29.845;
                case TrackTypeValue.Fast:
                    return 67.6269;
                default:
                    throw new ArgumentOutOfRangeException(nameof(trackType), trackType, null);
            }
        }

        private double GetBhpFactor2(TrackTypeValue trackType)
        {
            // 13   MED  102085.0 − 37.2884·x + 0.0142299·x2 − 21.0229·y + 0.00697829·y2
            // 1    SLOW  99059.9 −  29.845·x + 0.0112486·x2 − 15.6459·y + 0.00603023·y2
            //  9   FAST 136416.0 − 67.6269·x + 0.0253316·x2 − 12.63·y   + 0.00453705·y2

            // Silverstone 0.0159304

            switch (trackType)
            {
                case TrackTypeValue.Medium:
                    return 0.0142299;
                case TrackTypeValue.Slow:
                    return 0.0112486;
                case TrackTypeValue.Fast:
                    return 0.0253316;
                default:
                    throw new ArgumentOutOfRangeException(nameof(trackType), trackType, null);
            }
        }

        private double GetHandicapFactor1(TrackTypeValue trackType)
        {
            // 13   MED  102085.0 − 37.2884·x + 0.0142299·x2 − 21.0229·y + 0.00697829·y2
            // 1    SLOW  99059.9 −  29.845·x + 0.0112486·x2 − 15.6459·y + 0.00603023·y2
            //  9   FAST 136416.0 − 67.6269·x + 0.0253316·x2 − 12.63·y   + 0.00453705·y2

            // Silverstone 24.3641

            switch (trackType)
            {
                case TrackTypeValue.Medium:
                    return 21.0229;
                case TrackTypeValue.Slow:
                    return 15.6459;
                case TrackTypeValue.Fast:
                    return 12.63;
                default:
                    throw new ArgumentOutOfRangeException(nameof(trackType), trackType, null);
            }
        }

        private double GetHandicapFactor2(TrackTypeValue trackType)
        {
            // 13   MED  102085.0 − 37.2884·x + 0.0142299·x2 − 21.0229·y + 0.00697829·y2
            // 1    SLOW  99059.9 −  29.845·x + 0.0112486·x2 − 15.6459·y + 0.00603023·y2
            //  9   FAST 136416.0 − 67.6269·x + 0.0253316·x2 − 12.63·y   + 0.00453705·y2

            // Silverstone 0.00782616

            switch (trackType)
            {
                case TrackTypeValue.Medium:
                    return 0.00697829;
                case TrackTypeValue.Slow:
                    return 0.00603023;
                case TrackTypeValue.Fast:
                    return 0.00453705;
                default:
                    throw new ArgumentOutOfRangeException(nameof(trackType), trackType, null);
            }
        }
    }
}
