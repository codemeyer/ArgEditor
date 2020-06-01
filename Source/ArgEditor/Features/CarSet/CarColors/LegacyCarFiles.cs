using System.IO;
using System.Linq;
using ArgData.Entities;

namespace ArgEditor.Features.CarSet.CarColors
{
    public static class LegacyCarFiles
    {
        public static Car Load(string path)
        {
            var bytes = File.ReadAllBytes(path).Skip(4).ToArray();

            // rearrange bytes to order expected by Car()
            var newOrder = new byte[16];
            newOrder[0] = 33;
            newOrder[1] = bytes[9];
            newOrder[2] = bytes[13];
            newOrder[3] = bytes[2];
            newOrder[4] = bytes[4];
            newOrder[5] = bytes[8];
            newOrder[6] = bytes[5];
            newOrder[7] = bytes[1];
            newOrder[8] = bytes[14];
            newOrder[9] = 54;
            newOrder[10] = 36;
            newOrder[11] = bytes[15];
            newOrder[12] = bytes[12];
            newOrder[13] = bytes[10];
            newOrder[14] = bytes[11];
            newOrder[15] = bytes[6];

            return new Car(newOrder);
        }

        public static void Save(CarEditingViewModel car, string path)
        {
            var carBytes = new byte[20];
            carBytes[0] = 84;
            carBytes[1] = 75;
            carBytes[2] = 70;
            carBytes[3] = 49;
            carBytes[4] = 33;
            carBytes[5] = car.FrontAndRearWingColorIndex;
            carBytes[6] = car.FrontWingEndplateColorIndex;
            carBytes[7] = 54;
            carBytes[8] = car.RearWingSideColorIndex;
            carBytes[9] = car.SidepodColorIndex;
            carBytes[10] = car.SidepodTopColorIndex;
            carBytes[11] = 36;
            carBytes[12] = car.NoseSideColorIndex;
            carBytes[13] = car.EngineCoverColorIndex;
            carBytes[14] = car.EngineCoverSideColorIndex;
            carBytes[15] = car.EngineCoverRearColorIndex;
            carBytes[16] = car.CockpitSideColorIndex;
            carBytes[17] = car.CockpitFrontColorIndex;
            carBytes[18] = car.NoseTopColorIndex;
            carBytes[19] = car.NoseAngleColorIndex;

            File.WriteAllBytes(path, carBytes);
        }
    }
}
