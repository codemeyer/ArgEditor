using System.Collections.Generic;
using ArgEditor.ViewModels;

namespace ArgEditor.Interactors
{
    public class SaveFile
    {
        public int Version { get { return 1; } }
        public List<DriverViewModel> Drivers { get; set; }
        public List<TeamViewModel> Teams { get; set; }
    }
}
