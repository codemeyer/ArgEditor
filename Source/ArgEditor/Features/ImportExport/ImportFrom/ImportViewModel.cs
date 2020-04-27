using System.IO;
using ArgData;
using ArgEditor.Features.Main;

namespace ArgEditor.Features.ImportExport.ImportFrom
{
    public class ImportViewModel : ImportExportViewModel
    {
        // TODO: more stuff that can be pushed into base?

        public ImportViewModel(MainViewModel parent)
        {
            Parent = parent;
            UpdateInterface();
        }

        public ImportViewModel()
        {
        }

        public MainViewModel Parent { get; }

        private bool _canImport;


        // TODO: name :)
        protected override void UpdateInterface()
        {
            if (!File.Exists(SelectedExeFilePath))
            {
                UpdateFileVersionMessage(null);
                UpdateDriverNumberRelatedSettingsWarning();
                CanImport = false;
                return;
            }

            var exeInfo = GpExeFile.GetFileInfo(SelectedExeFilePath);

            if (exeInfo.IsEditingSupported)
            {
                CanImport = true;

                if (ApplyNameFile && string.IsNullOrWhiteSpace(SelectedNameFilePath))
                {
                    CanImport = false;
                }
            }
            else
            {
                CanImport = false;
            }

            UpdateFileVersionMessage(exeInfo);
            UpdateDriverNumberRelatedSettingsWarning();
        }


        public bool CanImport
        {
            get { return _canImport; }
            set
            {
                if (value.Equals(_canImport)) return;

                _canImport = value;
                OnPropertyChanged(nameof(CanImport));
            }
        }
    }
}
