using System.IO;
using ArgEditor.ViewModels;
using AutoMapper;
using Newtonsoft.Json;

namespace ArgEditor.Interactors
{
    public class SavedGameLoader
    {
        public void Load(MainViewModel viewModel, string path)
        {
            string fileData = File.ReadAllText(path);

            var saveFile = JsonConvert.DeserializeObject<SaveFile>(fileData);

            for (int i = 0; i < 36; i++)
            {
                var fileDriver = saveFile.Drivers[i];
                var driver = viewModel.Drivers[i];

                Mapper.Map(fileDriver, driver);
            }

            for (int i = 0; i < 18; i++)
            {
                var fileTeam = saveFile.Teams[i];
                var team = viewModel.Teams[i];

                Mapper.Map(fileTeam, team);

                team.Drivers.Add(viewModel.Drivers[i * 2]);
                team.Drivers.Add(viewModel.Drivers[i * 2 + 1]);
            }
        }
    }
}