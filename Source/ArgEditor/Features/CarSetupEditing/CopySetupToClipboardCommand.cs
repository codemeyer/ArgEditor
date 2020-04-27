using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSetupEditing
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
