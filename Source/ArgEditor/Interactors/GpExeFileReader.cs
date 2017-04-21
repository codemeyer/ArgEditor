using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ArgData;
using ArgEditor.Mappers;
using ArgEditor.ViewModels;

namespace ArgEditor.Interactors
{
    public class GpExeFileReader
    {
        public void UpdateViewModelFromExe(MainViewModel viewModel, string exePath)
        {
            var exeFile = GetExeFile(exePath);

            if (exeFile == null) { return; }

            UpdateCarColors(viewModel, exeFile);
            UpdatePitCrewColors(viewModel, exeFile);
            UpdateTeamHorsepower(viewModel, exeFile);
            UpdateDriverNumbers(viewModel, exeFile);
            UpdateGripLevels(viewModel, exeFile);
            UpdateHelmetColors(viewModel, exeFile);
            UpdatePlayerHorsepower(viewModel, exeFile);
            UpdateGeneralGripLevel(viewModel, exeFile);
            UpdateWeatherSettings(viewModel, exeFile);
            UpdatePointsSystem(viewModel, exeFile);
        }

        public void UpdateViewModelFromExe(MainViewModel viewModel, string exePath, ImportViewModel importViewModel)
        {
            var exeFile = GetExeFile(exePath);

            if (exeFile == null) { return; }

            if (importViewModel.ApplyCarColors)
                UpdateCarColors(viewModel, exeFile);

            if (importViewModel.ApplyPitCrewColors)
                UpdatePitCrewColors(viewModel, exeFile);

            if (importViewModel.ApplyTeamHorsepower)
                UpdateTeamHorsepower(viewModel, exeFile);

            if (importViewModel.ApplyPitCrewColors)
                UpdateDriverNumbers(viewModel, exeFile);

            if (importViewModel.ApplyDriverPerformanceValues)
                UpdateGripLevels(viewModel, exeFile);

            if (importViewModel.ApplyHelmetColors)
                UpdateHelmetColors(viewModel, exeFile);

            if (importViewModel.ApplyPlayerHorsepowerValue)
                UpdatePlayerHorsepower(viewModel, exeFile);

            if (importViewModel.ApplyGeneralAIGrip)
                UpdateGeneralGripLevel(viewModel, exeFile);

            if (importViewModel.ApplyWeatherSettings)
                UpdateWeatherSettings(viewModel, exeFile);

            if (importViewModel.ApplyPointsSystem)
                UpdatePointsSystem(viewModel, exeFile);
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

        private static void UpdateCarColors(MainViewModel viewModel, GpExeFile exeFile)
        {
            var carColorReader = CarColorReader.For(exeFile);

            var list = carColorReader.ReadCarColors();

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                var carInExe = list[i];
                var carInEditor = viewModel.Teams[i].Car;

                carInEditor.EngineCoverColorIndex = carInExe.EngineCover;
                carInEditor.NoseTopColorIndex = carInExe.NoseTop;
                carInEditor.FrontWingEndplateColorIndex = carInExe.FrontWingEndplate;
                carInEditor.RearWingSideColorIndex = carInExe.RearWingSide;
                carInEditor.SidepodColorIndex = carInExe.Sidepod;
                carInEditor.FrontAndRearWingColorIndex = carInExe.FrontAndRearWing;
                carInEditor.CockpitFrontColorIndex = carInExe.CockpitFront;
                carInEditor.NoseAngleColorIndex = carInExe.NoseAngle;
                carInEditor.CockpitSideColorIndex = carInExe.CockpitSide;
                carInEditor.EngineCoverSideColorIndex = carInExe.EngineCoverSide;
                carInEditor.EngineCoverRearColorIndex = carInExe.EngineCoverRear;
                carInEditor.SidepodTopColorIndex = carInExe.SidepodTop;
                carInEditor.NoseSideColorIndex = carInExe.NoseSide;
            }
        }

        private static void UpdatePitCrewColors(MainViewModel viewModel, GpExeFile exeFile)
        {
            var crewColorReader = PitCrewColorReader.For(exeFile);

            var list = crewColorReader.ReadPitCrewColors();

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                var pitCrewInExe = list[i];
                var pitCrewInEditor = viewModel.Teams[i].PitCrew;

                pitCrewInEditor.ShirtPrimaryColorIndex = pitCrewInExe.ShirtPrimary;
                pitCrewInEditor.ShirtSecondaryColorIndex = pitCrewInExe.ShirtSecondary;
                pitCrewInEditor.PantsPrimaryColorIndex = pitCrewInExe.PantsPrimary;
                pitCrewInEditor.PantsSecondaryColorIndex = pitCrewInExe.PantsSecondary;
                pitCrewInEditor.SocksColorIndex = pitCrewInExe.Socks;
            }
        }

