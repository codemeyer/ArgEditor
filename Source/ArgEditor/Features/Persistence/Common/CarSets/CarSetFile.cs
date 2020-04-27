using System.Collections.Generic;

namespace ArgEditor.Features.Persistence.Common.CarSets
{
    /// <summary>
    /// CarSet file that will be saved as JSON in an .arged file.
    /// </summary>
    public class CarSetFile
    {
        public CarSetFile()
        {
            FileVersion = 2;
            Teams = new List<CarSetTeam>();
            Drivers = new List<CarSetDriver>();
            PointsSystem = new CarSetPointsSystem();
        }

        public int FileVersion { get; set; }
        public List<CarSetTeam> Teams { get; set; }
        public List<CarSetDriver> Drivers { get; set; }
        public CarSetPointsSystem PointsSystem { get; set; }
    }
}
