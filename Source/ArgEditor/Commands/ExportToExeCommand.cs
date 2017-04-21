using ArgEditor.Interactors;
using ArgEditor.ViewModels;
using System;

namespace ArgEditor.Commands
{
    public class ExportToExeCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public ExportToExeCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel == null) return;

            var canExport = ExportValidator.CanExportToExe(viewModel);

            if (canExport != CanExportToExeStatus.OK)
            {
                var message = ExportValidator.GetMessageForStatus(canExport);
                viewModel.ShowWarningMessageCommand.Execute(message);

                return;
            }

            string path = _fileDialog.SelectGpExeFile();

            if (string.IsNullOrEmpty(path)) { return; }

            var fileExporter = new GpExeFileWriter();

            try
            {
                fileExporter.WriteViewModelToExe(viewModel, path);
            }
            catch (Exception)
            {
                // TODO: log?
                viewModel.ShowErrorMessageCommand.Execute("An error occurred when exporting data. Please try again!");
            }
        }
    }
}
