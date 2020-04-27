namespace ArgEditor.Features.Persistence.Common.LegacyCarSets
{
    public class LegacyTeam
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Engine { get; set; }
        public int Horsepower { get; set; }
        public int Driver1Number { get; set; }
        public int Driver2Number { get; set; }

        public byte[] CarColors { get; set; }
        public byte[] PitCrewColors { get; set; }
    }
}
