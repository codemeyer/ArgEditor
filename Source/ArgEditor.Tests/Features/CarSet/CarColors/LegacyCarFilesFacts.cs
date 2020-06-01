using ArgEditor.Features.CarSet.CarColors;
using FluentAssertions;
using System.IO;
using Xunit;

namespace ArgEditor.Tests.Features.CarSet.CarColors
{
    public class LegacyCarFilesFacts
    {
        [Fact]
        public void Load_Jordan_Has_Correct_Colors()
        {
            var path = ExampleDataHelper.GetExampleDataPath("JORDAN91.CAR");
            var car = LegacyCarFiles.Load(path);

            car.CockpitFront.Should().Be(72);
            car.CockpitSide.Should().Be(71);
            car.EngineCover.Should().Be(71);
            car.EngineCoverRear.Should().Be(71);
            car.EngineCoverSide.Should().Be(71);
            car.FrontAndRearWing.Should().Be(72);
            car.FrontWingEndplate.Should().Be(70);
            car.NoseAngle.Should().Be(71);
            car.NoseSide.Should().Be(91);
            car.NoseTop.Should().Be(72);
            car.RearWingSide.Should().Be(70);
            car.Sidepod.Should().Be(92);
            car.SidepodTop.Should().Be(72);
        }

        [Fact]
        public void Save_Stores_Properties_In_Correct_Locations()
        {
            var carViewModel = OrderedCarEditingViewModel();

            var temp = Path.GetTempFileName();
            LegacyCarFiles.Save(carViewModel, temp);

            var savedCar = LegacyCarFiles.Load(temp);

            savedCar.CockpitFront.Should().Be(1);
            savedCar.CockpitSide.Should().Be(2);
            savedCar.EngineCover.Should().Be(3);
            savedCar.EngineCoverRear.Should().Be(4);
            savedCar.EngineCoverSide.Should().Be(5);
            savedCar.FrontAndRearWing.Should().Be(6);
            savedCar.FrontWingEndplate.Should().Be(7);
            savedCar.NoseAngle.Should().Be(8);
            savedCar.NoseSide.Should().Be(9);
            savedCar.NoseTop.Should().Be(10);
            savedCar.RearWingSide.Should().Be(11);
            savedCar.Sidepod.Should().Be(12);
            savedCar.SidepodTop.Should().Be(13);

            try
            {
                File.Delete(temp);
            }
            catch
            {
            }
        }

        [Fact]
        public void Save_Stores_HardCoded_Values()
        {
            var carViewModel = OrderedCarEditingViewModel();

            var temp = Path.GetTempFileName();
            LegacyCarFiles.Save(carViewModel, temp);

            byte[] bytes = File.ReadAllBytes(temp);

            bytes[0].Should().Be(84);
            bytes[1].Should().Be(75);
            bytes[2].Should().Be(70);
            bytes[3].Should().Be(49);
            bytes[4].Should().Be(33);
            bytes[7].Should().Be(54);
            bytes[11].Should().Be(36);

            try
            {
                File.Delete(temp);
            }
            catch
            {
            }
        }

        private CarEditingViewModel OrderedCarEditingViewModel()
        {
            return new CarEditingViewModel
            {
                CockpitFrontColorIndex = 1,
                CockpitSideColorIndex = 2,
                EngineCoverColorIndex = 3,
                EngineCoverRearColorIndex = 4,
                EngineCoverSideColorIndex = 5,
                FrontAndRearWingColorIndex = 6,
                FrontWingEndplateColorIndex = 7,
                NoseAngleColorIndex = 8,
                NoseSideColorIndex = 9,
                NoseTopColorIndex = 10,
                RearWingSideColorIndex = 11,
                SidepodColorIndex = 12,
                SidepodTopColorIndex = 13
            };
        }
    }
}
