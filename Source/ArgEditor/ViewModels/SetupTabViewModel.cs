using ArgEditor.Commands.Setups;
using System.Windows;
using System.Windows.Input;

namespace ArgEditor.ViewModels
{
    public class SetupTabViewModel : BaseViewModel
    {
        public SetupTabViewModel()
        {
            SelectedTab = 0;
            UpdateActionButtonsVisibility();
        }



        // ReSharper disable UnusedMember.Global because it IS used in XAML
        public ICommand LoadSingleSetupFileCommand { get; } = new LoadSingleSetupFileCommand(new FileDialog());
        public ICommand SaveSingleSetupFileCommand { get; } = new SaveSingleSetupFileCommand(new FileDialog());
        public ICommand LoadMultiSetupFileCommand { get; } = new LoadMultiSetupFileCommand(new FileDialog());
        public ICommand SaveMultiSetupFileCommand { get; } = new SaveMultiSetupFileCommand(new FileDialog());

        public SetupViewModel SingleSetupViewModel { get; set; } = new SetupViewModel("SingleSetup");
        public MultiSetupViewModel MultiSetupViewModel { get; set; } = new MultiSetupViewModel();
        // ReSharper restore UnusedMember.Global


        private int _selectedTab;

        public int SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                if (SetProperty(ref _selectedTab, value, () => SelectedTab))
                {
                    UpdateActionButtonsVisibility();
                }
            }
        }

        private void UpdateActionButtonsVisibility()
        {
            ShowSingleSetupFileActionButtonsVisibility = SelectedTab == 0 ? Visibility.Visible : Visibility.Collapsed;
            ShowMultiSetupFileActionButtonsVisibility = SelectedTab == 1 ? Visibility.Visible : Visibility.Collapsed;
        }

        private Visibility _showSingleSetupFileActionButtonsVisibility;

        public Visibility ShowSingleSetupFileActionButtonsVisibility
        {
            get { return _showSingleSetupFileActionButtonsVisibility; }
            set
            {
                SetProperty(ref _showSingleSetupFileActionButtonsVisibility, value,
                    () => ShowSingleSetupFileActionButtonsVisibility);
            }
        }


        private Visibility _showMultiSetupFileActionButtonsVisibility;

        public Visibility ShowMultiSetupFileActionButtonsVisibility
        {
            get { return _showMultiSetupFileActionButtonsVisibility; }
            set
            {
                SetProperty(ref _showMultiSetupFileActionButtonsVisibility, value,
                    () => ShowMultiSetupFileActionButtonsVisibility);
            }
        }
    }
}
