using ArgEditor.Features.UndoRedo;

namespace ArgEditor.Features.CarSet.HelmetColors
{
    public static class HelmetColorChangeCreator
    {
        public static ColorChangeList CreateColorChangeListForHelmetPasteOperation(HelmetViewModel currentHelmet, HelmetViewModel updatedHelmet)
        {
            var colorChangeList = new ColorChangeList();

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.VisorColorIndex))),
                NewValue = updatedHelmet.VisorColorIndex,
                OldValue = currentHelmet.VisorColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.VisorSurroundColorIndex))),
                NewValue = updatedHelmet.VisorSurroundColorIndex,
                OldValue = currentHelmet.VisorSurroundColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.Stripe1ColorIndex))),
                NewValue = updatedHelmet.Stripe1ColorIndex,
                OldValue = currentHelmet.Stripe1ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.Stripe2ColorIndex))),
                NewValue = updatedHelmet.Stripe2ColorIndex,
                OldValue = currentHelmet.Stripe2ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.Stripe3ColorIndex))),
                NewValue = updatedHelmet.Stripe3ColorIndex,
                OldValue = currentHelmet.Stripe3ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.Stripe4ColorIndex))),
                NewValue = updatedHelmet.Stripe4ColorIndex,
                OldValue = currentHelmet.Stripe4ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.Stripe5ColorIndex))),
                NewValue = updatedHelmet.Stripe5ColorIndex,
                OldValue = currentHelmet.Stripe5ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.Stripe6ColorIndex))),
                NewValue = updatedHelmet.Stripe6ColorIndex,
                OldValue = currentHelmet.Stripe6ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.Stripe7ColorIndex))),
                NewValue = updatedHelmet.Stripe7ColorIndex,
                OldValue = currentHelmet.Stripe7ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.Stripe8ColorIndex))),
                NewValue = updatedHelmet.Stripe8ColorIndex,
                OldValue = currentHelmet.Stripe8ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.Stripe9ColorIndex))),
                NewValue = updatedHelmet.Stripe9ColorIndex,
                OldValue = currentHelmet.Stripe9ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.Stripe10ColorIndex))),
                NewValue = updatedHelmet.Stripe10ColorIndex,
                OldValue = currentHelmet.Stripe10ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.Stripe11ColorIndex))),
                NewValue = updatedHelmet.Stripe11ColorIndex,
                OldValue = currentHelmet.Stripe11ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.Stripe12ColorIndex))),
                NewValue = updatedHelmet.Stripe12ColorIndex,
                OldValue = currentHelmet.Stripe12ColorIndex
            });

            colorChangeList.Add(new ColorChange
            {
                Property = new ColorPropertyWrapper(typeof(HelmetViewModel).GetProperty(nameof(updatedHelmet.Stripe13ColorIndex))),
                NewValue = updatedHelmet.Stripe13ColorIndex,
                OldValue = currentHelmet.Stripe13ColorIndex
            });

            return colorChangeList;
        }
    }
}
