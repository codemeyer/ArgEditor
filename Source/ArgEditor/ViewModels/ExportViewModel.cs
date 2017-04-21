using System.IO;
using System.Linq;
using System.Windows;
using ArgData;

namespace ArgEditor.ViewModels
{
    public class ExportViewModel : ImportExportViewModel
    {
        // TODO: more stuff that can be pushed into base?

        public ExportViewModel(MainViewModel parent)
        {
            Parent = parent;
            UpdateInterface();

            ApplyNameFile = true;
            SelectedNameFilePath = "gpsaves/argedit.nam";
            AutoLoadNameFile = true;
        }

        public ExportViewModel()
        {
        }

        public MainViewModel Parent { get; }

        protected override void UpdateInterface()
        {
            if (!File.Exists(SelectedExeFilePath))
            {
                UpdateFileVersionMessage(null);
                CanExport = false;
                return;
            }

            var exeInfo = GpExeFile.GetFileInfo(SelectedExeFilePath);

            if (exeInfo.IsEditingSupported)
            {
                CanExport = true;

                if (ApplyNameFile && string.IsNullOrWhiteSpace(SelectedNameFilePath))
                {
                    CanExport = false;
                }
            }
            else
            {
                CanExport = false;
            }

            UpdateFileVersionMessage(exeInfo);

            UpdateEnoughActiveDrivers();
            UpdatePointsSystemWarning();
            UpdateAutoLoadNameFileWarning();
        }

        private void UpdateEnoughActiveDrivers()
        {
            var status = ExportValidator.CanExportToExe(Parent);

            if (status == CanExportToExeStatus.SharedDriverNumbers)
            {
                ShowDriverNumbersWarning = Visibility.Visible;
                ShowDriverNumbersWarningMessage = "Each active driver must have a unique number!";
                CanExport = false;
                return;
            }

            if (status == CanExportToExeStatus.TooFewActiveDrivers)
            {
                ShowDriverNumbersWarning = Visibility.Visible;
                ShowDriverNumbersWarningMessage = "There must be at least 26 active drivers!";
                CanExport = false;
                return;
            }

            ShowDriverNumbersWarning = Visibility.Hidden;
            ShowDriverNumbersWarningMessage = string.Empty;
        }



        private bool _canExport;

        public bool CanExport
        {
            get { return _canExport; }
            set
            {
                if (value.Equals(_canExport)) return;

                _canExport = value;
                OnPropertyChanged(nameof(CanExport));
            }
        }

        private bool _autoLoadNameFile;

        public bool AutoLoadNameFile
        {
            get { return _autoLoadNameFile; }
            set
            {
                if (value.Equals(_autoLoadNameFile)) return;

                _autoLoadNameFile = value;
                OnPropertyChanged(nameof(AutoLoadNameFile));
                UpdateAutoLoadNameFileWarning();
            }
        }

        private void UpdatePointsSystemWarning()
        {
            ShowPointsSystemWarning = Visibility.Hidden;
            ShowPointsSystemWarningMessage = string.Empty;

            if (!string.IsNullOrEmpty(SelectedExeFilePath))
            {
                var exeInfo = GpExeFile.GetFileInfo(SelectedExeFilePath);
                if (exeInfo.IsEditingSupported && !exeInfo.IsDecompressed)
                {
                    if (Parent.PointsSystem.NeedsDecompressedExe())
                    {
                        ShowPointsSystemWarning = Visibility.Visible;
                        ShowPointsSystemWarningMessage =
                            "The current points system needs a decompressed EXE for full support! " +
                            "You can still export to the specified EXE file, " +
                            "but only the top six finishers will score points.";
                    }
                }
            }
        }


        private void UpdateAutoLoadNameFileWarning()
        {
            ShowAutoLoadNameFileWarning = Visibility.Hidden;
            ShowAutoLoadNameFileWarningMessage = string.Empty;

            if (ApplyNameFile && string.IsNullOrEmpty(SelectedNameFilePath))
            {
                ShowAutoLoadNameFileWarning = Visibility.Visible;
                ShowAutoLoadNameFileWarningMessage = "You must set a path for the name file";
                CanExport = false;
            }

            if (ApplyNameFile && !string.IsNullOrEmpty(SelectedNameFilePath) && AutoLoadNameFile)
            {
                if (Path.IsPathRooted(SelectedNameFilePath))
                {
                    ShowAutoLoadNameFileWarning = Visibility.Visible;
                    ShowAutoLoadNameFileWarningMessage = "The path for an auto-loaded name file must be relative to the specified GP.EXE, e.g. gpsaves/argedit.nam";
                    CanExport = false;
                }
            }
        }


        private Visibility _showDriverNumbersWarning = Visibility.Hidden;

        public Visibility ShowDriverNumbersWarning
        {
            get { return _showDriverNumbersWarning; }
            set
            {
                if (value.Equals(_showDriverNumbersWarning)) return;

                _showDriverNumbersWarning = value;
                OnPropertyChanged(nameof(ShowDriverNumbersWarning));
            }
        }

        private string _showDriverNumbersWarningMessage;

        public string ShowDriverNumbersWarningMessage
        {
            get { return _showDriverNumbersWarningMessage; }
            set
            {
                if (value.Equals(_showDriverNumbersWarningMessage)) return;

                _showDriverNumbersWarningMessage = value;
                OnPropertyChanged(nameof(ShowDriverNumbersWarningMessage));
            }
        }

        private Visibility _showPointsSystemWarning = Visibility.Hidden;

        public Visibility ShowPointsSystemWarning
        {
            get { return _showPointsSystemWarning; }
            set
            {
                if (value.Equals(_showPointsSystemWarning)) return;

                _showPointsSystemWarning = value;
                OnPropertyChanged(nameof(ShowPointsSystemWarning));
            }
        }

        private string _showPointsSystemWarningMessage;

        public string ShowPointsSystemWarningMessage
        {
            get { return _showPointsSystemWarningMessage; }
            set
            {
                if (value.Equals(_showPointsSystemWarningMessage)) return;

                _showPointsSystemWarningMessage = value;
                OnPropertyChanged(nameof(ShowPointsSystemWarningMessage));
            }
        }


        private Visibility _showAutoLoadNameFileWarning = Visibility.Hidden;

        public Visibility ShowAutoLoadNameFileWarning
        {
            get { return _showAutoLoadNameFileWarning; }
            set
            {
                if (value.Equals(_showAutoLoadNameFileWarning)) return;

                _showAutoLoadNameFileWarning = value;
                OnPropertyChanged(nameof(ShowAutoLoadNameFileWarning));
            }
        }

        private string _showAutoLoadNameFileWarningMessage;

        public string ShowAutoLoadNameFileWarningMessage
        {
            get { return _showAutoLoadNameFileWarningMessage; }
            set
            {
                if (value.Equals(_showAutoLoadNameFileWarningMessage)) return;

                _showAutoLoadNameFileWarningMessage = value;
                OnPropertyChanged(nameof(ShowAutoLoadNameFileWarningMessage));
            }
        }
    }
}
