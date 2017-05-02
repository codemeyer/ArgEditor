using System.Collections.Generic;
using ArgData.Entities;

namespace ArgEditor.ViewModels
{
    public class MultiSetupViewModel : BaseViewModel
    {
        public MultiSetupViewModel()
        {
            SetupPairs = MultiSetupSetup.SetupList();
        }

        private bool _separateSetups;

        public bool SeparateSetups
        {
            get { return _separateSetups; }
            set
            {
                if (SetProperty(ref _separateSetups, value, () => SeparateSetups))
                {
                    foreach (var pair in SetupPairs)
                    {
                        pair.SeparateSetups = value;
                    }
                }
            }
        }

        public List<SetupPairViewModel> SetupPairs { get; set; }
    }


    public static class MultiSetupSetup
    {
        public static List<SetupPairViewModel> SetupList()
        {
            var pairs = new List<SetupPairViewModel>();
            for (int i = 0; i <= 15; i++)
            {
                var pair = new SetupPairViewModel(TrackNames[i]);

                UpdateSetup(pair.RaceSetup, i);
                UpdateSetup(pair.QualifyingSetup, i);

                pairs.Add(pair);
            }

            return pairs;
        }

        private static void UpdateSetup(SetupViewModel viewModel, int index)
        {
            viewModel.FrontWing = Wings[index];
            viewModel.RearWing = Wings[index];

            viewModel.GearRatio1 = GearRatios1[index];
            viewModel.GearRatio2 = GearRatios2[index];
            viewModel.GearRatio3 = GearRatios3[index];
            viewModel.GearRatio4 = GearRatios4[index];
            viewModel.GearRatio5 = GearRatios5[index];
            viewModel.GearRatio6 = GearRatios6[index];

            viewModel.TyreCompound = SetupTyreCompound.C;
        }

        private static readonly string[] TrackNames =
        {
            "Phoenix", "Interlagos", "Imola", "Monaco", "Montreal", "Mexico City", "Magny-Cours", "Silverstone",
            "Hockenheim", "Hungaroring", "Spa-Francorchamps", "Monza", "Estoril", "Barcelona", "Suzuka", "Adelaide"
        };

        private static readonly byte[] Wings =
        {
            48, 38, 38, 58, 37, 36, 39, 44, 18, 56, 37, 30, 36, 40, 44, 44
        };

        private static readonly byte[] GearRatios1 = { 23, 24, 24, 23, 24, 24, 24, 24, 24, 23, 24, 24, 24, 24, 24, 23 };
        private static readonly byte[] GearRatios2 = { 30, 32, 33, 30, 32, 33, 32, 33, 33, 30, 33, 33, 33, 32, 33, 30 };
        private static readonly byte[] GearRatios3 = { 37, 39, 40, 37, 39, 40, 39, 40, 40, 37, 40, 40, 40, 39, 40, 37 };
        private static readonly byte[] GearRatios4 = { 43, 46, 47, 43, 46, 47, 46, 48, 48, 43, 47, 48, 48, 46, 48, 43 };
        private static readonly byte[] GearRatios5 = { 51, 53, 55, 51, 53, 55, 53, 55, 57, 51, 55, 57, 55, 53, 55, 52 };
        private static readonly byte[] GearRatios6 = { 57, 60, 64, 57, 60, 64, 60, 62, 66, 57, 64, 66, 62, 60, 62, 61 };
    }
}
