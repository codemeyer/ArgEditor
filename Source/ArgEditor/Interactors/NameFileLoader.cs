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
            NamesFileParser parser = new NamesFileParser();
            var namesFile = parser.Parse(path);

            UpdateTeamNames(viewModel, namesFile);
            UpdateDriverNames(viewModel, namesFile);
        }

        private static void UpdateTeamNames(MainViewModel viewModel, NamesFile namesFile)
        {
            for (int i = 0; i < ArgEditorConstants.DriverCount; i++)
            {
                var fileTeam = namesFile.Teams[i];
                var team = viewModel.Teams[i];

                team.Name = fileTeam.Name;
                team.Engine = fileTeam.Engine;
            }
        }

        private static void UpdateDriverNames(MainViewModel viewModel, NamesFile namesFile)
        {
            for (int i = 0; i < ArgEditorConstants.TeamCount; i++)
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
}
