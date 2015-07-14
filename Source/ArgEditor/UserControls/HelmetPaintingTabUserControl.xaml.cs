using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ArgEditor.ViewModels;

namespace ArgEditor.UserControls
{
    /// <summary>
    /// Interaction logic for HelmetPaintingTabUserControl.xaml
    /// </summary>
    public partial class HelmetPaintingTabUserControl : UserControl
    {
        public HelmetPaintingTabUserControl()
        {
            InitializeComponent();
        }

        private void PaintHelmetUserControl_OnClickedPolygon(object sender, RoutedEventArgs e)
        {
            var clickedPolygonEvent = e as ClickedHelmetPolygonEventArgs;
            var selectedHelmet = DataContextViewModel.SelectedHelmet;
            var helmetType = selectedHelmet.GetType();
            PropertyInfo property = helmetType.GetProperty(clickedPolygonEvent.PolygonName);

            if (property == null)
            {
                int index = Convert.ToInt32(clickedPolygonEvent.PolygonName.Replace("StripeColorIndices[", "").Replace("]", ""));

                property = helmetType.GetProperty("StripeColorIndices");
                ObservableCollection<byte> stripeColors = (ObservableCollection<byte>)property.GetValue(selectedHelmet, null);

                stripeColors[index] = DataContextViewModel.Palette.SelectedColor;
            }
            else
            {
                property.SetValue(selectedHelmet, DataContextViewModel.Palette.SelectedColor, null);
            }
        }

        private MainViewModel DataContextViewModel
        {
            get
            {
                return DataContext as MainViewModel;
            }
        }

        private void SelectHelmet_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HelmetViewModel selectedHelmet = ((HelmetUserControl)sender).DataContext as HelmetViewModel;

            DataContextViewModel.SelectedHelmet = selectedHelmet;
        }
    }
}
