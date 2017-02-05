using System.IO;
using ArgEditor.ViewModels;
using Newtonsoft.Json;

namespace ArgEditor.Interactors.CarSets
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
}
