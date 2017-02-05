using System.Collections.Generic;

namespace ArgEditor.Interactors.CarSets
{
    /// <summary>
    /// CarSet file that will be saved as JSON in an .arged file.
    /// </summary>
    public class CarSetFile
    {
        public CarSetFile()
        {
            FileVersion = 1;
            Teams = new List<CarSetTeam>();
            Drivers = new List<CarSetDriver>();
        }

        public int FileVersion { get; set; }
        public List<CarSetTeam> Teams { get; set; }
        public List<CarSetDriver> Drivers { get; set; }
    }
}
