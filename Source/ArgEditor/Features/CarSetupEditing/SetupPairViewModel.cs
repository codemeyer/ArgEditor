using System.Windows;
using System.Windows.Input;
using ArgEditor.Features.Persistence;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSetupEditing
{
    public class SetupPairViewModel : BaseViewModel
    {
        public SetupPairViewModel(string description)
        {
            Description = description;
            RaceSetup = new SetupViewModel($"Race{Description}Group");
            QualifyingSetup = new SetupViewModel($"Qual{Description}Group");
            UpdateSetupDescriptions();
        }

        private string _description = "";

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value, () => Description); }
        }


        private string _setup1Description = "";

        public string Setup1Description
        {
            get { return _setup1Description; }
            set { SetProperty(ref _setup1Description, value, () => Setup1Description); }
        }

        private string _setup2Description = "";

        public string Setup2Description
        {
            get { return _setup2Description; }
            set { SetProperty(ref _setup2Description, value, () => Setup2Description); }
        }


        private void UpdateSetupDescriptions()
        {
            if (SeparateSetups)
            {
                Setup1Description = $"Race Setup for {Description}";
                Setup2Description = $"Qualifying Setup for {Description}";
                ShowSetup2 = Visibility.Visible;
            }
            else
            {
                Setup1Description = $"Race and Qualifying Setup for {Description}";
                Setup2Description = string.Empty;
                ShowSetup2 = Visibility.Hidden;
            }
        }

        public SetupViewModel RaceSetup { get; set; }
        public SetupViewModel QualifyingSetup { get; set; }

        private bool _separateSetups;


        public bool SeparateSetups
        {
            get { return _separateSetups; }
            set
            {
                if (SetProperty(ref _separateSetups, value, () => SeparateSetups))
                {
                    UpdateSetupDescriptions();
                }
            }
        }

        private Visibility _showSetup2;

        public Visibility ShowSetup2
        {
            get { return _showSetup2; }
            set { SetProperty(ref _showSetup2, value, () => ShowSetup2); }
        }


        public ICommand LoadSingleSetupFileCommand { get; } = new LoadSingleSetupFileCommand(new FileDialog());
        public ICommand SaveSingleSetupFileCommand { get; } = new SaveSingleSetupFileCommand(new FileDialog());
        public ICommand CopyRaceSetupToQualifyingCommand { get; } = new CopyRaceSetupToQualifyingCommand();
        public ICommand CopyQualifyingSetupToRaceCommand { get; } = new CopyQualifyingSetupToRaceCommand();
    }
}
