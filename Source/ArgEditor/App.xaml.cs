using System.Collections.Generic;
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


            CarColorUndoStacks = new Stack<ColorChange>[20];
            CarColorRedoStacks = new Stack<ColorChange>[20];

            for (int i = 0; i < 20; i++)
            {
                CarColorUndoStacks[i] = new Stack<ColorChange>();
                CarColorRedoStacks[i] = new Stack<ColorChange>();
            }

            HelmetColorUndoStacks = new Stack<ColorChange>[40];
            HelmetColorRedoStacks = new Stack<ColorChange>[40];

            for (int i = 0; i < 40; i++)
            {
                HelmetColorUndoStacks[i] = new Stack<ColorChange>();
                HelmetColorRedoStacks[i] = new Stack<ColorChange>();
            }

            base.OnStartup(e);
        }

        public static Stack<ColorChange>[] CarColorUndoStacks { get; private set; }
        public static Stack<ColorChange>[] CarColorRedoStacks { get; private set; }
        public static Stack<ColorChange>[] HelmetColorUndoStacks { get; private set; }
        public static Stack<ColorChange>[] HelmetColorRedoStacks { get; private set; }
    }
}
