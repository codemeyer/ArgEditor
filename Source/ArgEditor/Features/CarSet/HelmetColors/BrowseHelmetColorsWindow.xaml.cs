using System.Windows;
using System.Windows.Input;

namespace ArgEditor.Features.CarSet.HelmetColors
{
    /// <summary>
    /// Interaction logic for BrowseCarColorsWindow.xaml
    /// </summary>
    public partial class BrowseHelmetColorsWindow : Window
    {
        public BrowseHelmetColorsWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is HelmetUserControl helmetUserControl)
            {
                if (helmetUserControl.DataContext is HelmetViewModel clicked)
                {
                    (DataContext as BrowseHelmetColorsViewModel).SelectedHelmet = clicked;
                }
            }
        }
    }
}
