using System.Reflection;
using System.Windows;
using ArgEditor.Commands;

namespace ArgEditor.Windows
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();

            VersionLabel.Content = "Version " + Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void SiteLink_OnClick(object sender, RoutedEventArgs e)
        {
            new HelpDocsCommand().Execute("");
        }
    }
}
