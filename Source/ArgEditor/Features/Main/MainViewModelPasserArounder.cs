namespace ArgEditor.Features.Main
{
    // TODO: get rid of this
    public static class MainViewModelPasserArounder
    {
        // TODO: get rid of this
        public static MainViewModel MainViewModel { get; set; }

        public static void QueueLoad(string path)
        {
            LoadingQueued = true;
            LoadPath = path;
        }

        public static string LoadPath { get; set; }

        public static bool LoadingQueued { get; set; }
    }
}
