using System.Reflection;
using System.Windows;
using System.Windows.Input;
using ArgEditor.Interactors;

namespace ArgEditor
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class CheckVersionWindow : Window
    {
        public CheckVersionWindow()
        {
            InitializeComponent();

            string current = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            CurrentVersion.Content = $"Current version: {current}";

            var checker = new VersionChecker();
            string latest = checker.GetLatestVersion();
            if (string.IsNullOrEmpty(latest))
            {
                LatestVersion.Content = "Checking for updates failed!";
                DownloadLink.Visibility = Visibility.Hidden;
                return;
            }

            LatestVersion.Content = $"Latest version: {latest}";

            bool hasNewer = checker.Compare(current, latest);

            if (hasNewer)
            {
                DownloadLink.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DownloadLink_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://manicomio.se/argeditor/download/");
        }
    }
}
