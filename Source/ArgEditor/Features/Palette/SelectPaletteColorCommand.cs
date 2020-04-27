using ArgEditor.Infrastructure;

namespace ArgEditor.Features.Palette
{
    public class SelectPaletteColorCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var paletteColor = parameter as PaletteColorViewModel;

            paletteColor.Parent.SelectedColor = paletteColor.ColorIndex;
        }
    }
}
