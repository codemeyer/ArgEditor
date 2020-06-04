using System.Linq;
using ArgEditor.Features.CarSet.CarColors;
using ArgEditor.Features.Main;
using ArgEditor.Features.Persistence;
using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSet.HelmetColors
{
    public class BrowseHelmetColorsCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public BrowseHelmetColorsCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var helmet = parameter as HelmetViewModel;

            if (helmet == null)
                return;

            var viewModel = new BrowseHelmetColorsViewModel(_fileDialog);

            if (App.LatestBrowseHelmetColorsViewModel != null)
            {
                viewModel = App.LatestBrowseHelmetColorsViewModel;
                viewModel.SelectedHelmet = null;
            }

            var window = new BrowseHelmetColorsWindow
            {
                Owner = System.Windows.Application.Current.MainWindow,
                DataContext = viewModel
            };

            var result = window.ShowDialog();

            if (result == true)
            {
                if (viewModel.SelectedHelmet != null)
                {
                    var colorChangeList = HelmetColorChangeCreator.CreateColorChangeListForHelmetPasteOperation(helmet, viewModel.SelectedHelmet);

                    int index = -1;
                    foreach (var driver in MainViewModelPasserArounder.MainViewModel.Drivers)
                    {
                        if (helmet == driver.Helmet)
                        {
                            index = MainViewModelPasserArounder.MainViewModel.Drivers.IndexOf(driver);
                        }
                    }

                    if (index > -1)
                    {
                        App.HelmetColorUndoStacks[index].Push(colorChangeList);
                        App.HelmetColorRedoStacks[index].Clear();
                    }

                    Mapper.MapHelmetViewModel(viewModel.SelectedHelmet, helmet);
                }
            }

            if (!string.IsNullOrEmpty(viewModel.FilePath))
            {
                // remember this
                App.LatestBrowseHelmetColorsViewModel = viewModel;
            }
        }
    }
}
