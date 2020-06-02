using System.Collections.Generic;
using ArgEditor.Infrastructure;

namespace ArgEditor.Features.CarSet.SwapDrivers
{
    public class SwapDriversViewModel : BaseViewModel
    {
        public SwapDriversViewModel(List<TeamViewModel> teams)
        {
            _availableDrivers = new List<DriverViewModel>();

            foreach (var team in teams)
            {
                _availableDrivers.Add(team.Drivers[0]);
                _availableDrivers.Add(team.Drivers[1]);
            }
        }


        private List<DriverViewModel> _availableDrivers;

        public List<DriverViewModel> AvailableDrivers
        {
            get
            {
                return _availableDrivers;
            }
        }


        private DriverViewModel _selectedDriver1;

        public DriverViewModel SelectedDriver1
        {
            get { return _selectedDriver1; }
            set
            {
                SetProperty(ref _selectedDriver1, value, () => SelectedDriver1);
                CalculateCanClickOk();
            }
        }


        private DriverViewModel _selectedDriver2;

        public DriverViewModel SelectedDriver2
        {
            get { return _selectedDriver2; }
            set
            {
                SetProperty(ref _selectedDriver2, value, () => SelectedDriver2);
                CalculateCanClickOk();
            }
        }


        private void CalculateCanClickOk()
        {
            CanClickOk = SelectedDriver1 != null && SelectedDriver2 != null && SelectedDriver1 != SelectedDriver2;
        }


        private bool _canClickOk = false;

        public bool CanClickOk
        {
            get { return _canClickOk; }
            set
            {
                SetProperty(ref _canClickOk, value, () => CanClickOk);
            }
        }

    }
}
