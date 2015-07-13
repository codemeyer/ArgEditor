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
        }

        private static void UpdateCarColors(MainViewModel viewModel, GpExeFile exeFile)
        {
            var colorEditor = new CarColorEditor(exeFile);

            var list = colorEditor.ReadCarColors();

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
            var colorEditor = new PitCrewColorEditor(exeFile);

            var list = colorEditor.ReadPitCrewColors();

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
            var teamHorsepowerEditor = new TeamHorsepowerEditor(exeFile);

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                viewModel.Teams[i].Horsepower = teamHorsepowerEditor.ReadTeamHorsepower(i);
            }
        }

        private static void UpdateDriverNumbers(MainViewModel viewModel, GpExeFile exeFile)
        {
            var numbers = new DriverNumberEditor(exeFile);

            var values = numbers.ReadDriverNumbers();

            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                viewModel.Drivers[i].Number = values[i];
            }
        }

        private static void UpdateGripLevels(MainViewModel viewModel, GpExeFile exeFile)
        {
            var gripLevels = new GripLevelEditor(exeFile);

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
    }
}
