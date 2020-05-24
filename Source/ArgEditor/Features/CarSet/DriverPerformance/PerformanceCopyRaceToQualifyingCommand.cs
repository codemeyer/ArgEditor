using ArgEditor.Features.Main;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.DriverPerformance
{
    public class PerformanceCopyRaceToQualifyingCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var mainViewModel = parameter as MainViewModel;

            if (mainViewModel == null)
            {
                return;
            }

            foreach (var driver in mainViewModel.Drivers)
            {
                driver.QualifyingGripLevel = driver.RaceGripLevel;
            }
        }
    }
}
