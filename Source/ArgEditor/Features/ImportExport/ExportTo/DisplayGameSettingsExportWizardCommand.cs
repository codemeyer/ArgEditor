using ArgEditor.Features.Main;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.ImportExport.ExportTo
{
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
                Owner = System.Windows.Application.Current.MainWindow,
                DataContext = exportVM
            };

            exportWindow.ShowDialog();
        }
    }
}
