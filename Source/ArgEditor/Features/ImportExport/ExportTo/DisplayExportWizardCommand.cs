using ArgEditor.Features.Main;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.ImportExport.ExportTo
{
    public class DisplayExportWizardCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            var exportViewModel = App.LatestExportViewModel == null
                ? new ExportViewModel(viewModel)
                : App.LatestExportViewModel;

            var exportWindow = new ExportWindow
            {
                Owner = System.Windows.Application.Current.MainWindow,
                DataContext = exportViewModel
            };

            exportWindow.ShowDialog();
        }
    }
}
