using System.Diagnostics;

namespace ArgEditor.Commands
{
    public class OpenDownloadPageCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Process.Start(@"http://manicomio.se/argeditor/download");
        }
    }
}
