using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSetupEditing
{
    public class CopyAllRaceToQualifyingSetupsCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MultiSetupViewModel;

            if (viewModel == null) { return; }

            foreach (var pair in viewModel.SetupPairs)
            {
                Mapper.MapCarSetupViewModel(pair.RaceSetup, pair.QualifyingSetup);
            }
        }
    }
}
