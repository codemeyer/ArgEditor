using System;
using System.Collections;
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

            base.OnStartup(e);
        }

        public static Stack<ColorChange>[] CarColorUndoStacks { get; set; }
        public static Stack<ColorChange>[] CarColorRedoStacks { get; set; }

    }

    public class ColorChange
    {
        public byte OldValue { get; set; }
        public byte NewValue { get; set; }
        public ColorPropertyWrapper Property { get; set; }
        public PaintedElement PaintedElement { get; set; }
    }

    public enum PaintedElement
    {
        Car,
        PitCrew,
        Helmet
    }
}
