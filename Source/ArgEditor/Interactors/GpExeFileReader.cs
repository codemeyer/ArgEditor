using System;
using System.Collections.Generic;
using System.Linq;
using ArgData;
using ArgEditor.ViewModels;

namespace ArgEditor.Interactors
{
    public class GpExeFileReader
    {
        public void UpdateViewModelFromExe(MainViewModel viewModel, string exePath)
        {
            var exeFile = new GpExeFile(exePath);

            UpdateCarColors(viewModel, exeFile);
            UpdatePitCrewColors(viewModel, exeFile);
            UpdateTeamHorsepower(viewModel, exeFile);
            UpdateDriverNumbers(viewModel, exeFile);
            UpdateGripLevels(viewModel, exeFile);
            UpdateHelmetColors(viewModel, exeFile);
        }

        private static void UpdateCarColors(MainViewModel viewModel, GpExeFile exeFile)
        {
            var carColorReader = new CarColorReader(exeFile);

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
            var crewColorReader = new PitCrewColorReader(exeFile);

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
            var horsepowerReader = new TeamHorsepowerReader(exeFile);

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                viewModel.Teams[i].Horsepower = horsepowerReader.ReadTeamHorsepower(i);
            }
        }

        private static void UpdateDriverNumbers(MainViewModel viewModel, GpExeFile exeFile)
        {
            var numbers = new DriverNumberReader(exeFile);

            var values = numbers.ReadDriverNumbers();

            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                viewModel.Drivers[i].Number = values[i];
            }
        }

        private static void UpdateGripLevels(MainViewModel viewModel, GpExeFile exeFile)
        {
            var gripLevels = new GripLevelReader(exeFile);

            for (int i = 0; i < ArgEditorConstants.DriverCount; i++)
            {
                var driver = GetDriverWithNumber(viewModel.Drivers, Convert.ToByte(i + 1));

                driver.QualifyingGripLevel = gripLevels.ReadQualifyingGripLevel(i);
                driver.RaceGripLevel = gripLevels.ReadRaceGripLevel(i);
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
            var helmetColorReader = new HelmetReader(exeFile);

            var list = helmetColorReader.ReadHelmetColors();

            for (int i = 0; i < ArgEditorConstants.DriverCount; i++)
            {
                var helmetInExe = list[i];
                var helmetInEditor = GetDriverWithNumber(viewModel.Drivers, Convert.ToByte(i + 1)).Helmet;

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
    }
}
