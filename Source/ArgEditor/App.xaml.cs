using System.Collections.Generic;
using System.Windows;
using ArgEditor.Interactors;
using ArgEditor.ViewModels;

namespace ArgEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            CarColorUndoStacks = new Stack<ColorChangeList>[20];
            CarColorRedoStacks = new Stack<ColorChangeList>[20];

            for (int i = 0; i < 20; i++)
            {
                CarColorUndoStacks[i] = new Stack<ColorChangeList>();
                CarColorRedoStacks[i] = new Stack<ColorChangeList>();
            }

            HelmetColorUndoStacks = new Stack<ColorChangeList>[40];
            HelmetColorRedoStacks = new Stack<ColorChangeList>[40];

            for (int i = 0; i < 40; i++)
            {
                HelmetColorUndoStacks[i] = new Stack<ColorChangeList>();
                HelmetColorRedoStacks[i] = new Stack<ColorChangeList>();
            }

            ClipboardCar = null;
            ClipboardHelmet = null;

            base.OnStartup(e);
        }

        public static Stack<ColorChangeList>[] CarColorUndoStacks { get; private set; }
        public static Stack<ColorChangeList>[] CarColorRedoStacks { get; private set; }
        public static Stack<ColorChangeList>[] HelmetColorUndoStacks { get; private set; }
        public static Stack<ColorChangeList>[] HelmetColorRedoStacks { get; private set; }

        public static CarEditingViewModel ClipboardCar { get; set; }
        public static HelmetViewModel ClipboardHelmet { get; set; }
    }
}
