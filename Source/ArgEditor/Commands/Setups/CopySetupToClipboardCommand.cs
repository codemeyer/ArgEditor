using ArgEditor.Mappers;
using ArgEditor.ViewModels;

namespace ArgEditor.Commands.Setups
{
    public class CopySetupToClipboardCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var setup = parameter as SetupViewModel;

            if (setup == null)
                return;

            if (App.ClipboardSetup == null)
            {
                App.ClipboardSetup = new SetupViewModel();
            }

            Mapper.MapCarSetupViewModel(setup, App.ClipboardSetup);
        }
    }
}
