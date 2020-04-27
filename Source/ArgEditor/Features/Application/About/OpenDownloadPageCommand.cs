using System.Diagnostics;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.Application.About
{
    public class OpenDownloadPageCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Process.Start(@"http://www.argtools.com/argeditor/download");
        }
    }
}
