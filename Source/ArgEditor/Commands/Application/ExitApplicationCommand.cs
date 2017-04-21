using System.Windows;

namespace ArgEditor.Commands
{
    public class ExitApplicationCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
