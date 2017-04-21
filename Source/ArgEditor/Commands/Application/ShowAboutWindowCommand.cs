using System.Windows;
using ArgEditor.Windows;

namespace ArgEditor.Commands
{
    public class ShowAboutWindowCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var about = new AboutWindow
            {
                Owner = Application.Current.MainWindow
            };

            about.ShowDialog();
        }
    }
}
