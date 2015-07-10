using ArgData;
using ArgEditor.ViewModels;

namespace ArgEditor.Interactors
{
    public class GpExeFileReader
    {
        public void UpdateViewModelFromExe(MainViewModel viewModel, string exePath)
        {
            var exe = new GpExeFile(exePath);
            UpdateCarColors(viewModel, exe);
        }

        private static void UpdateCarColors(MainViewModel viewModel, GpExeFile exe)
        {
            var colorEditor = new CarColorEditor(exe);

            var list = colorEditor.ReadCarColors();

            for (int i = 0; i < 18; i++)
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
    }
}