        private static void UpdateTeamHorsepower(MainViewModel viewModel, GpExeFile exeFile)
        {
            var horsepowerReader = TeamHorsepowerReader.For(exeFile);

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                viewModel.Teams[i].Horsepower = horsepowerReader.ReadTeamHorsepower(i);
            }
        }

        private static void UpdateDriverNumbers(MainViewModel viewModel, GpExeFile exeFile)
        {
            var numbers = DriverNumberReader.For(exeFile);

            var values = numbers.ReadDriverNumbers();

            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                viewModel.Drivers[i].Number = values[(byte)i];
            }
        }

        private static void UpdateGripLevels(MainViewModel viewModel, GpExeFile exeFile)
        {
            var gripLevels = DriverPerformanceReader.For(exeFile);
            var raceGripLevels = gripLevels.ReadRacePerformanceLevels();
            var qualGripLevels = gripLevels.ReadQualifyingPerformanceLevels();

            foreach (var dr in viewModel.Drivers) //.Where(d => d.Enabled))
            {
                dr.RaceGripLevel = raceGripLevels.GetByDriverNumber(dr.Number);
                dr.QualifyingGripLevel = qualGripLevels.GetByDriverNumber(dr.Number);
            }
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

        private void UpdateHelmetColors(MainViewModel viewModel, GpExeFile exeFile)
        {
            var helmetColorReader = HelmetColorReader.For(exeFile);

            var list = helmetColorReader.ReadHelmetColors();

            for (byte i = 1; i <= ArgEditorConstants.DriverNumberMax; i++)
            {
                var helmetInExe = list.GetByDriverNumber(i);
                var helmetInEditor = GetDriverWithNumber(viewModel.Drivers, i).Helmet;

                helmetInEditor.VisorColorIndex = helmetInExe.Visor;
                helmetInEditor.VisorSurroundColorIndex = helmetInExe.VisorSurround;

                helmetInEditor.Stripe1ColorIndex = helmetInExe.Stripes[0];
                helmetInEditor.Stripe2ColorIndex = helmetInExe.Stripes[1];
                helmetInEditor.Stripe3ColorIndex = helmetInExe.Stripes[2];
                helmetInEditor.Stripe4ColorIndex = helmetInExe.Stripes[3];
                helmetInEditor.Stripe5ColorIndex = helmetInExe.Stripes[4];
                helmetInEditor.Stripe6ColorIndex = helmetInExe.Stripes[5];
                helmetInEditor.Stripe7ColorIndex = helmetInExe.Stripes[6];
                helmetInEditor.Stripe8ColorIndex = helmetInExe.Stripes[7];
                helmetInEditor.Stripe9ColorIndex = helmetInExe.Stripes[8];
                helmetInEditor.Stripe10ColorIndex = helmetInExe.Stripes[9];
                helmetInEditor.Stripe11ColorIndex = helmetInExe.Stripes[10];
                helmetInEditor.Stripe12ColorIndex = helmetInExe.Stripes[11];
                helmetInEditor.Stripe13ColorIndex = helmetInExe.Stripes[12];
            }
        }

        private static void UpdatePlayerHorsepower(MainViewModel viewModel, GpExeFile exeFile)
        {
            var horsepowerReader = PlayerHorsepowerReader.For(exeFile);
            viewModel.PlayerHorsepower = horsepowerReader.ReadPlayerHorsepower();
        }

        private static void UpdateGeneralGripLevel(MainViewModel viewModel, GpExeFile exeFile)
        {
            var griplevelReader = DriverPerformanceReader.For(exeFile);
            viewModel.GeneralGripLevel = griplevelReader.ReadGeneralGripLevel();
        }

        private static void UpdateWeatherSettings(MainViewModel viewModel, GpExeFile exeFile)
        {
            var weatherSettingsReader = WetWeatherSettingsReader.For(exeFile);
            var settings = weatherSettingsReader.ReadSettings();

            viewModel.ChanceOfRainPercent = settings.ChanceOfRain;
            viewModel.RainAtFirstTrack = settings.RainAtFirstTrack;
        }

        private static void UpdatePointsSystem(MainViewModel viewModel, GpExeFile exeFile)
        {
            var pointsSystemReader = PointsSystemReader.For(exeFile);
            var system = pointsSystemReader.Read();

            Mapper.MapDataPointsSystemToViewModel(system, viewModel.PointsSystem);
        }
    }
}
