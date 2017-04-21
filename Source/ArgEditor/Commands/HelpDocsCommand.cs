using System.Diagnostics;

namespace ArgEditor.Commands
{
    public class HelpDocsCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            // TODO: parse parameter to determine page to open

            Process.Start(@"http://manicomio.se/argeditor/");
        }
    }
}
