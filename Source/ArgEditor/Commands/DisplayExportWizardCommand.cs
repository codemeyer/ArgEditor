using System.Windows;
using ArgEditor.ViewModels;
using ArgEditor.Windows;

namespace ArgEditor.Commands
{
    public class DisplayExportWizardCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            var exportWindow = new ExportWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = new ExportViewModel(viewModel)
            };

            exportWindow.ShowDialog();
        }
    }

    public class DisplayGameSettingsExportWizardCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            var exportVM = new ExportViewModel(viewModel);
            exportVM.SetAllCarSetCheckBoxes(false);
            exportVM.ApplyNameFile = false;
            exportVM.SelectedNameFilePath = string.Empty;
            exportVM.AutoLoadNameFile = false;

            var exportWindow = new ExportWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = exportVM
            };

            exportWindow.ShowDialog();
        }
    }
}
