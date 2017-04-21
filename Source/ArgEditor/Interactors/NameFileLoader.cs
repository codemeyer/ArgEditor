using System.Linq;
using ArgData;
using ArgData.Entities;
using ArgEditor.ViewModels;

namespace ArgEditor.Interactors
{
    public class NameFileLoader
    {
        public void Load(MainViewModel viewModel, string path)
        {
            var namesFile = NameFileReader.Read(path);

            UpdateTeamNames(viewModel, namesFile);
            UpdateDriverNames(viewModel, namesFile);
        }

        private static void UpdateTeamNames(MainViewModel viewModel, NameFile namesFile)
        {
            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                var fileTeam = namesFile.Teams[i];
                var team = viewModel.Teams[i];

                team.Name = fileTeam.Name;
                team.Engine = fileTeam.Engine;
            }
        }

        private static void UpdateDriverNames(MainViewModel viewModel, NameFile namesFile)
        {
            for (int i = 0; i < ArgEditorConstants.DriverNumberMax; i++)
            {
                var fileDriver = namesFile.Drivers[i];
                var driver = viewModel.Drivers.SingleOrDefault(d => d.Number == i + 1);

                if (driver == null)
                {
                    continue;
                }

                driver.Name = fileDriver.Name;
            }
        }
    }

    public class NameFileSaver
    {
        public void Save(MainViewModel viewModel, string path)
        {
            var drivers = new NameFileDriverList();

            for (int i = 0; i < ArgEditorConstants.DriverNumberMax; i++)
            {
                int number = i + 1;

                var driver = viewModel.Drivers.FirstOrDefault(d => d.Number == number);

                if (driver != null)
                {
                    drivers[i].Name = driver.Name;
                }
                else
                {
                    drivers[i].Name = $"Spare {number}";
                }
            }

            var teams = new NameFileTeamList();

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                teams[i].Name = viewModel.Teams[i].Name;
                teams[i].Engine = viewModel.Teams[i].Engine;
            }

            teams[18].Name = "Team 19";
            teams[18].Engine = "Engine 19";
            teams[19].Name = "Team 20";
            teams[19].Engine = "Engine 20";

            NameFileWriter.Write(path, drivers, teams);
        }
    }
}
