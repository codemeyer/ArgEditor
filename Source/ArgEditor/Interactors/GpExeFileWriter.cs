using System;
using System.Collections.Generic;
using System.Linq;
using ArgData;
using ArgEditor.ViewModels;

namespace ArgEditor.Interactors
{
    public class GpExeFileWriter
    {
        public void WriteViewModelToExe(MainViewModel viewModel, string exePath)
        {
            var exeFile = new GpExeFile(exePath);

            WriteCarColors(viewModel, exeFile);
            WritePitCrewColors(viewModel, exeFile);
            WriteTeamHorsepower(viewModel, exeFile);
            WriteDriverNumbers(viewModel, exeFile);
            WriteGripLevels(viewModel, exeFile);
            WriteHelmetColors(viewModel, exeFile);
        }

        private static void WriteCarColors(MainViewModel viewModel, GpExeFile exeFile)
        {
            var colorEditor = new CarColorEditor(exeFile);

            var list = colorEditor.ReadCarColors();

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

            colorEditor.WriteCarColors(list);
        }

        private static void WritePitCrewColors(MainViewModel viewModel, GpExeFile exeFile)
        {
            var colorEditor = new PitCrewColorEditor(exeFile);

            var list = colorEditor.ReadPitCrewColors();

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

            colorEditor.WritePitCrewColors(list);
        }

        private static void WriteTeamHorsepower(MainViewModel viewModel, GpExeFile exeFile)
        {
            var teamHorsepowerEditor = new TeamHorsepowerEditor(exeFile);

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                int horsepower = viewModel.Teams[i].Horsepower;
                teamHorsepowerEditor.WriteTeamHorsepower(i, horsepower);
            }
        }

        private static void WriteDriverNumbers(MainViewModel viewModel, GpExeFile exeFile)
        {
            byte[] values = new byte[ArgEditorConstants.DriverCount];

            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                values[i] = viewModel.Drivers[i].Number;
            }

            var numbers = new DriverNumberEditor(exeFile);
            numbers.WriteDriverNumbers(values);
        }

        private static void WriteGripLevels(MainViewModel viewModel, GpExeFile exeFile)
        {
            var gripLevels = new GripLevelEditor(exeFile);

            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                var driver = GetDriverWithNumber(viewModel.Drivers, Convert.ToByte(i + 1));

                gripLevels.WriteQualifyingGripLevel(i, driver.QualifyingGripLevel);
                gripLevels.WriteRaceGripLevel(i, driver.RaceGripLevel);
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

        private void WriteHelmetColors(MainViewModel viewModel, GpExeFile exeFile)
        {
            var helmetEditor = new HelmetEditor(exeFile);

            var list = helmetEditor.ReadHelmetColors();

            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                var helmetInExe = list[i];
                var helmetInEditor = GetDriverWithNumber(viewModel.Drivers, Convert.ToByte(i + 1)).Helmet;

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

            helmetEditor.WriteHelmetColors(list);
        }
    }
}
