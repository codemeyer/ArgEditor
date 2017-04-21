using Microsoft.Win32;

namespace ArgEditor
{
    public interface IFileDialog
    {
        string SelectCarSetFileToOpen();
        string SelectCarSetFileToSave();
        string SelectLegacyCarFileToOpen();
        string SelectLegacyCarSetFileToSave();
        string SelectLegacyHelmetFileToOpen();
        string SelectGpExeFile();
        string SelectAnyFile();
        string SelectNameFileToSave();
    }

    public class FileDialog : IFileDialog
    {
        // TODO: more refactoring?

        public string SelectCarSetFileToOpen()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                DefaultExt = ".arged",
                Filter = "Car Sets (*.arged, *.1ed)|*.arged;*.1ed|ArgEditor files (*.arged)|*.arged|F1Ed files (*.1ed)|*.1ed|All files (*.*)|*.*",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectCarSetFileToSave()
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Title = "Save Car Set As",
                DefaultExt = ".arged",
                Filter = "ArgEditor files (*.arged)|.arged|All files (*.*)|*.*",
                FileName = "*.arged",
                CheckFileExists = false
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectLegacyCarSetFileToSave()
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Title = "Save Legacy Car Set As",
                DefaultExt = ".1ed",
                Filter = "F1Ed files (*.1ed)|*.1ed|All files (*.*)|*.*",
                FileName = "*.1ed",
                CheckFileExists = false
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectGpExeFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = "Select EXE File",
                DefaultExt = ".exe",
                Filter = "EXE files (*.exe)|.exe|All files (*.*)|*.*",
                FileName = "*.exe",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectAnyFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = "Select File",
                DefaultExt = ".*",
                Filter = "All files (*.*)|*.*",
                FileName = "*.*",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectNameFileToSave()
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Title = "Select Name File",
                DefaultExt = ".*",
                Filter = "All files (*.*)|*.*",
                FileName = "*.*"
            };

            return GetFilePathFromDialog(fileDialog);
        }


        public string SelectLegacyCarFileToOpen()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = "Select Car File",
                DefaultExt = ".car",
                Filter = "CAR File (*.car)|*.car|All files (*.*)|*.*",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectLegacyHelmetFileToOpen()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = "Select Helmet File",
                DefaultExt = ".hel",
                Filter = "HEL File (*.hel)|*.hel|All files (*.*)|*.*",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }


        private static string GetFilePathFromDialog(OpenFileDialog fileDialog)
        {
            bool? result = fileDialog.ShowDialog();

            if (result == true)
            {
                return fileDialog.FileName;
            }

            return string.Empty;
        }

        private static string GetFilePathFromDialog(SaveFileDialog fileDialog)
        {
            bool? result = fileDialog.ShowDialog();

            if (result == true)
            {
                return fileDialog.FileName;
            }

            return string.Empty;
        }
    }
}
