using System.Diagnostics;

namespace ArgEditor.Commands
{
    public class OpenArgDataPageCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Process.Start(@"http://www.argtools.com/argdata");
        }
    }
}
