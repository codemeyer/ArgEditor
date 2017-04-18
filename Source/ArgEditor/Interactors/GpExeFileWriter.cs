using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ArgData;
using ArgData.Entities;
using ArgEditor.ViewModels;

namespace ArgEditor.Interactors
{
    public class GpExeFileWriter
    {
        public void WriteViewModelToExe(MainViewModel viewModel, string exePath)
        {
            var exeFile = GetExeFile(exePath);

            WriteCarColors(viewModel, exeFile);
            WritePitCrewColors(viewModel, exeFile);
            WriteTeamHorsepower(viewModel, exeFile);
            WriteDriverNumbers(viewModel, exeFile);
            WriteGripLevels(viewModel, exeFile);
            WriteHelmetColors(viewModel, exeFile);
            WritePlayerHorsepower(viewModel, exeFile);
            WriteGeneralGripLevel(viewModel, exeFile);
            WriteWeatherSettings(viewModel, exeFile);
            WritePointsSystem(viewModel, exeFile);
        }

        public void WriteViewModelToExe(MainViewModel viewModel, string exePath, ExportViewModel exportViewModel)
        {
            var exeFile = GetExeFile(exePath);

            if (exportViewModel.ApplyCarColors)
                WriteCarColors(viewModel, exeFile);

            if (exportViewModel.ApplyPitCrewColors)
                WritePitCrewColors(viewModel, exeFile);

            if (exportViewModel.ApplyTeamHorsepower)
                WriteTeamHorsepower(viewModel, exeFile);

            if (exportViewModel.ApplyDriverNumbers)
                WriteDriverNumbers(viewModel, exeFile);

            if (exportViewModel.ApplyDriverPerformanceValues)
                WriteGripLevels(viewModel, exeFile);

            if (exportViewModel.ApplyHelmetColors)
                WriteHelmetColors(viewModel, exeFile);

            if (exportViewModel.ApplyPlayerHorsepowerValue)
                WritePlayerHorsepower(viewModel, exeFile);

            if (exportViewModel.ApplyGeneralAIGrip)
                WriteGeneralGripLevel(viewModel, exeFile);

            if (exportViewModel.ApplyWeatherSettings)
                WriteWeatherSettings(viewModel, exeFile);

            if (exportViewModel.ApplyPointsSystem)
                WritePointsSystem(viewModel, exeFile);
        }

        private static GpExeFile GetExeFile(string exePath)
        {
            try
            {
                return GpExeFile.At(exePath);
            }
            catch
            {
                MessageBox.Show("Not a valid GP.EXE file. Please try again!", "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        private static void WriteCarColors(MainViewModel viewModel, GpExeFile exeFile)
        {
            var colorReader = CarColorReader.For(exeFile);

            var list = colorReader.ReadCarColors();

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                var carInExe = list[i];
                var carInEditor = viewModel.Teams[i].Car;

                carInExe.EngineCover = carInEditor.EngineCoverColorIndex;
                carInExe.NoseTop = carInEditor.NoseTopColorIndex;
                carInExe.FrontWingEndplate = carInEditor.FrontWingEndplateColorIndex;
                carInExe.RearWingSide = carInEditor.RearWingSideColorIndex;
                carInExe.Sidepod = carInEditor.SidepodColorIndex;
                carInExe.FrontAndRearWing = carInEditor.FrontAndRearWingColorIndex;
                carInExe.CockpitFront = carInEditor.CockpitFrontColorIndex;
                carInExe.NoseAngle = carInEditor.NoseAngleColorIndex;
                carInExe.CockpitSide = carInEditor.CockpitSideColorIndex;
                carInExe.EngineCoverSide = carInEditor.EngineCoverSideColorIndex;
                carInExe.EngineCoverRear = carInEditor.EngineCoverRearColorIndex;
                carInExe.SidepodTop = carInEditor.SidepodTopColorIndex;
                carInExe.NoseSide = carInEditor.NoseSideColorIndex;
            }

            var colorWriter = CarColorWriter.For(exeFile);

            colorWriter.WriteCarColors(list);
        }

        private static void WritePitCrewColors(MainViewModel viewModel, GpExeFile exeFile)
        {
            var colorReader = PitCrewColorReader.For(exeFile);

            var list = colorReader.ReadPitCrewColors();

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                var pitCrewInExe = list[i];
                var pitCrewInEditor = viewModel.Teams[i].PitCrew;

                pitCrewInExe.ShirtPrimary = pitCrewInEditor.ShirtPrimaryColorIndex;
                pitCrewInExe.ShirtSecondary = pitCrewInEditor.ShirtSecondaryColorIndex;
                pitCrewInExe.PantsPrimary = pitCrewInEditor.PantsPrimaryColorIndex;
                pitCrewInExe.PantsSecondary = pitCrewInEditor.PantsSecondaryColorIndex;
                pitCrewInExe.Socks = pitCrewInEditor.SocksColorIndex;
            }

            var colorWriter = PitCrewColorWriter.For(exeFile);

            colorWriter.WritePitCrewColors(list);
        }

        private static void WriteTeamHorsepower(MainViewModel viewModel, GpExeFile exeFile)
        {
            var teamHorsepowerEditor = TeamHorsepowerWriter.For(exeFile);

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                int horsepower = viewModel.Teams[i].Horsepower;
                teamHorsepowerEditor.WriteTeamHorsepower(i, horsepower);
            }
        }

