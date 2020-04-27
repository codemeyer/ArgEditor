using System.Collections.Generic;

namespace ArgEditor.Features.UndoRedo
{
    public static class UndoRedoService
    {
        public static void ProcessColorChangeStacks(object viewModel, Stack<ColorChangeList> popStack, Stack<ColorChangeList> pushStack)
        {
            // TODO: viewModel must be Helmet or CarEditing, use common interface???

            var latestChanges = popStack.Pop();
            var reverseChanges = new ColorChangeList();

            foreach (var latestChange in latestChanges)
            {
                latestChange.Property.SetValue(viewModel, latestChange.OldValue);

                var reverseChange = new ColorChange
                {
                    NewValue = latestChange.OldValue,
                    OldValue = latestChange.NewValue,
                    Property = latestChange.Property,
                    PaintedElement = latestChange.PaintedElement
                };
                reverseChanges.Add(reverseChange);
            }

            pushStack.Push(reverseChanges);
        }
    }
}
