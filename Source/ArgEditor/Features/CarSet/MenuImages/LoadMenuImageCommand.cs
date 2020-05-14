using System.Linq;
using ArgEditor.Features.Main;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.MenuImages
{
    public class LoadMenuImageCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var menuImageViewModel = parameter as MenuImageViewModel;

            if (menuImageViewModel == null)
            {
                return;
            }

            var loadViewModel = new LoadMenuImageViewModel();

            var window = new MenuImageImportWindow
            {
                Owner = System.Windows.Application.Current.MainWindow,
                DataContext = loadViewModel
            };

            var result = window.ShowDialog();

            if (result == true)
            {
                int index = MainViewModelPasserArounder.MainViewModel.Drivers.Select(t => t.MenuImage).ToList().IndexOf(menuImageViewModel);
                var pixelChange = new PixelDataChange
                {
                    OldValue = menuImageViewModel.PixelData,
                    NewValue = loadViewModel.PixelData
                };
                App.MenuImageUndoStacks[index].Push(pixelChange);
                App.MenuImageRedoStacks[index].Clear();

                menuImageViewModel.PixelData = loadViewModel.PixelData;
                menuImageViewModel.Image = loadViewModel.InGameImage;
                menuImageViewModel.MagnifiedImage = loadViewModel.InGameMagnifiedImage;
            }
        }
    }
}
