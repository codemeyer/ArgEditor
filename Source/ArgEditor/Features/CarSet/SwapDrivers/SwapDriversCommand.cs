using ArgEditor.Features.Main;
using ArgEditor.Infrastructure;
using ArgEditor.Mappers;

namespace ArgEditor.Features.CarSet.SwapDrivers
{
    public class SwapDriversCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var mainViewModel = parameter as MainViewModel;

            if (mainViewModel == null)
            {
                return;
            }

            var viewModel = new SwapDriversViewModel(mainViewModel.Teams);

            var window = new SwapDriversWindow
            {
                Owner = System.Windows.Application.Current.MainWindow,
                DataContext = viewModel
            };

            var result = window.ShowDialog();

            if (result == true)
            {
                var driver1 = viewModel.SelectedDriver1;
                var driver2 = viewModel.SelectedDriver2;

                byte origDriver1Number = driver1.Number;
                byte origDriver2Number = driver2.Number;

                var temp = new DriverViewModel(driver2.Number, driver2.Name, driver2.RaceGripLevel, driver2.QualifyingGripLevel);
                Mapper.MapDriverViewModel(driver2, temp);
                Mapper.MapDriverViewModel(driver1, driver2);
                Mapper.MapDriverViewModel(temp, driver1);

                driver1.Number = origDriver1Number;
                driver2.Number = origDriver2Number;
            }
        }
    }
}
