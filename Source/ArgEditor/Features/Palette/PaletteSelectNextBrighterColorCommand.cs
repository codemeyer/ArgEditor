using ArgEditor.Infrastructure;

namespace ArgEditor.Features.Palette
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
