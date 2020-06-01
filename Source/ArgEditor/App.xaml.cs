using System.Collections.Generic;
using System.Windows;
using ArgEditor.Features.CarSet.CarColors;
using ArgEditor.Features.CarSet.HelmetColors;
using ArgEditor.Features.CarSet.MenuImages;
using ArgEditor.Features.CarSetupEditing;
using ArgEditor.Features.ImportExport.ExportTo;
using ArgEditor.Features.ImportExport.ImportFrom;
using ArgEditor.Features.Main;
using ArgEditor.Features.UndoRedo;

namespace ArgEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            CarColorUndoStacks = new Stack<ColorChangeList>[ArgEditorConstants.TeamCountSupported];
            CarColorRedoStacks = new Stack<ColorChangeList>[ArgEditorConstants.TeamCountSupported];

            for (int i = 0; i < ArgEditorConstants.TeamCountSupported; i++)
            {
                CarColorUndoStacks[i] = new Stack<ColorChangeList>();
                CarColorRedoStacks[i] = new Stack<ColorChangeList>();
            }

            HelmetColorUndoStacks = new Stack<ColorChangeList>[ArgEditorConstants.DriverCountSupported];
            HelmetColorRedoStacks = new Stack<ColorChangeList>[ArgEditorConstants.DriverCountSupported];

            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                HelmetColorUndoStacks[i] = new Stack<ColorChangeList>();
                HelmetColorRedoStacks[i] = new Stack<ColorChangeList>();
            }

            MenuImageUndoStacks = new Stack<PixelDataChange>[ArgEditorConstants.DriverCountSupported];
            MenuImageRedoStacks = new Stack<PixelDataChange>[ArgEditorConstants.DriverCountSupported];

            for (int i = 0; i < ArgEditorConstants.DriverCountSupported; i++)
            {
                MenuImageUndoStacks[i] = new Stack<PixelDataChange>();
                MenuImageRedoStacks[i] = new Stack<PixelDataChange>();
            }

            ClipboardCar = null;
            ClipboardHelmet = null;
            ClipboardSetup = null;
            ClipboardMenuImage = null;

            if (e.Args.Length > 0)
            {
                MainViewModelPasserArounder.QueueLoad(e.Args[0]);
            }

            base.OnStartup(e);
        }

        public static Stack<ColorChangeList>[] CarColorUndoStacks { get; private set; }
        public static Stack<ColorChangeList>[] CarColorRedoStacks { get; private set; }
        public static Stack<ColorChangeList>[] HelmetColorUndoStacks { get; private set; }
        public static Stack<ColorChangeList>[] HelmetColorRedoStacks { get; private set; }

        public static Stack<PixelDataChange>[] MenuImageUndoStacks { get; private set; }
        public static Stack<PixelDataChange>[] MenuImageRedoStacks { get; private set; }

        public static CarEditingViewModel ClipboardCar { get; set; }
        public static HelmetViewModel ClipboardHelmet { get; set; }
        public static SetupViewModel ClipboardSetup { get; set; }
        public static byte[] ClipboardMenuImage { get; set; }

        // better place for this?
        public static ImportViewModel LatestImportViewModel { get; set; }
        public static ExportViewModel LatestExportViewModel { get; set; }
        public static BrowseCarColorsViewModel LatestBrowseCarColorsViewModel { get; set; }
        public static BrowseHelmetColorsViewModel LatestBrowseHelmetColorsViewModel { get; set; }
    }
}
