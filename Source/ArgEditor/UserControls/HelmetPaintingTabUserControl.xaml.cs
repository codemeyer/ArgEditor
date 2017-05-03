using ArgEditor.Interactors;
using ArgEditor.Mappers;
using ArgEditor.ViewModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

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
            var helmet = GetHelmetViewModelForContextMenuItem(sender as MenuItem);

            if (helmet == null)
                return;

            var colorChangeList = CreateColorChangeListForHelmetPasteOperation(helmet, App.ClipboardHelmet);
            int index = (DataContext as MainViewModel).Drivers.Select(t => t.Helmet).ToList().IndexOf(helmet);
            App.HelmetColorUndoStacks[index].Push(colorChangeList);

            Mapper.MapHelmetViewModel(App.ClipboardHelmet, helmet);
        }

        private ColorChangeList CreateColorChangeListForHelmetPasteOperation(HelmetViewModel helmet, HelmetViewModel sourceHelmet)
        {
            var colorChangeList = new ColorChangeList();

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.VisorColorIndex))),
                NewValue = sourceHelmet.VisorColorIndex,
                OldValue = helmet.VisorColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.VisorSurroundColorIndex))),
                NewValue = sourceHelmet.VisorSurroundColorIndex,
                OldValue = helmet.VisorSurroundColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.Stripe1ColorIndex))),
                NewValue = sourceHelmet.Stripe1ColorIndex,
                OldValue = helmet.Stripe1ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.Stripe2ColorIndex))),
                NewValue = sourceHelmet.Stripe2ColorIndex,
                OldValue = helmet.Stripe2ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.Stripe3ColorIndex))),
                NewValue = sourceHelmet.Stripe3ColorIndex,
                OldValue = helmet.Stripe3ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.Stripe4ColorIndex))),
                NewValue = sourceHelmet.Stripe4ColorIndex,
                OldValue = helmet.Stripe4ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.Stripe5ColorIndex))),
                NewValue = sourceHelmet.Stripe5ColorIndex,
                OldValue = helmet.Stripe5ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.Stripe6ColorIndex))),
                NewValue = sourceHelmet.Stripe6ColorIndex,
                OldValue = helmet.Stripe6ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.Stripe7ColorIndex))),
                NewValue = sourceHelmet.Stripe7ColorIndex,
                OldValue = helmet.Stripe7ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.Stripe8ColorIndex))),
                NewValue = sourceHelmet.Stripe8ColorIndex,
                OldValue = helmet.Stripe8ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.Stripe9ColorIndex))),
                NewValue = sourceHelmet.Stripe9ColorIndex,
                OldValue = helmet.Stripe9ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.Stripe10ColorIndex))),
                NewValue = sourceHelmet.Stripe10ColorIndex,
                OldValue = helmet.Stripe10ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.Stripe11ColorIndex))),
                NewValue = sourceHelmet.Stripe11ColorIndex,
                OldValue = helmet.Stripe11ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.Stripe12ColorIndex))),
                NewValue = sourceHelmet.Stripe12ColorIndex,
                OldValue = helmet.Stripe12ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(sourceHelmet.Stripe13ColorIndex))),
                NewValue = sourceHelmet.Stripe13ColorIndex,
                OldValue = helmet.Stripe13ColorIndex
            });

            return colorChangeList;
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
            System.Diagnostics.Process.Start(@"http://manicomio.se/argeditor/decompressed-exe");
        }

        private void HelmetSelectionLoadFile_Click(object sender, RoutedEventArgs e)
        {
            var update = GetHelmetViewModelForContextMenuItem(sender as MenuItem);

            var path = new FileDialog().SelectLegacyHelmetFileToOpen();

            if (path == string.Empty)
                return;

            var helmet = LegacyHelmetFileLoader.Load(path);

            Mapper.MapDataHelmetToViewModelHelmet(helmet, update);
        }
    }
}
