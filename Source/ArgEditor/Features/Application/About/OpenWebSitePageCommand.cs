using System.Diagnostics;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.Application.About
{
    public class OpenWebSitePageCommand : CommandBase
    {
        private readonly string _url;

        public OpenWebSitePageCommand(string url)
        {
            _url = url;
        }

        public override void Execute(object parameter)
        {
            if (string.IsNullOrEmpty(_url))
            {
                return;
            }

            Process.Start(_url);
        }
    }
}
