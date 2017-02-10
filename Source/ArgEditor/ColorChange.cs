using System.Reflection;

namespace ArgEditor
{
    public class ColorChange
    {
        public byte OldValue { get; set; }
        public byte NewValue { get; set; }
        public ColorPropertyWrapper Property { get; set; }
        public PaintedElement PaintedElement { get; set; }
    }

    public class ColorPropertyWrapper
    {
        private readonly PropertyInfo _propertyInfo;

        public ColorPropertyWrapper(PropertyInfo propertyInfo)
        {
            _propertyInfo = propertyInfo;
        }

        public byte GetValue(object viewModel)
        {
            return (byte)_propertyInfo.GetValue(viewModel, null);
        }

        public void SetValue(object viewModel, byte value)
        {
            _propertyInfo.SetValue(viewModel, value, null);
        }
    }

    public enum PaintedElement
    {
        Car,
        PitCrew,
        Helmet
    }
}
