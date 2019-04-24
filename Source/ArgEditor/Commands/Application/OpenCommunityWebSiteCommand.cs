using System.Diagnostics;

namespace ArgEditor.Commands
{
    public class OpenCommunityWebSiteCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            const string fullUrl = "https://sites.google.com/view/f1gpwc/";

            Process.Start(fullUrl);
        }
    }
}
