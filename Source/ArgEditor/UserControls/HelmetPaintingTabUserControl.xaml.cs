using System.Collections.Generic;
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
            var clickedPolygonEvent = e as ClickedPolygonEventArgs;
            var selectedHelmet = DataContextViewModel.SelectedHelmet;

            AddUndoAction(clickedPolygonEvent.Property, selectedHelmet, PaintedElement.Helmet);
        }

        // TODO: in some base class?
        // TODO: does more than just Undo!
        private void AddUndoAction(ColorPropertyWrapper property, object viewModel, PaintedElement paintedElement)
        {
            byte currentColor = property.GetValue(viewModel);

            property.SetValue(viewModel, DataContextViewModel.Palette.SelectedColor);

            int index = -1;
            for (int i = 0; i < 40; i++)
            {
                if (DataContextViewModel.Drivers[i].Helmet == DataContextViewModel.SelectedHelmet)
                {
                    index = i;
                }
            }
            if (index == -1) { return; }

            var change = new ColorChange
            {
                OldValue = currentColor,
                NewValue = DataContextViewModel.Palette.SelectedColor,
                Property = property,
                PaintedElement = paintedElement
            };

            App.HelmetColorUndoStacks[index].Push(change);
            App.HelmetColorRedoStacks[index].Clear();
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

        private void PaintingTab_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                int index = -1;
                for (int i = 0; i < 40; i++)
                {
                    if (DataContextViewModel.Drivers[i].Helmet == DataContextViewModel.SelectedHelmet)
                    {
                        index = i;
                    }
                }
                if (index == -1) { return; }

                if (e.Key == Key.Z)
                {
                    if (App.HelmetColorUndoStacks[index].Count == 0) { return; }

                    ProcessColorChangeStacks(App.HelmetColorUndoStacks[index], App.HelmetColorRedoStacks[index]);
                }

                if (e.Key == Key.Y)
                {
                    if (App.HelmetColorRedoStacks[index].Count == 0) { return; }

                    ProcessColorChangeStacks(App.HelmetColorRedoStacks[index], App.HelmetColorUndoStacks[index]);
                }
            }
        }

        private void ProcessColorChangeStacks(Stack<ColorChange> popStack, Stack<ColorChange> pushStack)
        {
            var latestChange = popStack.Pop();
            var viewModel = DataContextViewModel.SelectedHelmet;

            latestChange.Property.SetValue(viewModel, latestChange.OldValue);

            var reverseChange = new ColorChange
            {
                NewValue = latestChange.OldValue,
                OldValue = latestChange.NewValue,
                Property = latestChange.Property,
                PaintedElement = latestChange.PaintedElement
            };
            pushStack.Push(reverseChange);
        }
    }
}
