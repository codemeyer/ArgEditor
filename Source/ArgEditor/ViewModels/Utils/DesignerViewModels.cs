// ReSharper disable ClassNeverInstantiated.Global
namespace ArgEditor.ViewModels.Utils
{
    public class DesignerCarEditingViewModel : CarEditingViewModel
    {
        public DesignerCarEditingViewModel()
            : base(new byte[] { 78, 78, 78, 78, 78, 78, 78, 78, 78, 78, 78, 78, 78 })
        {
        }
    }

    public class DesignerHelmetViewModel : HelmetViewModel
    {
        public DesignerHelmetViewModel()
            : base(new byte[] { 0, 1, 111, 111, 111, 111, 6, 79, 79, 111, 111, 95, 111, 111, 111, 111 })
        {
        }
    }

    public class DesignerPitCrewViewModel : PitCrewViewModel
    {
        public DesignerPitCrewViewModel()
            : base(new byte[] { 72, 68, 58, 56, 38 })
        {
        }
    }

    public class DesignerTeamViewModel : TeamViewModel
    {
        public DesignerTeamViewModel()
            : base(0, "Team", "Engine", new DriverViewModel(1, "Driver One", 1, 1), new DriverViewModel(2, "Driver Two", 2, 2))
        {
        }
    }
}
