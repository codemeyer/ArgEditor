using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArgEditor.Features.Main;
using ArgEditor.Features.Persistence.Common.CarSets;
using ArgEditor.Mappers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ArgEditor.Features.Persistence.SaveCarSet
{
    /// <summary>
    /// Saves a MainViewModel to disk as a CarSet.
    /// </summary>
    public class CarSetSaver
    {
        // TODO: map MainViewModel to CarSet first, and pass in CarSet here?

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

            Mapper.MapPointsSystemViewModelToCarSet(viewModel.PointsSystem, carSet.PointsSystem);

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
}
