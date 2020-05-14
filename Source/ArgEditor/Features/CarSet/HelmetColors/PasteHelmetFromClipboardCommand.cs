using System.Linq;
using ArgEditor.Features.Main;
using ArgEditor.Features.UndoRedo;
using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSet.HelmetColors
{
    public class PasteHelmetFromClipboardCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var helmet = parameter as HelmetViewModel;

            if (helmet == null) return;

            var colorChangeList = CreateColorChangeListForHelmetPasteOperation(helmet, App.ClipboardHelmet);
            int index = MainViewModelPasserArounder.MainViewModel.Drivers.Select(t => t.Helmet).ToList().IndexOf(helmet);
            App.HelmetColorUndoStacks[index].Push(colorChangeList);
            App.HelmetColorRedoStacks[index].Clear();

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

        public override bool CanExecute(object parameter)
        {
            return App.ClipboardHelmet != null;
        }
    }
}
