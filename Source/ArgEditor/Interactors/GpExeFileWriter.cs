using System;
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
            WriteTeamHorsepower(viewModel, exeFile);
            WriteGripLevels(viewModel, exeFile);
        }

        private static void WriteCarColors(MainViewModel viewModel, GpExeFile exeFile)
        {
            var colorEditor = new CarColorEditor(exeFile);

            var list = colorEditor.ReadCarColors();

            for (int i = 0; i <= 17; i++)
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

        private static void WriteTeamHorsepower(MainViewModel viewModel, GpExeFile exeFile)
        {
            var teamHorsepowerEditor = new TeamHorsepowerEditor(exeFile);

            for (int i = 0; i <= 17; i++)
            {
                int horsepower = viewModel.Teams[i].Horsepower;
                teamHorsepowerEditor.WriteTeamHorsepower(i, horsepower);
            }
        }

        private static void WriteGripLevels(MainViewModel viewModel, GpExeFile exeFile)
        {
            var gripLevels = new GripLevelEditor(exeFile);

            for (int i = 0; i < 36; i++)
            {
                var driver = viewModel.Drivers[i];
                gripLevels.WriteQualifyingGripLevel(i, driver.QualifyingGripLevel);
                gripLevels.WriteRaceGripLevel(i, driver.RaceGripLevel);
            }
        }
    }
}