        private static void WriteDriverNumbers(MainViewModel viewModel, GpExeFile exeFile)
        {
            byte[] values = new byte[ArgEditorConstants.DriverCount];
            var theNumbers = new DriverNumberList();

            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                var driver = viewModel.Drivers[i];

                byte value = viewModel.Drivers[i].Number;
                if (!driver.Enabled)
                {
                    value = 0;
                }
                if (!driver.Team.Enabled)
                {
                    value = 0;
                }

                values[i] = value;
                theNumbers[Convert.ToByte(i)] = value;
            }

            var numbers = DriverNumberWriter.For(exeFile);
            numbers.WriteDriverNumbers(theNumbers);
        }

        private static void WriteGripLevels(MainViewModel viewModel, GpExeFile exeFile)
        {
            var gripLevelEditor = DriverPerformanceWriter.For(exeFile);

            var raceGripLevels = new DriverPerformanceList();
            var qualifyingGripLevels = new DriverPerformanceList();

            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                var driver = GetDriverWithNumber(viewModel.Drivers, Convert.ToByte(i + 1));

                raceGripLevels.SetByDriverNumber(Convert.ToByte(i + 1), driver.RaceGripLevel);
                qualifyingGripLevels.SetByDriverNumber(Convert.ToByte(i + 1), driver.QualifyingGripLevel);
            }

            gripLevelEditor.WriteRacePerformanceLevels(raceGripLevels);
            gripLevelEditor.WriteQualifyingPerformanceLevels(qualifyingGripLevels);
        }

        private static DriverViewModel GetDriverWithNumber(IList<DriverViewModel> drivers, byte number)
        {
            var driver = drivers.SingleOrDefault(d => d.Number == number);

            if (driver == default(DriverViewModel))
            {
                driver = new DriverViewModel(number, "", 0, 0);
            }

            return driver;
        }

        private void WriteHelmetColors(MainViewModel viewModel, GpExeFile exeFile)
        {
            var helmetReader = HelmetColorReader.For(exeFile);

            var list = helmetReader.ReadHelmetColors();

            for (byte b = 1; b <= ArgEditorConstants.DriverCount; b++)
            {
                var helmetInExe = list.GetByDriverNumber(b);
                var helmetInEditor = GetDriverWithNumber(viewModel.Drivers, b).Helmet;

                helmetInExe.Visor = helmetInEditor.VisorColorIndex;
                helmetInExe.VisorSurround = helmetInEditor.VisorSurroundColorIndex;
                helmetInExe.Stripes[0] = helmetInEditor.Stripe1ColorIndex;
                helmetInExe.Stripes[1] = helmetInEditor.Stripe2ColorIndex;
                helmetInExe.Stripes[2] = helmetInEditor.Stripe3ColorIndex;
                helmetInExe.Stripes[3] = helmetInEditor.Stripe4ColorIndex;
                helmetInExe.Stripes[4] = helmetInEditor.Stripe5ColorIndex;
                helmetInExe.Stripes[5] = helmetInEditor.Stripe6ColorIndex;
                helmetInExe.Stripes[6] = helmetInEditor.Stripe7ColorIndex;
                helmetInExe.Stripes[7] = helmetInEditor.Stripe8ColorIndex;
                helmetInExe.Stripes[8] = helmetInEditor.Stripe9ColorIndex;
                helmetInExe.Stripes[9] = helmetInEditor.Stripe10ColorIndex;
                helmetInExe.Stripes[10] = helmetInEditor.Stripe11ColorIndex;
                helmetInExe.Stripes[11] = helmetInEditor.Stripe12ColorIndex;
                helmetInExe.Stripes[12] = helmetInEditor.Stripe13ColorIndex;
            }

            var helmetWriter = HelmetColorWriter.For(exeFile);

            helmetWriter.WriteHelmetColors(list);
        }

        private static void WritePlayerHorsepower(MainViewModel viewModel, GpExeFile exeFile)
        {
            var horsepower = PlayerHorsepowerWriter.For(exeFile);
            horsepower.WritePlayerHorsepower(viewModel.PlayerHorsepower);
        }

        private static void WriteGeneralGripLevel(MainViewModel viewModel, GpExeFile exeFile)
        {
            // TODO: report incorrect value instead of just ignoring
            if (viewModel.GeneralGripLevel < 1 || viewModel.GeneralGripLevel > 100)
                return;

            var writer = DriverPerformanceWriter.For(exeFile);
            writer.WriteGeneralGripLevel(viewModel.GeneralGripLevel);
        }

        private static void WriteWeatherSettings(MainViewModel viewModel, GpExeFile exeFile)
        {
            // TODO: report incorrect value instead of just updating?
            if (viewModel.ChanceOfRainPercent < 0)
                viewModel.ChanceOfRainPercent = 0;

            if (viewModel.ChanceOfRainPercent > 100)
                viewModel.ChanceOfRainPercent = 100;

            var writer = WetWeatherSettingsWriter.For(exeFile);
            var settings = new WetWeatherSettings
            {
                ChanceOfRain = (byte)viewModel.ChanceOfRainPercent,
                RainAtFirstTrack = viewModel.RainAtFirstTrack
            };

            writer.WriteSettings(settings);
        }

        private static void WritePointsSystem(MainViewModel viewModel, GpExeFile exeFile)
        {
            var system = new PointsSystem();
            Mapper.MapPointsSystemViewModelToData(viewModel.PointsSystem, system);

            var writer = PointsSystemWriter.For(exeFile);
            writer.Write(system);
        }
    }
}
