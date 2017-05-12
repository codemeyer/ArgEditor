using System.Windows;
using ArgEditor.ViewModels;
using ArgEditor.Windows;

namespace ArgEditor.Commands
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
                Owner = Application.Current.MainWindow,
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
                Owner = Application.Current.MainWindow,
                DataContext = importVM
            };

            importWindow.ShowDialog();
        }
    }
}
