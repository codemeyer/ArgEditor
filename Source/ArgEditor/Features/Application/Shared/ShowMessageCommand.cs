using System.Windows;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.Application.Shared
{
    public class ShowWarningMessageCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            MessageBox.Show(parameter.ToString(), "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
    public class ShowErrorMessageCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            MessageBox.Show(parameter.ToString(), "ArgEditor", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // ?
    public class ShowMessageCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            // TODO: expand and improve :)
            MessageBox.Show(parameter.ToString());
        }
    }
}
