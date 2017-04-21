using ArgEditor.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ArgEditor.UserControls.Settings
{
    /// <summary>
    /// Interaction logic for GeneralGripLevel.xaml
    /// </summary>
    public partial class GeneralGripLevelUserControl : UserControl
    {
        public GeneralGripLevelUserControl()
        {
            InitializeComponent();
        }

        private void SetDefault_OnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).GeneralGripLevel = 1;
        }
    }
}
