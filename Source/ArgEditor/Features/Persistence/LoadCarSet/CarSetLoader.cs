using System.IO;
using ArgEditor.Features.Main;
using ArgEditor.Features.Persistence.Common.CarSets;
using ArgEditor.Mappers;
using Newtonsoft.Json;

namespace ArgEditor.Features.Persistence.LoadCarSet
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

            if (carSet.FileVersion > 1)
            {
                Mapper.MapCarSetPointsSystemToViewModel(carSet.PointsSystem, viewModel.PointsSystem);
            }
            else
            {
                // version 1 does not contain a points system, use default...
                viewModel.PointsSystem.SetFrom1991To2002();
            }
        }
    }
}
