using Microsoft.Win32;

namespace ArgEditor.Features.Persistence
{
    public interface IFileDialog
    {
        string SelectCarSetFileToOpen();
        string SelectCarSetFileToSave();
        string SelectLegacyCarFileToOpen();
        string SelectLegacyCarSetFileToSave();
        string SelectLegacyHelmetFileToOpen();
        string SelectGpExeFile();
        string SelectDatFileToOpen();
        string SelectAnyFileToOpen();
        string SelectAnyFileToSave();
        string SelectNameFileToSave();
        string SelectImageFileToOpen();
        string SelectImageFileToSave();
    }

    public class FileDialog : IFileDialog
    {
        public string SelectCarSetFileToOpen()
        {
            var fileDialog = new OpenFileDialog
            {
                DefaultExt = ".arged",
                Filter = "Car Sets (*.arged, *.1ed)|*.arged;*.1ed|ArgEditor files (*.arged)|*.arged|F1Ed files (*.1ed)|*.1ed|All files (*.*)|*.*",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectCarSetFileToSave()
        {
            var fileDialog = new SaveFileDialog
            {
                Title = "Save Car Set As",
                DefaultExt = ".arged",
                Filter = "ArgEditor car set (*.arged)|*.arged|F1Ed car set (*.1ed)|*.1ed",
                //FileName = "*.arged",
                CheckFileExists = false
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectLegacyCarSetFileToSave()
        {
            var fileDialog = new SaveFileDialog
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
            var fileDialog = new OpenFileDialog
            {
                Title = "Select EXE File",
                DefaultExt = ".exe",
                Filter = "EXE files (*.exe)|.exe|All files (*.*)|*.*",
                FileName = "*.exe",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectDatFileToOpen()
        {
            var fileDialog = new OpenFileDialog
            {
                Title = "Select DAT File",
                DefaultExt = ".*",
                Filter = "DAT files (*.dat)|.dat|All files (*.*)|*.*",
                FileName = "*.dat",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectAnyFileToOpen()
        {
            var fileDialog = new OpenFileDialog
            {
                Title = "Select File",
                DefaultExt = ".*",
                Filter = "All files (*.*)|*.*",
                FileName = "*.*",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectAnyFileToSave()
        {
            var fileDialog = new SaveFileDialog
            {
                Title = "Select File",
                DefaultExt = "",
                Filter = "All files (*.*)|*.*",
                FileName = "*",
                AddExtension = false
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectNameFileToSave()
        {
            var fileDialog = new SaveFileDialog
            {
                Title = "Select Name File",
                DefaultExt = "",
                Filter = "All files (*.*)|*.*",
                FileName = "*",
                AddExtension = false
            };

            return GetFilePathFromDialog(fileDialog);
        }


        public string SelectLegacyCarFileToOpen()
        {
            var fileDialog = new OpenFileDialog
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
            var fileDialog = new OpenFileDialog
            {
                Title = "Select Helmet File",
                DefaultExt = ".hel",
                Filter = "HEL File (*.hel)|*.hel|All files (*.*)|*.*",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectImageFileToOpen()
        {
            var fileDialog = new OpenFileDialog
            {
                Title = "Select Image File",
                DefaultExt = ".*",
                Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png;*.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif;|All files (*.*)|*.*",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public string SelectImageFileToSave()
        {
            var fileDialog = new SaveFileDialog
            {
                Title = "Save Menu Image File",
                DefaultExt = ".png",
                Filter = "PNG Image File (*.png)|*.png",
                CheckFileExists = false
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
