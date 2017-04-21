using System;
using System.IO;
using System.Linq;
using ArgData.Entities;
using ArgEditor.Mappers;
using ArgEditor.ViewModels;

namespace ArgEditor.Interactors.LegacyCarSets
{
    public static class LegacyCarSetLoader
    {
        public static LegacyCarSet Load(string path)
        {
            var carset = new LegacyCarSet();

            var lines = File.ReadAllLines(path);

            int teamsStartLine = FindLineMatching(lines, "[Teams]");

            for (int i = teamsStartLine; i <= teamsStartLine + ArgEditorConstants.TeamCountSupported; i++)
            {
                var teamData = lines[i];

                var team = new LegacyTeam
                {
                    Index = Convert.ToInt32(teamData.Split('=')[0])
                };

                if (team.Index > ArgEditorConstants.TeamCountSupported)
                    continue;

                var mainData = teamData.Split('=')[1].Split(',');
                team.Name = mainData[0];
                team.Engine = mainData[1];
                team.Horsepower = Convert.ToInt32(mainData[2]);
                team.Driver1Number = Convert.ToInt32(mainData[3]);
                team.Driver2Number = Convert.ToInt32(mainData[4]);

                carset.Teams.Add(team);
            }


            int carColorsStartLine = FindLineMatching(lines, "[CarColours]");

            for (int i = carColorsStartLine; i <= carColorsStartLine + ArgEditorConstants.TeamCountSupported; i++)
            {
                var colorData = lines[i];

                var index = Convert.ToInt32(colorData.Split('=')[0]);

                if (index > ArgEditorConstants.TeamCountSupported)
                    continue;

                var team = carset.Teams.FirstOrDefault(t => t.Index == index);

                var mainData = colorData.Split('=')[1].Split(',');
                var bytes = mainData.Select(byte.Parse).ToArray();

                team.CarColors = bytes;
            }

            // TODO: above and below, very similar...

            int pitCrewColorsStartLine = FindLineMatching(lines, "[PitColours]");

            for (int i = pitCrewColorsStartLine;
                i <= pitCrewColorsStartLine + ArgEditorConstants.TeamCountSupported;
                i++)
            {
                var colorData = lines[i];

                var index = Convert.ToInt32(colorData.Split('=')[0]);

                if (index > ArgEditorConstants.TeamCountSupported)
                    continue;

                var team = carset.Teams.FirstOrDefault(t => t.Index == index);

                var mainData = colorData.Split('=')[1].Split(',');
                var bytes = mainData.Select(byte.Parse).ToArray();

                team.PitCrewColors = bytes;
            }

            int driversStartLine = FindLineMatching(lines, "[Drivers]");

            for (int i = driversStartLine; i < driversStartLine + ArgEditorConstants.DriverNumberMax; i++)
            {
                var driverData = lines[i];

                var driver = new LegacyDriver
                {
                    Number = Convert.ToInt32(driverData.Split('=')[0])
                };

                if (driver.Number > ArgEditorConstants.DriverNumberMax)
                    continue;

                var mainData = driverData.Split('=')[1].Split(',');
                driver.Name = mainData[0];
                driver.QualifyingPerformance = Convert.ToInt32(mainData[1]);
                driver.RacePerformance = Convert.ToInt32(mainData[2]);

                carset.Drivers.Add(driver);
            }

            int helmetColorsStartLine = FindLineMatching(lines, "[HelmetColours]");


            for (int i = helmetColorsStartLine;
                i < helmetColorsStartLine + ArgEditorConstants.DriverNumberMax;
                i++)
            {
                var colorData = lines[i];

                var number = Convert.ToInt32(colorData.Split('=')[0]);

                if (number > ArgEditorConstants.DriverNumberMax)
                    continue;

                var driver = carset.Drivers.FirstOrDefault(d => d.Number == number);

                var mainData = colorData.Split('=')[1].Split(',');
                var bytes = mainData.Select(byte.Parse).ToArray();

                driver.HelmetColors = bytes;
            }

            carset.Settings.GeneralGripLevel = GetValueForProperty(lines, "AIGrip");
            carset.Settings.PlayerHorsepower = GetValueForProperty(lines, "HumanBHP");
            carset.Settings.ChanceOfRain = GetValueForProperty(lines, "WetRace");
            carset.Settings.RainAtFirstTrack = Convert.ToBoolean(GetValueForProperty(lines, "WetRacePhoenix"));

            return carset;
        }

