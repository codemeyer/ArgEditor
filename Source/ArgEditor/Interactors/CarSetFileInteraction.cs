using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArgEditor.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ArgEditor.Interactors
{
    public class CarSetLoader
    {
        public void Load(MainViewModel viewModel, string path)
        {
            string fileData = File.ReadAllText(path);

            var carSet = JsonConvert.DeserializeObject<CarSetFile>(fileData);

            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                var fileDriver = carSet.Drivers[i];
                var driver = viewModel.Drivers[i];

                Mapper.MapCarSetDriverToDriverViewModel(fileDriver, driver);
                Mapper.MapCarSetHelmetToHelmetViewModel(fileDriver.HelmetColors, driver.Helmet);
            }

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                var fileTeam = carSet.Teams[i];
                var team = viewModel.Teams[i];

                Mapper.MapCarSetTeamToTeamViewModel(fileTeam, team);
                Mapper.MapCarSetCarColorsToCarEditingViewModel(fileTeam.CarColors, team.Car);
                Mapper.MapCarSetPitCrewColorsToPitCrewViewModel(fileTeam.PitCrewColors, team.PitCrew);

                team.Drivers.Add(viewModel.Drivers[i * 2]);
                team.Drivers.Add(viewModel.Drivers[i * 2 + 1]);
            }
        }
    }

    public class CarSetSaver
    {
        public void Save(MainViewModel viewModel, string path)
        {
            var carSet = new CarSetFile();

            foreach (var team in viewModel.Teams.Take(ArgEditorConstants.TeamCountSupported))
            {
                var fileTeam = Mapper.MapCarSetTeam(team);
                fileTeam.CarColors = Mapper.MapCarSetCarColors(team.Car);
                fileTeam.PitCrewColors = Mapper.MapCarSetPitCrewColors(team.PitCrew);
                carSet.Teams.Add(fileTeam);
            }

            foreach (var driver in viewModel.Drivers.Take(ArgEditorConstants.DriverCountSupported))
            {
                var fileDriver = Mapper.MapCarSetDriver(driver);
                fileDriver.HelmetColors = Mapper.MapCarSetHelmetColors(driver.Helmet);
                carSet.Drivers.Add(fileDriver);
            }

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new WritablePropertiesOnlyResolver(),
                Formatting = Formatting.Indented
            };

            string saveFileData = JsonConvert.SerializeObject(carSet, settings);

            File.WriteAllText(path, saveFileData);
        }

        private class WritablePropertiesOnlyResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
                return props.Where(p => p.Writable).ToList();
            }
        }
    }

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

    public class CarSetDriver
    {
        public byte Number { get; set; }
        public string Name { get; set; }
        public byte RaceGripLevel { get; set; }
        public byte QualifyingGripLevel { get; set; }
        public CarSetHelmetColors HelmetColors { get; set; }
    }

    public class CarSetTeam
    {
        public string Name { get; set; }
        public string Engine { get; set; }
        public int Horsepower { get; set; }
        public CarSetCarColors CarColors { get; set; }
        public CarSetPitCrewColors PitCrewColors { get; set; }
    }

    public class CarSetPitCrewColors
    {
        public byte ShirtPrimary { get; set; }
        public byte ShirtSecondary { get; set; }
        public byte PantsPrimary { get; set; }
        public byte PantsSecondary { get; set; }
        public byte Socks { get; set; }
    }

    public class CarSetCarColors
    {
        public byte EngineCover { get; set; }
        public byte CockpitFront { get; set; }
        public byte FrontWingEndplate { get; set; }
        public byte RearWingSide { get; set; }
        public byte NoseSide { get; set; }
        public byte Sidepod { get; set; }
        public byte FrontAndRearWing { get; set; }
        public byte NoseTop { get; set; }
        public byte NoseAngle { get; set; }
        public byte CockpitSide { get; set; }
        public byte EngineCoverSide { get; set; }
        public byte EngineCoverRear { get; set; }
        public byte SidepodTop { get; set; }
    }

    public class CarSetHelmetColors
    {
        public byte Stripe1 { get; set; }
        public byte Stripe2 { get; set; }
        public byte Stripe3 { get; set; }
        public byte Stripe4 { get; set; }
        public byte Stripe5 { get; set; }
        public byte Stripe6 { get; set; }
        public byte Stripe7 { get; set; }
        public byte Stripe8 { get; set; }
        public byte Stripe9 { get; set; }
        public byte Stripe10 { get; set; }
        public byte Stripe11 { get; set; }
        public byte Stripe12 { get; set; }
        public byte Stripe13 { get; set; }
        public byte Visor { get; set; }
        public byte VisorSurround { get; set; }
    }
}
