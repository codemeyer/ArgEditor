using ArgEditor.Mappers;
using ArgEditor.ViewModels;

namespace ArgEditor.Commands
{
    public class CopyHelmetToClipboardCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var helmet = parameter as HelmetViewModel;

            if (helmet == null)
                return;

            if (App.ClipboardHelmet == null)
            {
                App.ClipboardHelmet = new HelmetViewModel(null);  // ?
            }

            Mapper.MapHelmetViewModel(helmet, App.ClipboardHelmet);
        }
    }
}
