using System.Windows.Controls;
using System.Windows.Input;

namespace ArgEditor.UserControls
{
    /// <summary>
    /// Interaction logic for CarUserControl.xaml
    /// </summary>
    public partial class CarUserControl : UserControl, ICarUserControl
    {
        public CarUserControl()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
        }
    }
}
