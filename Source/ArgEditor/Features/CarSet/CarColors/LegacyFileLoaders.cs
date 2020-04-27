using System.IO;
using System.Linq;
using ArgData.Entities;

namespace ArgEditor.Features.CarSet.CarColors
{
    public static class LegacyCarFileLoader
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
    }

    public static class LegacyHelmetFileLoader
    {
        public static Helmet Load(string path)
        {
            var bytes = File.ReadAllBytes(path).Skip(4).ToArray();

            return new Helmet(bytes);
        }
    }
}
