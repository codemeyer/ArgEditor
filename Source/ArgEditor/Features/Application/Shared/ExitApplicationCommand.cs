using ArgEditor.Infrastructure;

namespace ArgEditor.Features.Application.Shared
{
    public class ExitApplicationCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
