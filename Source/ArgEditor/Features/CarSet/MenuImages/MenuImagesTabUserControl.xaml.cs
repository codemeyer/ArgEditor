using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ArgEditor.Features.Main;

namespace ArgEditor.Features.CarSet.MenuImages
{
    /// <summary>
    /// Interaction logic for MenuImagesTabUserControl.xaml
    /// </summary>
    public partial class MenuImagesTabUserControl : UserControl
    {
        public MenuImagesTabUserControl()
        {
            InitializeComponent();
        }

        private MainViewModel DataContextViewModel => DataContext as MainViewModel;

        private void SelectMenuImage_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;

            var driver = img.DataContext as DriverViewModel;

            DataContextViewModel.SelectedMenuImage = driver.MenuImage;
        }

        private void MenuImageSelectionCopy_Click(object sender, RoutedEventArgs e)
        {
            var menuImage = GetMenuImageViewModelForContextMenuItem(sender as MenuItem);

            if (menuImage == null)
                return;

            App.ClipboardMenuImage = menuImage.PixelData;
        }

        private void MenuImageSelectionPaste_Click(object sender, RoutedEventArgs e)
        {
            if (App.ClipboardMenuImage == null)
            {
                return;
            }

            var menuImage = GetMenuImageViewModelForContextMenuItem(sender as MenuItem);

            if (menuImage == null)
                return;

            var pasteCommand = new PasteMenuImageFromClipboardCommand();
            pasteCommand.Execute(menuImage);
        }

        private MenuImageViewModel GetMenuImageViewModelForContextMenuItem(MenuItem menuItem)
        {
            ContextMenu cm = menuItem.CommandParameter as ContextMenu;
            if (cm != null)
            {
                var g = cm.PlacementTarget as Image;

                var driver = g.DataContext as DriverViewModel;

                return driver?.MenuImage;
            }

            return null;
        }
    }
}
