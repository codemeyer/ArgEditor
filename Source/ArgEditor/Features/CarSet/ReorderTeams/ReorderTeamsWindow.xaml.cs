using System.Windows;

namespace ArgEditor.Features.CarSet.ReorderTeams
{
    /// <summary>
    /// Interaction logic for ReorderTeamsWindow.xaml
    /// </summary>
    public partial class ReorderTeamsWindow : Window
    {
        public ReorderTeamsWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
