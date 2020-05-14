using System.IO;
using System.Windows;
using ArgData;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.ImportExport
{
    public abstract class ImportExportViewModel : BaseViewModel
    {
        private string _selectedExeFilePath;

        public string SelectedExeFilePath
        {
            get { return _selectedExeFilePath; }
            set
            {
                if (value.Equals(_selectedExeFilePath)) return;

                _selectedExeFilePath = value;
                OnPropertyChanged(nameof(SelectedExeFilePath));
                UpdateInterface();
                UpdateMenuImagesPath();
            }
        }



        private void UpdateMenuImagesPath()
        {
            if (!File.Exists(SelectedExeFilePath))
            {
                return;
            }

            // not if we don't want images
            if (!ApplyMenuImages)
            {
                return;
            }

            // do not overwrite
            if (!string.IsNullOrEmpty(SelectedMenuImageFilePath))
            {
                return;
            }

            var dir = Path.GetDirectoryName(SelectedExeFilePath);

            var newPath = Path.Combine(dir, "HELMETS.DAT");

            if (File.Exists(newPath))
            {
                SelectedMenuImageFilePath = newPath;
            }
        }


        protected abstract void UpdateInterface();


        protected void UpdateFileVersionMessage(GpExeInfo exeInfo)
        {
            if (exeInfo == null)
            {
                FileVersionMessage = "";
                return;
            }

            switch (exeInfo.Version)
            {
                case GpExeVersionInfo.Unknown:
                    FileVersionMessage = "Unknown version or not a GP.EXE file";
                    break;
                case GpExeVersionInfo.European103:
                    FileVersionMessage = "European 1.03 (Unsupported)";
                    break;
                case GpExeVersionInfo.European105:
                    FileVersionMessage = "European 1.05";
                    break;
                case GpExeVersionInfo.European105Decompressed:
                    FileVersionMessage = "European 1.05 (Decompressed)";
                    break;
                case GpExeVersionInfo.Us103:
                    FileVersionMessage = "US World Circuit 1.03 (Unsupported)";
                    break;
                case GpExeVersionInfo.Us105:
                    FileVersionMessage = "US World Circuit 1.05";
                    break;
                case GpExeVersionInfo.Us105Decompressed:
                    FileVersionMessage = "US World Circuit 1.05 (Decompressed)";
                    break;
            }
        }


        private string _fileVersionMessage;

        public string FileVersionMessage
        {
            get { return _fileVersionMessage; }
            set
            {
                if (value.Equals(_fileVersionMessage)) return;

                _fileVersionMessage = value;
                OnPropertyChanged(nameof(FileVersionMessage));
            }
        }



        public void SetAllCarSetCheckBoxes(bool value)
        {
            ApplyCarColors = value;
            ApplyTeamHorsepower = value;
            ApplyDriverNumbers = value;
            ApplyDriverPerformanceValues = value;
            ApplyPitCrewColors = value;
            ApplyHelmetColors = value;
            ApplyMenuImages = value;
            ApplyPointsSystem = value;
        }



        private bool _applyCarColors = true;

        public bool ApplyCarColors
        {
            get { return _applyCarColors; }
            set
            {
                if (value.Equals(_applyCarColors)) return;

                _applyCarColors = value;
                OnPropertyChanged(nameof(ApplyCarColors));
            }
        }

        private bool _applyTeamHorsepower = true;

        public bool ApplyTeamHorsepower
        {
            get { return _applyTeamHorsepower; }
            set
            {
                if (value.Equals(_applyTeamHorsepower)) return;

                _applyTeamHorsepower = value;
                OnPropertyChanged(nameof(ApplyTeamHorsepower));
            }
        }

        private bool _applyDriverNumbers = true;

        public bool ApplyDriverNumbers
        {
            get { return _applyDriverNumbers; }
            set
            {
                if (value.Equals(_applyDriverNumbers)) return;

                _applyDriverNumbers = value;
                OnPropertyChanged(nameof(ApplyDriverNumbers));
                UpdateInterface();
            }
        }

        private bool _applyDriverPerformanceValues = true;

        public bool ApplyDriverPerformanceValues
        {
            get { return _applyDriverPerformanceValues; }
            set
            {
                if (value.Equals(_applyDriverPerformanceValues)) return;

                _applyDriverPerformanceValues = value;
                OnPropertyChanged(nameof(ApplyDriverPerformanceValues));
                UpdateInterface();
            }
        }


        private bool _applyPitCrewColors = true;

        public bool ApplyPitCrewColors
        {
            get { return _applyPitCrewColors; }
            set
            {
                if (value.Equals(_applyPitCrewColors)) return;

                _applyPitCrewColors = value;
                OnPropertyChanged(nameof(ApplyPitCrewColors));
            }
        }


        private bool _applyHelmetColors = true;

        public bool ApplyHelmetColors
        {
            get { return _applyHelmetColors; }
            set
            {
                if (value.Equals(_applyHelmetColors)) return;

                _applyHelmetColors = value;
                OnPropertyChanged(nameof(ApplyHelmetColors));
                UpdateInterface();
            }
        }


        private bool _applyMenuImages = true;

        public bool ApplyMenuImages
        {
            get { return _applyMenuImages; }
            set
            {
                if (value.Equals(_applyMenuImages)) return;

                _applyMenuImages = value;
                OnPropertyChanged(nameof(ApplyMenuImages));
                UpdateInterface();
            }
        }


        private string _selectedMenuImageFilePath;

        public string SelectedMenuImageFilePath
        {
            get { return _selectedMenuImageFilePath; }
            set
            {
                if (value.Equals(_selectedMenuImageFilePath)) return;

                _selectedMenuImageFilePath = value;
                OnPropertyChanged(nameof(SelectedMenuImageFilePath));
                UpdateInterface();
            }
        }



        private bool _applyPointsSystem = true;

        public bool ApplyPointsSystem
        {
            get { return _applyPointsSystem; }
            set
            {
                if (value.Equals(_applyPointsSystem)) return;

                _applyPointsSystem = value;
                OnPropertyChanged(nameof(ApplyPointsSystem));
            }
        }


        public void SetAllGameSettingsCheckBoxes(bool value)
        {
            ApplyPlayerHorsepowerValue = value;
            ApplyGeneralAIGrip = value;
            ApplyWeatherSettings = value;
            ApplyDamageSettings = value;
        }

        private bool _applyPlayerHorsepowerValue = true;

        public bool ApplyPlayerHorsepowerValue
        {
            get { return _applyPlayerHorsepowerValue; }
            set
            {
                if (value.Equals(_applyPlayerHorsepowerValue)) return;

                _applyPlayerHorsepowerValue = value;
                OnPropertyChanged(nameof(ApplyPlayerHorsepowerValue));
            }
        }

        private bool _applyGeneralAIGrip = true;

        public bool ApplyGeneralAIGrip
        {
            get { return _applyGeneralAIGrip; }
            set
            {
                if (value.Equals(_applyGeneralAIGrip)) return;

                _applyGeneralAIGrip = value;
                OnPropertyChanged(nameof(ApplyGeneralAIGrip));
            }
        }

        private bool _applyWeatherSettings = true;

        public bool ApplyWeatherSettings
        {
            get { return _applyWeatherSettings; }
            set
            {
                if (value.Equals(_applyWeatherSettings)) return;

                _applyWeatherSettings = value;
                OnPropertyChanged(nameof(ApplyWeatherSettings));
            }
        }

        private bool _applyDamageSettings = true;

        public bool ApplyDamageSettings
        {
            get { return _applyDamageSettings; }
            set
            {
                if (value.Equals(_applyDamageSettings)) return;

                _applyDamageSettings = value;
                OnPropertyChanged(nameof(ApplyDamageSettings));
            }
        }

        private bool _applyNameFile;

        public bool ApplyNameFile
        {
            get { return _applyNameFile; }
            set
            {
                if (value.Equals(_applyNameFile)) return;

                _applyNameFile = value;
                OnPropertyChanged(nameof(ApplyNameFile));
                UpdateInterface();
            }
        }

        private string _selectedNameFilePath;

        public string SelectedNameFilePath
        {
            get { return _selectedNameFilePath; }
            set
            {
                if (value.Equals(_selectedNameFilePath)) return;

                _selectedNameFilePath = value;
                OnPropertyChanged(nameof(SelectedNameFilePath));
                UpdateInterface();
            }
        }




        protected void UpdateDriverNumberRelatedSettingsWarning()
        {
            ShowDriverNumberRelatedPerformanceWarning = Visibility.Hidden;
            ShowDriverNumberRelatedPerformanceWarningMessage = string.Empty;

            if (!ApplyDriverNumbers && ApplyDriverPerformanceValues)
            {
                ShowDriverNumberRelatedPerformanceWarning = Visibility.Visible;
                ShowDriverNumberRelatedPerformanceWarningMessage = "Performance values are dependent on driver numbers. Importing or exporting performance values but not driver numbers may result in unexpected behavior.";
            }

            ShowDriverNumberRelatedHelmetColorsWarning = Visibility.Hidden;
            ShowDriverNumberRelatedHelmetColorsWarningMessage = string.Empty;

            if (!ApplyDriverNumbers && ApplyHelmetColors)
            {
                ShowDriverNumberRelatedHelmetColorsWarning = Visibility.Visible;
                ShowDriverNumberRelatedHelmetColorsWarningMessage = "Helmet colors are dependent on driver numbers. Importing or exporting helmet colors but not driver numbers may result in unexpected behavior.";
            }

            ShowDriverNumberRelatedMenuImagesWarning = Visibility.Hidden;
            ShowDriverNumberRelatedMenuImagesWarningMessage = string.Empty;

            if (!ApplyDriverNumbers && ApplyMenuImages)
            {
                ShowDriverNumberRelatedMenuImagesWarning = Visibility.Visible;
                ShowDriverNumberRelatedMenuImagesWarningMessage = "Menu images are dependent on driver numbers. Importing or exporting menu images but not driver numbers may result in unexpected behavior.";
            }
        }



        private Visibility _showDriverNumberRelatedPerformanceWarning = Visibility.Hidden;

        public Visibility ShowDriverNumberRelatedPerformanceWarning
        {
            get { return _showDriverNumberRelatedPerformanceWarning; }
            set
            {
                SetProperty(ref _showDriverNumberRelatedPerformanceWarning, value,
                    () => ShowDriverNumberRelatedPerformanceWarning);
            }
        }

        private string _showDriverNumberRelatedPerformanceWarningMessage;

        public string ShowDriverNumberRelatedPerformanceWarningMessage
        {
            get { return _showDriverNumberRelatedPerformanceWarningMessage; }
            set
            {
                SetProperty(ref _showDriverNumberRelatedPerformanceWarningMessage, value,
                    () => ShowDriverNumberRelatedPerformanceWarningMessage);
            }
        }

        private Visibility _showDriverNumberRelatedHelmetColorsWarning = Visibility.Hidden;

        public Visibility ShowDriverNumberRelatedHelmetColorsWarning
        {
            get { return _showDriverNumberRelatedHelmetColorsWarning; }
            set
            {
                SetProperty(ref _showDriverNumberRelatedHelmetColorsWarning, value,
                    () => ShowDriverNumberRelatedHelmetColorsWarning);
            }
        }

        private string _showDriverNumberRelatedHelmetColorsWarningMessage;

        public string ShowDriverNumberRelatedHelmetColorsWarningMessage
        {
            get { return _showDriverNumberRelatedHelmetColorsWarningMessage; }
            set
            {
                SetProperty(ref _showDriverNumberRelatedHelmetColorsWarningMessage, value,
                    () => ShowDriverNumberRelatedHelmetColorsWarningMessage);
            }
        }


        private Visibility _showDriverNumberRelatedMenuImagesWarning = Visibility.Hidden;

        public Visibility ShowDriverNumberRelatedMenuImagesWarning
        {
            get { return _showDriverNumberRelatedMenuImagesWarning; }
            set
            {
                SetProperty(ref _showDriverNumberRelatedMenuImagesWarning, value,
                    () => ShowDriverNumberRelatedMenuImagesWarning);
            }
        }

        private string _showDriverNumberRelatedMenuImagesWarningMessage;

        public string ShowDriverNumberRelatedMenuImagesWarningMessage
        {
            get { return _showDriverNumberRelatedMenuImagesWarningMessage; }
            set
            {
                SetProperty(ref _showDriverNumberRelatedMenuImagesWarningMessage, value,
                    () => ShowDriverNumberRelatedMenuImagesWarningMessage);
            }
        }

    }
}
