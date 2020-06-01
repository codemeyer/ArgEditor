using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using ArgEditor.Features.CarSet.CarColors;
using ArgEditor.Features.Main;
using ArgEditor.Features.Palette;
using ArgEditor.Features.Persistence;
using ArgEditor.Features.UndoRedo;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSet.HelmetColors
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
            var clickedPolygonEvent = e as ClickedPolygonEventArgs;
            if (clickedPolygonEvent == null) return;

            var selectedHelmet = DataContextViewModel.SelectedHelmet;

            var activePaletteTool = DataContextViewModel.Palette.ActivePaletteTool;

            PaletteActionService.PerformPaletteAction(DataContextViewModel, activePaletteTool, clickedPolygonEvent.Property, selectedHelmet, PaintedElement.Helmet);
        }

        private MainViewModel DataContextViewModel => DataContext as MainViewModel;


        private void SelectHelmet_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HelmetViewModel selectedHelmet = ((HelmetUserControl)sender).DataContext as HelmetViewModel;

            DataContextViewModel.SelectedHelmet = selectedHelmet;
        }

        // TODO: all stuff below is also in various commands
        // refactor to use commands instead of this code for the context menu!

        private void HelmetSelectionCopy_Click(object sender, RoutedEventArgs e)
        {
            var helmet = GetHelmetViewModelForContextMenuItem(sender as MenuItem);

            if (helmet == null)
                return;

            if (App.ClipboardHelmet == null)
            {
                App.ClipboardHelmet = new HelmetViewModel(null);  // ?
            }

            Mapper.MapHelmetViewModel(helmet, App.ClipboardHelmet);
        }

        private void HelmetSelectionPaste_Click(object sender, RoutedEventArgs e)
        {
            if (App.ClipboardHelmet == null)
            {
                return;
            }

            var helmet = GetHelmetViewModelForContextMenuItem(sender as MenuItem);

            if (helmet == null)
                return;

            var colorChangeList = HelmetColorChangeCreator.CreateColorChangeListForHelmetPasteOperation(helmet, App.ClipboardHelmet);
            int index = (DataContext as MainViewModel).Drivers.Select(t => t.Helmet).ToList().IndexOf(helmet);
            App.HelmetColorUndoStacks[index].Push(colorChangeList);
            App.HelmetColorRedoStacks[index].Clear();

            Mapper.MapHelmetViewModel(App.ClipboardHelmet, helmet);
        }

        private HelmetViewModel GetHelmetViewModelForContextMenuItem(MenuItem menuItem)
        {
            ContextMenu cm = menuItem.CommandParameter as ContextMenu;
            if (cm != null)
            {
                var g = cm.PlacementTarget as HelmetUserControl;

                var team = g.DataContext as HelmetViewModel;
                return team;
            }

            return null;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.argtools.com/argeditor/decompressed-exe");
        }

        private void HelmetSelectionLoadFile_Click(object sender, RoutedEventArgs e)
        {
            var helmet = GetHelmetViewModelForContextMenuItem(sender as MenuItem);

            if (helmet == null)
            {
                return;
            }

            var command = new LoadHelmetFileCommand(new FileDialog());
            command.Execute(helmet);
        }

        private void HelmetSelectionSaveFile_Click(object sender, RoutedEventArgs e)
        {
            var helmet = GetHelmetViewModelForContextMenuItem(sender as MenuItem);

            if (helmet == null)
            {
                return;
            }

            var command = new SaveHelmetFileCommand(new FileDialog());
            command.Execute(helmet);
        }
    }
}
