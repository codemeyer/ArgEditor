using System.Diagnostics;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.Application.About
{
    public class OpenGoogleGroupsWebSiteCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            const string fullUrl = "https://groups.google.com/forum/#!forum/f1gpwc";

            Process.Start(fullUrl);
        }
    }
}
