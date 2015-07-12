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
                Filter = "ArgEditor files (*.arged)|.arged|All files (*.*)|*.*",
                FileName = "*.arged",
                CheckFileExists = true
            };

            return GetFilePathFromDialog(fileDialog);
        }

        public static string SelectArgEditorFileToSave()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                DefaultExt = ".arged",
                Filter = "ArgEditor files (*.arged)|.arged|All files (*.*)|*.*",
                FileName = "*.arged",
                CheckFileExists = false     //?
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

        private static string GetFilePathFromDialog(OpenFileDialog fileDialog)
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