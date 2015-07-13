using System.Windows;
using ArgEditor.Interactors;
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
            Mapper.CreateMap<TeamViewModel, CarSetTeam>();
            Mapper.CreateMap<DriverViewModel, CarSetDriver>();
            Mapper.CreateMap<CarEditingViewModel, CarSetCarColors>();
            Mapper.CreateMap<PitCrewViewModel, CarSetPitCrewColors>();

            Mapper.CreateMap<CarSetTeam, TeamViewModel>();
            Mapper.CreateMap<CarSetDriver, DriverViewModel>();
            Mapper.CreateMap<CarSetCarColors, CarEditingViewModel>();
            Mapper.CreateMap<CarSetPitCrewColors, PitCrewViewModel>();

            base.OnStartup(e);
        }
    }
}
