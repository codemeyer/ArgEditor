using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSet.HelmetColors
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
