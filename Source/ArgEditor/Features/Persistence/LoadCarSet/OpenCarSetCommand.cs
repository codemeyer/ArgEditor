using System.Windows.Input;
using ArgEditor.Features.CarSet.MenuImages;
using ArgEditor.Features.Main;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.Persistence.LoadCarSet
{
    public class OpenCarSetCommand : CommandBase
    {
        private readonly IFileDialog _fileDialog;

        public OpenCarSetCommand(IFileDialog fileDialog)
        {
            _fileDialog = fileDialog;
        }

        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;

            if (viewModel == null) { return; }

            string path = _fileDialog.SelectCarSetFileToOpen();

            if (string.IsNullOrEmpty(path)) { return; }

            // HACK: stupid temporary workaround to avoid not updating a textbox that currently has focus
            //hiddenTextElement.Focus();
            // not needed anymore?

            Mouse.OverrideCursor = Cursors.Wait;

            try
            {
                MainViewModelPasserArounder.MainViewModel.IsLoading = true;

                if (path.ToLowerInvariant().EndsWith(".arged"))
                {
                    var loader = new CarSetLoader();
                    loader.Load(viewModel, path);
                }
                if (path.ToLowerInvariant().EndsWith(".1ed"))
                {
                    LegacyCarSetLoader.IntoViewModel(viewModel, path);
                }

                // TODO: unknown file? try to read as arged?
            }
            finally
            {
                MainViewModelPasserArounder.MainViewModel.IsLoading = false;
                Mouse.OverrideCursor = null;
            }
        }
    }




    //public class OpenCarSetCommand : RelayCommand
    //{
    //    public OpenCarSetCommand(Action<object> execute) : base(execute)
    //    {
    //    }

    //    public OpenCarSetCommand(Action<object> execute, Predicate<object> canExecute) : base(execute, canExecute)
    //    {
    //    }

    //    public bool CanOpenCarSet()
    //    {
    //        return true;
    //    }

    //    public void OpenCarSet(MainViewModel viewModel)
    //    {
    //        if (viewModel == null) { return; }

    //        string path = FileDialog.SelectArgEditorFileToOpen();

    //        if (string.IsNullOrEmpty(path)) { return; }

    //        // HACK: stupid temporary workaround to avoid not updating a textbox that currently has focus
    //        //hiddenTextElement.Focus();
    //        // not needed anymore?

    //        if (path.ToLowerInvariant().EndsWith(".arged"))
    //        {
    //            var loader = new CarSetLoader();
    //            loader.Load(viewModel, path);
    //        }
    //        if (path.ToLowerInvariant().EndsWith(".1ed"))
    //        {
    //            LegacyCarSetLoader.IntoViewModel(viewModel, path);
    //        }

    //        // TODO: unknown file? try to read as arged?
    //    }
    //}

    //public class RelayCommand : ICommand
    //{
    //    readonly Action<object> _execute;
    //    readonly Predicate<object> _canExecute;

    //    public RelayCommand(Action<object> execute) : this(execute, null)
    //    {
    //    }

    //    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    //    {
    //        //if (execute == null)
    //        //    throw new ArgumentNullException("execute");
    //        _execute = execute;
    //        _canExecute = canExecute;
    //    }

    //    public bool CanExecute(object parameter)
    //    {
    //        return _canExecute?.Invoke(parameter) ?? true;
    //    }

    //    public void Execute(object parameter)
    //    {
    //        _execute(parameter);
    //    }


    //    //public bool SuperCanSave()
    //    //{
    //    //    return true;
    //    //}

    //    //public void SuperSave()
    //    //{
    //    //}

    //    public event EventHandler CanExecuteChanged
    //    {
    //        add { CommandManager.RequerySuggested += value; }
    //        remove { CommandManager.RequerySuggested -= value; }
    //    }
    //}
}
