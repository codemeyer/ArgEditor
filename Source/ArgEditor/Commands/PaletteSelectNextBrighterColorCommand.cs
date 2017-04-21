using ArgEditor.ViewModels;

namespace ArgEditor.Commands
{
    public class PaletteSelectNextBrighterColorCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var palette = parameter as PaletteViewModel;

            palette?.SelectNextBrighterColor();
        }
    }
}
