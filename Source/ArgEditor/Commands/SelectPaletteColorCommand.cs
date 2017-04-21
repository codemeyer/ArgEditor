using ArgEditor.ViewModels;

namespace ArgEditor.Commands
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
