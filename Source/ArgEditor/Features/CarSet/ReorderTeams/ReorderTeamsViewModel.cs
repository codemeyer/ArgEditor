using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSet.ReorderTeams
{
    public class ReorderTeamsViewModel : BaseViewModel
    {
        public ReorderTeamsViewModel(List<TeamViewModel> teams)
        {
            _teams = new ObservableCollection<ReorderableTeamViewModel>();

            foreach (var team in teams)
            {
                var reorderableTeam = new ReorderableTeamViewModel(team, _teams);
                reorderableTeam.OriginalIndex = team.Index;
                _teams.Add(reorderableTeam);
            }
        }


        private ObservableCollection<ReorderableTeamViewModel> _teams;

        public ObservableCollection<ReorderableTeamViewModel> Teams
        {
            get { return _teams; }
            set { SetProperty(ref _teams, value, () => Teams); }
        }


        public ICommand MoveTeamDownCommand { get; } = new MoveTeamDownCommand();
        public ICommand MoveTeamUpCommand { get; } = new MoveTeamUpCommand();
    }


    public class ReorderableTeamViewModel : BaseViewModel
    {
        public ReorderableTeamViewModel(TeamViewModel team, ObservableCollection<ReorderableTeamViewModel> parentList)
        {
            ParentList = parentList;
            Team = team;
        }

        public ObservableCollection<ReorderableTeamViewModel> ParentList { get; }


        private TeamViewModel _team;

        public TeamViewModel Team
        {
            get { return _team; }
            set { SetProperty(ref _team, value, () => Team); }
        }


        public int OriginalIndex { get; set; }


        public int IndexOf()
        {
            return ParentList.IndexOf(this);
        }
    }
}
