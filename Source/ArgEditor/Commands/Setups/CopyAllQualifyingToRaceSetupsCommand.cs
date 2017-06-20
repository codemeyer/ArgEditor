using ArgEditor.Mappers;
using ArgEditor.ViewModels;

namespace ArgEditor.Commands.Setups
{
    public class CopyAllQualifyingToRaceSetupsCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MultiSetupViewModel;

            if (viewModel == null) { return; }

            foreach (var pair in viewModel.SetupPairs)
            {
                Mapper.MapCarSetupViewModel(pair.QualifyingSetup, pair.RaceSetup);
            }
        }
    }
}
