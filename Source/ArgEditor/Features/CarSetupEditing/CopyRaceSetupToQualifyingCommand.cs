using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSetupEditing
{
    public class CopyRaceSetupToQualifyingCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as SetupPairViewModel;

            if (viewModel == null) { return; }

            Mapper.MapCarSetupViewModel(viewModel.RaceSetup, viewModel.QualifyingSetup);
        }
    }
}
