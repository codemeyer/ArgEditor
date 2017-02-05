namespace ArgEditor.Interactors.CarSets
{
    /// <summary>
    /// CarSetTeam that will be saved as JSON in an .arged file.
    /// </summary>
    public class CarSetTeam
    {
        public string Name { get; set; }
        public string Engine { get; set; }
        public int Horsepower { get; set; }
        public CarSetCarColors CarColors { get; set; }
        public CarSetPitCrewColors PitCrewColors { get; set; }
    }
}
