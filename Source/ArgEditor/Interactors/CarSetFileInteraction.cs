using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArgEditor.ViewModels;
using AutoMapper;
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

                Mapper.Map(fileDriver, driver);
            }

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                var fileTeam = carSet.Teams[i];
                var team = viewModel.Teams[i];

                Mapper.Map(fileTeam, team);
                Mapper.Map(fileTeam.CarColors, team.Car);
                Mapper.Map(fileTeam.PitCrewColors, team.PitCrew);

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
            // TODO: no need to save ALL info in the view models

            foreach (var team in viewModel.Teams.Take(ArgEditorConstants.TeamCountSupported))
            {
                var fileTeam = Mapper.Map<CarSetTeam>(team);
                fileTeam.CarColors = Mapper.Map<CarSetCarColors>(team.Car);
                fileTeam.PitCrewColors = Mapper.Map<CarSetPitCrewColors>(team.PitCrew);
                carSet.Teams.Add(fileTeam);
            }

            foreach (var driver in viewModel.Drivers.Take(ArgEditorConstants.DriverCountSupported))
            {
                var fileDriver = Mapper.Map<CarSetDriver>(driver);
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
        public byte ShirtPrimaryColorIndex { get; set; }
        public byte ShirtSecondaryColorIndex { get; set; }
        public byte PantsPrimaryColorIndex { get; set; }
        public byte PantsSecondaryColorIndex  { get; set; }
        public byte SocksColorIndex { get; set; }
    }

    public class CarSetCarColors
    {
            public byte EngineCoverColorIndex { get; set; }
            public byte CockpitFrontColorIndex { get; set; }
            public byte FrontWingEndplateColorIndex { get; set; }
            public byte RearWingSideColorIndex { get; set; }
            public byte NoseSideColorIndex { get; set; }
            public byte SidepodColorIndex { get; set; }
            public byte FrontAndRearWingColorIndex { get; set; }
            public byte NoseTopColorIndex { get; set; }
            public byte NoseAngleColorIndex { get; set; }
            public byte CockpitSideColorIndex { get; set; }
            public byte EngineCoverSideColorIndex { get; set; }
            public byte EngineCoverRearColorIndex { get; set; }
            public byte SidepodTopColorIndex { get; set; }
    }
}
