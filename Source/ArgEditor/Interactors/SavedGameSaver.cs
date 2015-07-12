using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArgEditor.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ArgEditor.Interactors
{
    public class SavedGameSaver
    {
        public void DoSaveisch(MainViewModel viewModel, string path)
        {
            var saveFile = new SaveFile();
            // TODO: no need to save ALL info in the view models
            saveFile.Drivers = viewModel.Drivers;
            saveFile.Teams = viewModel.Teams;

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new WritablePropertiesOnlyResolver(),
                Formatting = Formatting.Indented
            };

            string saveFileData = JsonConvert.SerializeObject(saveFile, settings);

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
