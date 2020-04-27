using System.Diagnostics;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.Application.Shared
{
    public class OpenArgDataPageCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Process.Start(@"http://www.argtools.com/argdata");
        }
    }
}
