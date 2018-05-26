using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ArgEditor.ViewModels;

namespace ArgEditor.UserControls
{
    /// <summary>
    /// Interaction logic for PointsSystemTabUserControl.xaml
    /// </summary>
    public partial class PointsSystemTabUserControl : UserControl
    {
        public PointsSystemTabUserControl()
        {
            InitializeComponent();
        }

        // TODO: commands instead of code-behind, ffs

        private void ButtonCurrent_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as PointsSystemViewModel).SetF1From2010();
        }

        private void Button2003_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as PointsSystemViewModel).SetFrom2003To2009();
        }

        private void Button1991_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as PointsSystemViewModel).SetFrom1991To2002();
        }

        private void Button1990_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as PointsSystemViewModel).SetFrom1961To1990();
        }

        private void ButtonAll_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as PointsSystemViewModel).SetAll();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.argtools.com/argeditor/decompressed-exe/");
        }
    }
}
