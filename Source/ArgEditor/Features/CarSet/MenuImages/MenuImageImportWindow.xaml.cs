using System.Windows;
using System.Windows.Input;
using ArgEditor.Features.Persistence;

namespace ArgEditor.Features.CarSet.MenuImages
{
    /// <summary>
    /// Interaction logic for MenuImageImportWindow.xaml
    /// </summary>
    public partial class MenuImageImportWindow : Window
    {
        public MenuImageImportWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var path = new FileDialog().SelectImageFileToOpen();

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                // do stuff
                (DataContext as LoadMenuImageViewModel).LoadImage(path);
            }
            catch
            {
                MessageBox.Show("An error occurred when loading the selected image. Please make sure that it is a valid image file.",
                    "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
