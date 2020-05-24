using ArgEditor.Infrastructure;
using System.Diagnostics;

namespace ArgEditor.Features.CarSetupEditing
{
    public class OpenTyreWearDatabaseWebSiteCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Process.Start("https://sites.google.com/view/f1gpwc/file-archive/tutorials/tyre-wear-database");
        }
    }
}
