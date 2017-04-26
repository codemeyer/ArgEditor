using System.Windows;
using ArgData;

namespace ArgEditor.ViewModels
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
    }
}
