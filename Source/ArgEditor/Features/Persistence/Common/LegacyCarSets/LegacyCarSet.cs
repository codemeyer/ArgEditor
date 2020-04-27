using System.Collections.Generic;

namespace ArgEditor.Features.Persistence.Common.LegacyCarSets
{
    public class LegacyCarSet
    {
        public List<LegacyDriver> Drivers { get; set; } = new List<LegacyDriver>();
        public List<LegacyTeam> Teams { get; set; } = new List<LegacyTeam>();
        public LegacySettings Settings { get; set; } = new LegacySettings();
    }
}
