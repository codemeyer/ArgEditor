using ArgEditor.Features.Main;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.ImportExport.ImportFrom
{
    public class DisplayImportWizardCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            var importViewModel = App.LatestImportViewModel == null
                ? new ImportViewModel(viewModel)
                : App.LatestImportViewModel;

            var importWindow = new ImportWindow
            {
                Owner = System.Windows.Application.Current.MainWindow,
                DataContext = importViewModel
            };

            importWindow.ShowDialog();
        }
    }

    public class DisplayGameSettingsImportWizardCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            var importVM = new ImportViewModel(viewModel);
            importVM.SetAllCarSetCheckBoxes(false);

            var importWindow = new ImportWindow
            {
                Owner = System.Windows.Application.Current.MainWindow,
                DataContext = importVM
            };

            importWindow.ShowDialog();
        }
    }
}
