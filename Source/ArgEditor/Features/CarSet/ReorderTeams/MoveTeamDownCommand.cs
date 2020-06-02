using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.ReorderTeams
{
    public class MoveTeamDownCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var team = parameter as ReorderableTeamViewModel;

            if (team == null)
            {
                return;
            }

            int currentIndex = team.IndexOf();
            team.ParentList.Move(currentIndex, currentIndex + 1);

            for (int i = 0; i < team.ParentList.Count; i++)
            {
                team.ParentList[i].Team.Car.IsSpecialShape = i == 0;
            }
        }
    }
}
