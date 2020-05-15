using System.Diagnostics;
using ArgEditor.Features.Main;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.Application.Shared
{
    public class HelpDocsCommand : CommandBase
    {
        private readonly string _known;

        public HelpDocsCommand()
        {
        }

        public HelpDocsCommand(string known)
        {
            _known = known;
        }

        public override void Execute(object parameter)
        {
            if (!string.IsNullOrEmpty(_known))
            {
                OpenWebSitePage(_known);
                return;
            }

            var vm = parameter as MainViewModel;

            if (vm == null)
            {
                OpenWebSitePage();
                return;
            }

            if (vm.SelectedMainTabIndex == 0)       // carset
            {
                if (vm.SelectedCarSetTabIndex == 0)
                {
                    OpenWebSitePage("carset-screen/#teams-and-drivers-tab");
                    return;
                }

                if (vm.SelectedCarSetTabIndex == 1)
                {
                    OpenWebSitePage("carset-screen/#performance-tab");
                    return;
                }

                if (vm.SelectedCarSetTabIndex == 2)
                {
                    OpenWebSitePage("carset-screen/#cars-tab");
                    return;
                }

                if (vm.SelectedCarSetTabIndex == 3)
                {
                    OpenWebSitePage("carset-screen/#helmets-tab");
                    return;
                }

                if (vm.SelectedCarSetTabIndex == 4)
                {
                    OpenWebSitePage("carset-screen/#menu-images-tab");
                    return;
                }

                if (vm.SelectedCarSetTabIndex == 5)
                {
                    OpenWebSitePage("carset-screen/#points-system-tab");
                    return;
                }
            }

            if (vm.SelectedMainTabIndex == 1)       // game settings
            {
                OpenWebSitePage("settings-screen/");
                return;
            }

            if (vm.SelectedMainTabIndex == 2)       // setups
            {
                // TODO: implement selected setups tab
                OpenWebSitePage("setups-screen/");
                return;
            }

            if (vm.SelectedMainTabIndex == 3)       // help/about
            {
                OpenWebSitePage("help-about-screen/");
                return;
            }

            // fallback
            OpenWebSitePage();
        }

        private void OpenWebSitePage(string relativeChildUrl = "")
        {
            var fullUrl = $"https://www.argtools.com/argeditor/{relativeChildUrl}";

            Process.Start(fullUrl);
        }
    }
}
