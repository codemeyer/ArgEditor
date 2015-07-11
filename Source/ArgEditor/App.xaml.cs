using System.Windows;
using ArgEditor.ViewModels;
using AutoMapper;

namespace ArgEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Mapper.CreateMap<TeamViewModel, TeamViewModel>();
            Mapper.CreateMap<DriverViewModel, DriverViewModel>();

            base.OnStartup(e);
        }
    }
}
