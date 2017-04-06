using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ArgEditor.Interactors.LegacyCarSets
{
    public static class LegacyCarSetSaver
    {
        // TODO: LegacyCarSet from MainViewModel?


        public static void Save(LegacyCarSet carset, string path)
        {
            var lines = GenerateLines(carset);

            File.WriteAllLines(path, lines.ToArray(), Encoding.ASCII);
        }

        public static List<string> GenerateLines(LegacyCarSet carset)
        {
            var lines = new List<string>();

            WriteDrivers(carset, lines);
            WriteTeams(carset, lines);
            WriteCarColors(carset, lines);
            WritePitCrewColors(carset, lines);
            WriteHelmetColors(carset, lines);
            WriteSettings(carset, lines);
            WriteRemainingData(lines);

            return lines;
        }

        private static void WriteDrivers(LegacyCarSet carset, List<string> lines)
        {
            lines.Add("[Drivers]");

            for (int i = 1; i <= 40; i++)
            {
                var driver = carset.Drivers.FirstOrDefault(d => d.Number == i);

                if (driver == null)
                {
                    driver = new LegacyDriver
                    {
                        Number = i,
                        Name = $"Spare{i}",
                        RacePerformance = 0,
                        QualifyingPerformance = 0
                    };
                }

                lines.Add($"{i}={driver.Name},{driver.QualifyingPerformance},{driver.RacePerformance},0");
            }
        }

        private static void WriteTeams(LegacyCarSet carset, List<string> lines)
        {
            lines.Add("[Teams]");

            for (int i = 1; i <= 20; i++)
            {
                var team = i <= 18
                    ? carset.Teams[i - 1]
                    : new LegacyTeam
                    {
                        Name = "Not Used",
                        Engine = "Not Used",
                        Driver1Number = 0,
                        Driver2Number = 0,
                        Horsepower = 0
                    };

                lines.Add($"{i}={team.Name},{team.Engine},{team.Horsepower},{team.Driver1Number},{team.Driver2Number}");
            }
        }

        private static void WriteCarColors(LegacyCarSet carset, List<string> lines)
        {
            lines.Add("[CarColours]");

            for (int i = 1; i <= 20; i++)
            {
                var team = i <= 18
                    ? carset.Teams[i - 1]
                    : new LegacyTeam
                    {
                        CarColors = new byte[16]
                    };

                var line = string.Join(",", team.CarColors);
                lines.Add($"{i}={line}");
            }
        }

        private static void WritePitCrewColors(LegacyCarSet carset, List<string> lines)
        {
            lines.Add("[PitColours]");

            for (int i = 1; i <= 20; i++)
            {
                var team = i <= 18
                    ? carset.Teams[i - 1]
                    : new LegacyTeam
                    {
                        PitCrewColors = new byte[16]
                    };

                var line = string.Join(",", team.PitCrewColors);
                lines.Add($"{i}={line}");
            }
        }

        private static void WriteHelmetColors(LegacyCarSet carset, List<string> lines)
        {
            lines.Add("[HelmetColours]");

            for (int i = 1; i <= 40; i++)
            {
                var driver = carset.Drivers.FirstOrDefault(d => d.Number == i);

                if (driver == null)
                {
                    driver = new LegacyDriver
                    {
                        Number = i,
                        HelmetColors = new byte[16]
                    };
                }

                var line = string.Join(",", driver.HelmetColors);
                lines.Add($"{i}={line}");
            }
        }

        private static void WriteSettings(LegacyCarSet carset, List<string> lines)
        {
            var bhpLegalise = carset.Settings.PlayerHorsepower == 716 ? "1" : "0";
            var rainAtFirstTrack = carset.Settings.RainAtFirstTrack ? "1" : "0";

            lines.Add("[F1Ed]");
            lines.Add($"AIGrip={carset.Settings.GeneralGripLevel}");
            lines.Add($"HumanBHP={carset.Settings.PlayerHorsepower}");
            lines.Add($"BHPLegalise={bhpLegalise}");
            lines.Add("NameFile=");
            lines.Add("BatchFile=C:\\GPRIX\\STARTGP.BAT");
            lines.Add("Damage1=7424");
            lines.Add("Damage2=8192");
            lines.Add("Damage3=1792");
            lines.Add("Damage4=1792");
            lines.Add("YellowFlag=20");
            lines.Add("RemoveCrashedCar=15");
            lines.Add("FastFade=0");
            lines.Add("FPS=25");
            lines.Add("CameraZoom=248");
            lines.Add("CameraHeight=384");
            lines.Add("QTyres=0");
            lines.Add("SlowestTeam=600");
            lines.Add("FastestTeam=900");
            lines.Add("SlowestDriver=80");
            lines.Add("FastestDriver=1");
            lines.Add("MateFactor=2");
            lines.Add($"WetRacePhoenix={rainAtFirstTrack}");
            lines.Add($"WetRace={carset.Settings.ChanceOfRain}");
            lines.Add("NumRaces=5");
        }

        private static void WriteRemainingData(List<string> lines)
        {
            lines.Add("[GPGAP]");
            lines.Add("Status=1");
            lines.Add("ShowCars=15");
            lines.Add("TimeDelay=2");
            lines.Add("FileName=GPGAP.EXE");
            lines.Add("[GPPERF]");
            lines.Add("Status=1");
            lines.Add("LED1=10000");
            lines.Add("LED2=11500");
            lines.Add("LED3=13000");
            lines.Add("LogDisable=0");
            lines.Add("AutoLog=2");
            lines.Add("LogFileName=GPPERF.PRF");
            lines.Add("FileName=GPPERF.EXE");
            lines.Add("[GPLAPTIM]");
            lines.Add("Status=1");
            lines.Add("LogOnlyPlayer=1");
            lines.Add("LogFileName=GPLAPTIM.LOG");
            lines.Add("FileName=GPLAPTIM.COM");
            lines.Add("SplitPercent1=25");
            lines.Add("SplitPercent2=50");
            lines.Add("SplitPercent3=75");
            lines.Add("Delay=10");
            lines.Add("[CCPIT]");
            lines.Add("Status=1");
            lines.Add("MaxCars=13");
            lines.Add("TyreCompound=5");
            lines.Add("RandGroupOrder=1");
            lines.Add("Multiplayer=0");
            lines.Add("Pitgroup1=20,0,2,25,55");
            lines.Add("Pitgroup2=6,0,2,35,65");
            lines.Add("FileName=CCPIT.EXE");
            lines.Add("[ExtraBatch]");
            lines.Add("NumLinesBefore=1");
            lines.Add("BeforeLine1=");
            lines.Add("NumLinesAfter=1");
            lines.Add("AfterLine1=");
            lines.Add("[Race1]");
            lines.Add("Enabled=0");
            lines.Add("EventName=1996 Australian G.P. (Melbourne)");
            lines.Add("IgnoreRace=1");
            lines.Add("DriverData1=1:33.125,1,0:00.000,1");
            lines.Add("DriverData2=1:32.889,1,0:00.000,1");
            lines.Add("DriverData3=1:34.257,1,0:00.000,1");
            lines.Add("DriverData4=1:34.344,1,0:00.000,1");
            lines.Add("DriverData5=1:32.509,1,0:00.000,1");
            lines.Add("DriverData6=1:32.371,1,0:00.000,1");
            lines.Add("DriverData7=1:34.054,1,0:00.000,1");
            lines.Add("DriverData8=1:35.351,1,0:00.000,1");
            lines.Add("DriverData9=1:35.330,1,0:00.000,1");
            lines.Add("DriverData10=1:36.298,1,0:00.000,1");
            lines.Add("DriverData11=1:34.474,1,0:00.000,1");
            lines.Add("DriverData12=1:36.286,1,0:00.000,1");
            lines.Add("DriverData13=0:00.000,0,0:00.000,0");
            lines.Add("DriverData14=1:35.453,1,0:00.000,1");
            lines.Add("DriverData15=1:34.494,1,0:00.000,1");
            lines.Add("DriverData16=1:36.198,1,0:00.000,1");
            lines.Add("DriverData17=1:35.338,1,0:00.000,1");
            lines.Add("DriverData18=1:35.715,1,0:00.000,1");
            lines.Add("DriverData19=1:34.832,1,0:00.000,1");
            lines.Add("DriverData20=1:36.109,1,0:00.000,1");
            lines.Add("DriverData21=1:35.898,1,0:00.000,1");
            lines.Add("DriverData22=1:42.087,1,0:00.000,1");
            lines.Add("DriverData23=1:39.202,1,0:00.000,1");
            lines.Add("DriverData24=0:00.000,0,0:00.000,1");
            lines.Add("DriverData25=0:00.000,0,0:00.000,1");
            lines.Add("DriverData26=0:00.000,0,0:00.000,0");
            lines.Add("DriverData27=0:00.000,0,0:00.000,0");
            lines.Add("DriverData28=0:00.000,0,0:00.000,0");
            lines.Add("DriverData29=0:00.000,0,0:00.000,0");
            lines.Add("DriverData30=0:00.000,0,0:00.000,0");
            lines.Add("DriverData31=0:00.000,1,0:00.000,1");
            lines.Add("DriverData32=0:00.000,1,0:00.000,1");
            lines.Add("DriverData33=0:00.000,0,0:00.000,0");
            lines.Add("DriverData34=0:00.000,0,0:00.000,0");
            lines.Add("DriverData35=0:00.000,0,0:00.000,0");
            lines.Add("DriverData36=0:00.000,0,0:00.000,0");
            lines.Add("DriverData37=0:00.000,0,0:00.000,0");
            lines.Add("DriverData38=0:00.000,0,0:00.000,0");
            lines.Add("DriverData39=0:00.000,0,0:00.000,0");
            lines.Add("DriverData40=0:00.000,0,0:00.000,0");
            lines.Add("[Race2]");
            lines.Add("Enabled=0");
            lines.Add("EventName=1996 Brazilian G.P. (Interlagos)");
            lines.Add("IgnoreRace=1");
            lines.Add("DriverData1=1:19.474,1,0:00.000,1");
            lines.Add("DriverData2=1:19.591,1,0:00.000,1");
            lines.Add("DriverData3=1:19.484,1,0:00.000,1");
            lines.Add("DriverData4=1:19.762,1,0:00.000,1");
            lines.Add("DriverData5=1:18.111,1,0:00.000,1");
            lines.Add("DriverData6=1:19.254,1,0:00.000,1");
            lines.Add("DriverData7=1:19.607,1,0:00.000,1");
            lines.Add("DriverData8=1:20.167,1,0:00.000,1");
            lines.Add("DriverData9=1:20.426,1,0:00.000,1");
            lines.Add("DriverData10=1:20.873,1,0:00.000,1");
            lines.Add("DriverData11=1:19.092,1,0:00.000,1");
            lines.Add("DriverData12=1:19.519,1,0:00.000,1");
            lines.Add("DriverData13=0:00.000,0,0:00.000,0");
            lines.Add("DriverData14=1:20.144,1,0:00.000,1");
            lines.Add("DriverData15=1:19.799,1,0:00.000,1");
            lines.Add("DriverData16=1:20.440,1,0:00.000,1");
            lines.Add("DriverData17=1:20.157,1,0:00.000,1");
            lines.Add("DriverData18=1:20.427,1,0:00.000,1");
            lines.Add("DriverData19=1:20.000,1,0:00.000,1");
            lines.Add("DriverData20=1:21.491,1,0:00.000,1");
            lines.Add("DriverData21=1:21.421,1,0:00.000,1");
            lines.Add("DriverData22=1:23.454,1,0:00.000,1");
            lines.Add("DriverData23=1:23.174,1,0:00.000,1");
            lines.Add("DriverData24=1:23.172,-1,0:00.000,1");
            lines.Add("DriverData25=1:23.176,-1,0:00.000,1");
            lines.Add("DriverData26=0:00.000,0,0:00.000,0");
            lines.Add("DriverData27=0:00.000,0,0:00.000,0");
            lines.Add("DriverData28=0:00.000,0,0:00.000,0");
            lines.Add("DriverData29=0:00.000,0,0:00.000,0");
            lines.Add("DriverData30=0:00.000,0,0:00.000,0");
            lines.Add("DriverData31=1:23.173,-1,0:00.000,1");
            lines.Add("DriverData32=0:00.000,0,0:00.000,1");
            lines.Add("DriverData33=0:00.000,0,0:00.000,0");
            lines.Add("DriverData34=0:00.000,0,0:00.000,0");
            lines.Add("DriverData35=0:00.000,0,0:00.000,0");
            lines.Add("DriverData36=0:00.000,0,0:00.000,0");
            lines.Add("DriverData37=0:00.000,0,0:00.000,0");
            lines.Add("DriverData38=0:00.000,0,0:00.000,0");
            lines.Add("DriverData39=0:00.000,0,0:00.000,0");
            lines.Add("DriverData40=0:00.000,0,0:00.000,0");
            lines.Add("[Race3]");
            lines.Add("Enabled=0");
            lines.Add("EventName=1996 Argentine G.P.");
            lines.Add("IgnoreRace=1");
            lines.Add("DriverData1=1:30.598,1,0:00.000,1");
            lines.Add("DriverData2=1:32.058,1,0:00.000,1");
            lines.Add("DriverData3=1:31.038,1,0:00.000,1");
            lines.Add("DriverData4=1:31.262,1,0:00.000,1");
            lines.Add("DriverData5=1:30.346,1,0:00.000,1");
            lines.Add("DriverData6=1:30.907,1,0:00.000,1");
            lines.Add("DriverData7=1:31.891,1,0:00.000,1");
            lines.Add("DriverData8=1:32.001,1,0:00.000,1");
            lines.Add("DriverData9=1:32.177,1,0:00.000,1");
            lines.Add("DriverData10=1:33.424,1,0:00.000,1");
            lines.Add("DriverData11=1:31.262,1,0:00.000,1");
            lines.Add("DriverData12=1:32.696,1,0:00.000,1");
            lines.Add("DriverData13=0:00.000,0,0:00.000,0");
            lines.Add("DriverData14=1:33.256,1,0:00.000,1");
            lines.Add("DriverData15=1:32.130,1,0:00.000,1");
            lines.Add("DriverData16=1:33.752,1,0:00.000,1");
            lines.Add("DriverData17=1:31.615,1,0:00.000,1");
            lines.Add("DriverData18=1:32.407,1,0:00.000,1");
            lines.Add("DriverData19=1:32.903,1,0:00.000,1");
            lines.Add("DriverData20=1:33.727,1,0:00.000,1");
            lines.Add("DriverData21=1:32.502,1,0:00.000,1");
            lines.Add("DriverData22=1:35.651,1,0:00.000,1");
            lines.Add("DriverData23=1:34.830,1,0:00.000,1");
            lines.Add("DriverData24=1:35.651,1,0:00.000,1");
            lines.Add("DriverData25=1:35.651,1,0:00.000,1");
            lines.Add("DriverData26=0:00.000,0,0:00.000,0");
            lines.Add("DriverData27=0:00.000,0,0:00.000,0");
            lines.Add("DriverData28=0:00.000,0,0:00.000,0");
            lines.Add("DriverData29=0:00.000,0,0:00.000,0");
            lines.Add("DriverData30=0:00.000,0,0:00.000,0");
            lines.Add("DriverData31=1:35.651,1,0:00.000,1");
            lines.Add("DriverData32=1:35.651,1,0:00.000,1");
            lines.Add("DriverData33=0:00.000,0,0:00.000,0");
            lines.Add("DriverData34=0:00.000,0,0:00.000,0");
            lines.Add("DriverData35=0:00.000,0,0:00.000,0");
            lines.Add("DriverData36=0:00.000,0,0:00.000,0");
            lines.Add("DriverData37=0:00.000,0,0:00.000,0");
            lines.Add("DriverData38=0:00.000,0,0:00.000,0");
            lines.Add("DriverData39=0:00.000,0,0:00.000,0");
            lines.Add("DriverData40=0:00.000,0,0:00.000,0");
            lines.Add("[Race4]");
            lines.Add("Enabled=0");
            lines.Add("EventName=1996 European G.P. (Nurburgring)");
            lines.Add("IgnoreRace=1");
            lines.Add("DriverData1=1:20.149,1,0:00.000,1");
            lines.Add("DriverData2=1:20.931,1,0:00.000,1");
            lines.Add("DriverData3=1:20.711,1,0:00.000,1");
            lines.Add("DriverData4=1:21.054,1,0:00.000,1");
            lines.Add("DriverData5=1:18.941,1,0:00.000,1");
            lines.Add("DriverData6=1:19.721,1,0:00.000,1");
            lines.Add("DriverData7=1:21.078,1,0:00.000,1");
            lines.Add("DriverData8=1:20.888,1,0:00.000,1");
            lines.Add("DriverData9=1:21.509,1,0:00.000,1");
            lines.Add("DriverData10=1:22.733,1,0:00.000,1");
            lines.Add("DriverData11=1:20.818,1,0:00.000,1");
            lines.Add("DriverData12=1:21.177,1,0:00.000,1");
            lines.Add("DriverData13=0:00.000,0,0:00.000,0");
            lines.Add("DriverData14=1:21.210,1,0:00.000,1");
            lines.Add("DriverData15=1:21.113,1,0:00.000,1");
            lines.Add("DriverData16=1:23.620,1,0:00.000,1");
            lines.Add("DriverData17=1:21.367,1,0:00.000,1");
            lines.Add("DriverData18=1:21.812,1,0:00.000,1");
            lines.Add("DriverData19=1:21.458,1,0:00.000,1");
            lines.Add("DriverData20=1:23.139,1,0:00.000,1");
            lines.Add("DriverData21=1:22.921,1,0:00.000,1");
            lines.Add("DriverData22=1:25.053,1,0:00.000,1");
            lines.Add("DriverData23=1:25.840,1,0:00.000,1");
            lines.Add("DriverData24=1:25.840,1,0:00.000,1");
            lines.Add("DriverData25=1:25.840,1,0:00.000,1");
            lines.Add("DriverData26=0:00.000,0,0:00.000,0");
            lines.Add("DriverData27=0:00.000,0,0:00.000,0");
            lines.Add("DriverData28=0:00.000,0,0:00.000,0");
            lines.Add("DriverData29=0:00.000,0,0:00.000,0");
            lines.Add("DriverData30=0:00.000,0,0:00.000,0");
            lines.Add("DriverData31=1:25.840,1,0:00.000,1");
            lines.Add("DriverData32=0:00.000,0,0:00.000,1");
            lines.Add("DriverData33=0:00.000,0,0:00.000,0");
            lines.Add("DriverData34=0:00.000,0,0:00.000,0");
            lines.Add("DriverData35=0:00.000,0,0:00.000,0");
            lines.Add("DriverData36=0:00.000,0,0:00.000,0");
            lines.Add("DriverData37=0:00.000,0,0:00.000,0");
            lines.Add("DriverData38=0:00.000,0,0:00.000,0");
            lines.Add("DriverData39=0:00.000,0,0:00.000,0");
            lines.Add("DriverData40=0:00.000,0,0:00.000,0");
            lines.Add("[Race5]");
            lines.Add("Enabled=1");
            lines.Add("EventName=1996 San Marino G.P. (Imola)");
            lines.Add("IgnoreRace=1");
            lines.Add("DriverData1=1:26.890,1,0:00.000,1");
            lines.Add("DriverData2=1:28.205,1,0:00.000,1");
            lines.Add("DriverData3=1:28.009,1,0:00.000,1");
            lines.Add("DriverData4=1:28.336,1,0:00.000,1");
            lines.Add("DriverData5=1:27.105,1,0:00.000,1");
            lines.Add("DriverData6=1:27.220,1,0:00.000,1");
            lines.Add("DriverData7=1:29.079,1,0:00.000,1");
            lines.Add("DriverData8=1:27.688,1,0:00.000,1");
            lines.Add("DriverData9=1:29.472,1,0:00.000,1");
            lines.Add("DriverData10=1:29.989,1,0:00.000,1");
            lines.Add("DriverData11=1:28.632,1,0:00.000,1");
            lines.Add("DriverData12=1:29.099,1,0:00.000,1");
            lines.Add("DriverData13=0:00.000,0,0:00.000,0");
            lines.Add("DriverData14=1:29.541,1,0:00.000,1");
            lines.Add("DriverData15=1:28.785,1,0:00.000,1");
            lines.Add("DriverData16=1:31.316,1,0:00.000,1");
            lines.Add("DriverData17=1:29.539,1,0:00.000,1");
            lines.Add("DriverData18=1:29.892,1,0:00.000,1");
            lines.Add("DriverData19=1:28.423,1,0:00.000,1");
            lines.Add("DriverData20=1:30.471,1,0:00.000,1");
            lines.Add("DriverData21=1:30.814,1,0:00.000,1");
            lines.Add("DriverData22=1:33.685,1,0:00.000,1");
            lines.Add("DriverData23=1:32.037,1,0:00.000,1");
            lines.Add("DriverData24=0:00.000,0,0:00.000,1");
            lines.Add("DriverData25=0:00.000,0,0:00.000,1");
            lines.Add("DriverData26=0:00.000,0,0:00.000,0");
            lines.Add("DriverData27=0:00.000,0,0:00.000,0");
            lines.Add("DriverData28=0:00.000,0,0:00.000,0");
            lines.Add("DriverData29=0:00.000,0,0:00.000,0");
            lines.Add("DriverData30=0:00.000,0,0:00.000,0");
            lines.Add("DriverData31=1:33.685,0,0:00.000,1");
            lines.Add("DriverData32=1:33.685,0,0:00.000,1");
            lines.Add("DriverData33=0:00.000,0,0:00.000,0");
            lines.Add("DriverData34=0:00.000,0,0:00.000,0");
            lines.Add("DriverData35=0:00.000,0,0:00.000,0");
            lines.Add("DriverData36=0:00.000,0,0:00.000,0");
            lines.Add("DriverData37=0:00.000,0,0:00.000,0");
            lines.Add("DriverData38=0:00.000,0,0:00.000,0");
            lines.Add("DriverData39=0:00.000,0,0:00.000,0");
            lines.Add("DriverData40=0:00.000,0,0:00.000,0");
            lines.Add("[ComputerCarSetup]");
            lines.Add("1Qual=64");
            lines.Add("1Race=64");
            lines.Add("1FWing=48");
            lines.Add("1RWing=48");
            lines.Add("1Brake=0");
            lines.Add("1Gear1=23");
            lines.Add("1Gear2=30");
            lines.Add("1Gear3=37");
            lines.Add("1Gear4=43");
            lines.Add("1Gear5=51");
            lines.Add("1Gear6=57");
            lines.Add("2Qual=65");
            lines.Add("2Race=64");
            lines.Add("2FWing=38");
            lines.Add("2RWing=38");
            lines.Add("2Brake=0");
            lines.Add("2Gear1=24");
            lines.Add("2Gear2=32");
            lines.Add("2Gear3=39");
            lines.Add("2Gear4=46");
            lines.Add("2Gear5=53");
            lines.Add("2Gear6=60");
            lines.Add("3Qual=63");
            lines.Add("3Race=63");
            lines.Add("3FWing=38");
            lines.Add("3RWing=38");
            lines.Add("3Brake=0");
            lines.Add("3Gear1=24");
            lines.Add("3Gear2=33");
            lines.Add("3Gear3=40");
            lines.Add("3Gear4=47");
            lines.Add("3Gear5=55");
            lines.Add("3Gear6=64");
            lines.Add("4Qual=64");
            lines.Add("4Race=63");
            lines.Add("4FWing=58");
            lines.Add("4RWing=58");
            lines.Add("4Brake=0");
            lines.Add("4Gear1=23");
            lines.Add("4Gear2=30");
            lines.Add("4Gear3=37");
            lines.Add("4Gear4=43");
            lines.Add("4Gear5=51");
            lines.Add("4Gear6=57");
            lines.Add("5Qual=65");
            lines.Add("5Race=65");
            lines.Add("5FWing=37");
            lines.Add("5RWing=37");
            lines.Add("5Brake=0");
            lines.Add("5Gear1=24");
            lines.Add("5Gear2=32");
            lines.Add("5Gear3=39");
            lines.Add("5Gear4=46");
            lines.Add("5Gear5=53");
            lines.Add("5Gear6=60");
            lines.Add("6Qual=64");
            lines.Add("6Race=64");
            lines.Add("6FWing=36");
            lines.Add("6RWing=36");
            lines.Add("6Brake=0");
            lines.Add("6Gear1=24");
            lines.Add("6Gear2=33");
            lines.Add("6Gear3=40");
            lines.Add("6Gear4=47");
            lines.Add("6Gear5=55");
            lines.Add("6Gear6=64");
            lines.Add("7Qual=66");
            lines.Add("7Race=65");
            lines.Add("7FWing=39");
            lines.Add("7RWing=39");
            lines.Add("7Brake=0");
            lines.Add("7Gear1=24");
            lines.Add("7Gear2=32");
            lines.Add("7Gear3=39");
            lines.Add("7Gear4=46");
            lines.Add("7Gear5=53");
            lines.Add("7Gear6=60");
            lines.Add("8Qual=65");
            lines.Add("8Race=63");
            lines.Add("8FWing=44");
            lines.Add("8RWing=44");
            lines.Add("8Brake=0");
            lines.Add("8Gear1=24");
            lines.Add("8Gear2=33");
            lines.Add("8Gear3=40");
            lines.Add("8Gear4=48");
            lines.Add("8Gear5=55");
            lines.Add("8Gear6=62");
            lines.Add("9Qual=65");
            lines.Add("9Race=63");
            lines.Add("9FWing=18");
            lines.Add("9RWing=18");
            lines.Add("9Brake=0");
            lines.Add("9Gear1=24");
            lines.Add("9Gear2=33");
            lines.Add("9Gear3=40");
            lines.Add("9Gear4=48");
            lines.Add("9Gear5=57");
            lines.Add("9Gear6=66");
            lines.Add("10Qual=63");
            lines.Add("10Race=63");
            lines.Add("10FWing=56");
            lines.Add("10RWing=56");
            lines.Add("10Brake=0");
            lines.Add("10Gear1=23");
            lines.Add("10Gear2=30");
            lines.Add("10Gear3=37");
            lines.Add("10Gear4=43");
            lines.Add("10Gear5=51");
            lines.Add("10Gear6=57");
            lines.Add("11Qual=65");
            lines.Add("11Race=63");
            lines.Add("11FWing=37");
            lines.Add("11RWing=37");
            lines.Add("11Brake=0");
            lines.Add("11Gear1=24");
            lines.Add("11Gear2=33");
            lines.Add("11Gear3=40");
            lines.Add("11Gear4=47");
            lines.Add("11Gear5=55");
            lines.Add("11Gear6=64");
            lines.Add("12Qual=64");
            lines.Add("12Race=64");
            lines.Add("12FWing=30");
            lines.Add("12RWing=30");
            lines.Add("12Brake=0");
            lines.Add("12Gear1=24");
            lines.Add("12Gear2=33");
            lines.Add("12Gear3=40");
            lines.Add("12Gear4=48");
            lines.Add("12Gear5=57");
            lines.Add("12Gear6=66");
            lines.Add("13Qual=66");
            lines.Add("13Race=64");
            lines.Add("13FWing=36");
            lines.Add("13RWing=36");
            lines.Add("13Brake=0");
            lines.Add("13Gear1=24");
            lines.Add("13Gear2=33");
            lines.Add("13Gear3=40");
            lines.Add("13Gear4=48");
            lines.Add("13Gear5=55");
            lines.Add("13Gear6=62");
            lines.Add("14Qual=64");
            lines.Add("14Race=64");
            lines.Add("14FWing=40");
            lines.Add("14RWing=40");
            lines.Add("14Brake=0");
            lines.Add("14Gear1=24");
            lines.Add("14Gear2=32");
            lines.Add("14Gear3=39");
            lines.Add("14Gear4=46");
            lines.Add("14Gear5=53");
            lines.Add("14Gear6=60");
            lines.Add("15Qual=65");
            lines.Add("15Race=64");
            lines.Add("15FWing=44");
            lines.Add("15RWing=44");
            lines.Add("15Brake=0");
            lines.Add("15Gear1=24");
            lines.Add("15Gear2=33");
            lines.Add("15Gear3=40");
            lines.Add("15Gear4=48");
            lines.Add("15Gear5=55");
            lines.Add("15Gear6=62");
            lines.Add("16Qual=65");
            lines.Add("16Race=65");
            lines.Add("16FWing=44");
            lines.Add("16RWing=44");
            lines.Add("16Brake=0");
            lines.Add("16Gear1=23");
            lines.Add("16Gear2=30");
            lines.Add("16Gear3=37");
            lines.Add("16Gear4=43");
            lines.Add("16Gear5=52");
            lines.Add("16Gear6=61");
        }
    }
}
