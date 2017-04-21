using System.Windows;
using ArgEditor.Windows;

namespace ArgEditor.Commands
{
    public class ShowCheckForUpdatesWindowCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var checkUpdates = new CheckVersionWindow
            {
                Owner = Application.Current.MainWindow
            };

            checkUpdates.ShowDialog();
        }
    }
}
