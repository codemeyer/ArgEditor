using System.Reflection;
using System.Windows;

namespace ArgEditor
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SiteLink_OnClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://manicomio.se/argeditor/");
        }
    }
}
