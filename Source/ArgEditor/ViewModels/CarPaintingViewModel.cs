using System.Collections.Generic;

namespace ArgEditor.ViewModels
{
    public class CarPaintingViewModel
    {
        public List<CarEditingViewModel> Cars { get; set; }

        public CarPaintingViewModel()
        {
            Cars = new List<CarEditingViewModel>();

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 47, 62, 44, 58, 32, 44, 47, 47, 46, 47, 47, 62, 47 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 34, 47, 45, 56, 33, 33, 32, 47, 46, 46, 46, 46, 34 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 110, 111, 86, 86, 84, 44, 47, 89, 87, 86, 86, 87, 47 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 89, 87, 86, 86, 45, 86, 46, 88, 46, 46, 46, 46, 89 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 46, 47, 45, 45, 63, 45, 47, 47, 46, 46, 46, 46, 47 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 46, 47, 70, 70, 69, 44, 46, 47, 46, 46, 46, 46, 74 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 36, 38, 32, 47, 35, 59, 37, 38, 36, 36, 36, 36, 61 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 70, 231, 228, 228, 226, 228, 32, 231, 229, 229, 46, 46, 231 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 46, 47, 44, 44, 43, 44, 32, 47, 46, 46, 46, 46, 47 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 110, 111, 107, 86, 72, 85, 111, 75, 74, 110, 110, 110, 90 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 62, 47, 57, 57, 56, 57, 60, 62, 61, 46, 46, 46, 62 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 32, 33, 32, 109, 32, 32, 111, 33, 34, 34, 47, 110, 36 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 94, 95, 32, 32, 92, 32, 95, 95, 94, 94, 94, 94, 95 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 60, 61, 32, 32, 32, 56, 32, 61, 60, 60, 60, 60, 61 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 32, 61, 32, 32, 32, 32, 111, 62, 34, 34, 60, 60, 36 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 94, 40, 45, 45, 45, 45, 47, 40, 39, 39, 39, 39, 47 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 71, 72, 70, 70, 91, 92, 72, 72, 71, 71, 71, 71, 72 }
                ));

            Cars.Add(new CarEditingViewModel(
                    new byte[] { 88, 88, 32, 32, 86, 86, 33, 88, 87, 87, 87, 87, 88 }
                ));
        }
    }
}