        // weird name
        private static int FindLineMatching(string[] lines, string matching)
        {
            for (int i = 0; i <= lines.Length; i++)
            {
                string line = lines[i];

                if (line == matching)
                {
                    return i + 1;
                }
            }

            return -1;
        }

        private static int GetValueForProperty(string[] lines, string name)
        {
            // only for [F1Ed] section?

            for (int i = 0; i <= lines.Length; i++)
            {
                string line = lines[i];

                if (line.StartsWith(name + "="))
                {
                    var mainData = line.Split('=')[1];

                    return Convert.ToInt32(mainData);
                }
            }

            return -1;
        }

        // TODO: put somewhere else?
        // TODO: should have tests
        public static void IntoViewModel(MainViewModel mainViewModel, string path)
        {
            var legacy = LegacyCarSetLoader.Load(path);

            ClearAll(mainViewModel);

            for (int teamIndex = 0; teamIndex < ArgEditorConstants.TeamCountSupported; teamIndex++)
            {
                var vmTeam = mainViewModel.Teams[teamIndex];
                var legacyTeam = legacy.Teams[teamIndex];

                vmTeam.Name = legacyTeam.Name;
                vmTeam.Engine = legacyTeam.Engine;
                vmTeam.Horsepower = legacyTeam.Horsepower;

                // set team name and engine to "" if no drivers?
                if (legacyTeam.Driver1Number == 0 && legacyTeam.Driver2Number == 0)
                {
                    vmTeam.Name = "";
                    vmTeam.Engine = "";
                }

                var carcar = new Car(legacyTeam.CarColors);
                Mapper.MapDataCarToViewModelCar(carcar, vmTeam.Car);

                var pitcrew = new PitCrew(legacyTeam.PitCrewColors);
                Mapper.MapDataPitCrewToViewModelPitCrew(pitcrew, vmTeam.PitCrew);

                if (legacyTeam.Driver1Number > 0)
                {
                    var driver1 = legacy.Drivers.FirstOrDefault(d => d.Number == legacyTeam.Driver1Number);
                    Mapper.MapLegacyDriverToViewModelDriver(driver1, vmTeam.Drivers[0]);

                    var helmet = new Helmet(driver1.HelmetColors);
                    Mapper.MapDataHelmetToViewModelHelmet(helmet, vmTeam.Drivers[0].Helmet);
                }

                if (legacyTeam.Driver2Number > 0)
                {
                    var driver2 = legacy.Drivers.FirstOrDefault(d => d.Number == legacyTeam.Driver2Number);
                    Mapper.MapLegacyDriverToViewModelDriver(driver2, vmTeam.Drivers[1]);
                    var helmet = new Helmet(driver2.HelmetColors);
                    Mapper.MapDataHelmetToViewModelHelmet(helmet, vmTeam.Drivers[1].Helmet);
                }
            }

            mainViewModel.PlayerHorsepower = legacy.Settings.PlayerHorsepower;
            mainViewModel.GeneralGripLevel = legacy.Settings.GeneralGripLevel;
            mainViewModel.ChanceOfRainPercent = legacy.Settings.ChanceOfRain;
            mainViewModel.RainAtFirstTrack = legacy.Settings.RainAtFirstTrack;

            // reset points system, since .1ed files do not support editing it
            mainViewModel.PointsSystem.SetFrom1991To2002();
        }

        private static void ClearAll(MainViewModel viewModel)
        {
            // otherwise, drivers that weren't active in new .1ed file were not overwritten
            foreach (var driver in viewModel.Drivers)
            {
                driver.Number = 0;
                driver.Name = "";
            }
        }
    }
}
