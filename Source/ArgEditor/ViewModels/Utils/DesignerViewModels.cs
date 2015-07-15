namespace ArgEditor.ViewModels.Utils
{
    // ReSharper disable once ClassNeverInstantiated.Global - Used by XAML Designer
    public class DesignerCarEditingViewModel : CarEditingViewModel
    {
        public DesignerCarEditingViewModel()
            : base(new byte[] { 78, 78, 78, 78, 78, 78, 78, 78, 78, 78, 78, 78, 78 })
        {
        }
    }

    // ReSharper disable once ClassNeverInstantiated.Global - Used by XAML Designer
    public class DesignerHelmetViewModel : HelmetViewModel
    {
        public DesignerHelmetViewModel()
            : base(new byte[] { 0, 1, 111, 111, 111, 111, 6, 79, 79, 111, 111, 95, 111, 111, 111, 111 })
        {
        }
    }

    // ReSharper disable once ClassNeverInstantiated.Global - Used by XAML Designer
    public class DesignerPitCrewViewModel : PitCrewViewModel
    {
        public DesignerPitCrewViewModel()
            : base(new byte[] { 72, 68, 58, 56, 38 })
        {
        }
    }
}
