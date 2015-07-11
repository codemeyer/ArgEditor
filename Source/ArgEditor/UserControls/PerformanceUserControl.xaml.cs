using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace ArgEditor.UserControls
{
    /// <summary>
    /// Interaction logic for TeamDriverPerformanceUserControl.xaml
    /// </summary>
    public partial class TeamDriverPerformanceUserControl : UserControl
    {
        public TeamDriverPerformanceUserControl()
        {
            InitializeComponent();
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!IsValidKey(e.Key))
            {
                e.Handled = true;
                return;
            }

            // TODO: max value?

            var textbox = (TextBox)sender;
            string currentTextValue = textbox.Text;
            int value = 0;

            if (!int.TryParse(currentTextValue, out value))
                return;

            if (e.Key == Key.OemPlus)
            {
                value++;
                e.Handled = true;
            }

            if (e.Key == Key.OemMinus && value > 0)
            {
                value--;
                e.Handled = true;
            }

            textbox.Text = value.ToString();
        }

        private Key[] _validKeys = new Key[]
        {
            Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9,
            Key.OemPlus, Key.OemMinus, Key.Delete, Key.Tab
        };

        private bool IsValidKey(Key key)
        {
            return (_validKeys.Contains(key));
        }
    }
}
