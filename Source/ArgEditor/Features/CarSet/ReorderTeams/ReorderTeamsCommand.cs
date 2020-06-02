using System.Collections.Generic;
using System.Windows.Input;
using ArgEditor.Features.Main;
using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSet.ReorderTeams
{
    public class ReorderTeamsCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var mainViewModel = parameter as MainViewModel;

            if (mainViewModel == null)
            {
                return;
            }

            Mouse.OverrideCursor = Cursors.Wait;

            var copyList = CopyTeamList(mainViewModel.Teams);

            var viewModel = new ReorderTeamsViewModel(copyList);

            Mouse.OverrideCursor = null;

            var window = new ReorderTeamsWindow
            {
                Owner = System.Windows.Application.Current.MainWindow,
                DataContext = viewModel
            };

            var result = window.ShowDialog();

            if (result == true)
            {
                Mouse.OverrideCursor = Cursors.Wait;

                int originalIndex = 0;

                foreach (var originalTeam in mainViewModel.Teams)
                {
                    int newIndex = 0;

                    foreach (var newTeam in viewModel.Teams)
                    {
                        if (originalTeam.Index == newTeam.OriginalIndex)
                        {
                            break;
                        }

                        newIndex++;
                    }

                    if (originalIndex != newIndex && newIndex < 18)
                    {
                        // something moved!
                        MoveFromTo(mainViewModel.Teams, originalIndex, newIndex, copyList);
                    }

                    originalIndex++;
                }

                // needed?
                for (int i = 0; i < mainViewModel.Teams.Count; i++)
                {
                    mainViewModel.Teams[i].Index = i;
                }

                Mouse.OverrideCursor = null;
            }
        }



        private List<TeamViewModel> CopyTeamList(List<TeamViewModel> originalList)
        {
            var copyList = new List<TeamViewModel>();

            foreach (var team in originalList)
            {
                var driver1 = new DriverViewModel(team.Drivers[0].Number, team.Drivers[0].Name, team.Drivers[0].RaceGripLevel, team.Drivers[0].QualifyingGripLevel);
                var driver2 = new DriverViewModel(team.Drivers[1].Number, team.Drivers[1].Name, team.Drivers[1].RaceGripLevel, team.Drivers[1].QualifyingGripLevel);

                var copyTeam = new TeamViewModel(team.Index, team.Name, team.Engine, driver1, driver2);
                Mapper.MapTeamViewModel(team, copyTeam);

                copyList.Add(copyTeam);
            }

            return copyList;
        }

        private void MoveFromTo(List<TeamViewModel> updateList, int originalIndex, int newIndex, List<TeamViewModel> dataList)
        {
            var target = updateList[newIndex];
            var source = dataList[originalIndex];

            Mapper.MapTeamViewModel(source, target);
        }
    }
}
