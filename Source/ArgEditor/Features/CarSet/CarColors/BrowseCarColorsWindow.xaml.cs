using ArgEditor.Features.CarSet.PitCrew;
using System.Windows;
using System.Windows.Input;

namespace ArgEditor.Features.CarSet.CarColors
{
    /// <summary>
    /// Interaction logic for BrowseCarColorsWindow.xaml
    /// </summary>
    public partial class BrowseCarColorsWindow : Window
    {
        public BrowseCarColorsWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is CarUserControl carUserControl)
            {
                if (carUserControl.DataContext is CarEditingViewModel clicked)
                {
                    (DataContext as BrowseCarColorsViewModel).SelectedCar = clicked;
                    (DataContext as BrowseCarColorsViewModel).SelectedPitCrew = null;
                }
            }

            if (e.Source is PitCrewUserControl pitCrewUserControl)
            {
                if (pitCrewUserControl.DataContext is PitCrewViewModel clicked)
                {
                    (DataContext as BrowseCarColorsViewModel).SelectedPitCrew = clicked;
                    (DataContext as BrowseCarColorsViewModel).SelectedCar = null;
                }
            }
        }
    }
}
