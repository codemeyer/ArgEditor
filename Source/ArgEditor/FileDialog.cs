using Microsoft.Win32;

namespace ArgEditor
{
    public static class FileDialog
    {
        // TODO: more refactoring?

        public static string SelectArgEditorFileToOpen()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                DefaultExt = ".arged",
                Filter = "Car Sets (*.arged, *.1ed)|*.arged;*.1ed|ArgEditor files (*.arged)|*.arged|F1Ed files (*.1ed)|*.1ed|All files (*.*)|*.*",
                //FileName = "*.arged",
                //DefaultExt = ".arged",
                //Filter = "ArgEditor files (*.arged)|.arged|All files (*.*)|*.*",
                //FileName = "*.arged",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public static string SelectArgEditorFileToSave()
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                DefaultExt = ".arged",
                Filter = "ArgEditor files (*.arged)|.arged|All files (*.*)|*.*",
                FileName = "*.arged",
                CheckFileExists = false
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public static string SelectF1edFileToSave()
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                DefaultExt = ".1ed",
                Filter = "F1Ed files (*.1ed)|*.1ed|All files (*.*)|*.*",
                FileName = "*.1ed",
                CheckFileExists = false
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public static string SelectGpExe()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                DefaultExt = ".exe",
                Filter = "EXE files (*.exe)|.exe|All files (*.*)|*.*",
                FileName = "*.exe",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public static string SelectAnyFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                DefaultExt = ".*",
                Filter = "All files (*.*)|*.*",
                FileName = "*.*",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public static string SelectNameFileToSave()
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                DefaultExt = ".*",
                Filter = "All files (*.*)|*.*",
                FileName = "*.*"
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