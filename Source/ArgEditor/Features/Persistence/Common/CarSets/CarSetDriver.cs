namespace ArgEditor.Features.Persistence.Common.CarSets
{
    /// <summary>
    /// CarSetDriver that will be saved as JSON in an .arged file.
    /// </summary>
    public class CarSetDriver
    {
        public byte Number { get; set; }
        public string Name { get; set; }
        public byte RaceGripLevel { get; set; }
        public byte QualifyingGripLevel { get; set; }
        public CarSetHelmetColors HelmetColors { get; set; }
    }
}
