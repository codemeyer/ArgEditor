using System.IO;
using System.Linq;
using ArgData.Entities;

namespace ArgEditor.Features.CarSet.HelmetColors
{
    public static class LegacyHelmetFiles
    {
        public static Helmet Load(string path)
        {
            var bytes = File.ReadAllBytes(path).Skip(4).ToArray();

            return new Helmet(bytes);
        }

        public static void Save(HelmetViewModel helmet, string path)
        {
            var helmetBytes = new byte[20];
            helmetBytes[0] = 84;
            helmetBytes[1] = 75;
            helmetBytes[2] = 72;
            helmetBytes[3] = 69;
            helmetBytes[5] = 1;

            helmetBytes[4] = helmet.VisorColorIndex;

            helmetBytes[6] = helmet.Stripe1ColorIndex;
            helmetBytes[7] = helmet.Stripe2ColorIndex;
            helmetBytes[8] = helmet.Stripe3ColorIndex;
            helmetBytes[9] = helmet.Stripe4ColorIndex;
            helmetBytes[10] = helmet.VisorSurroundColorIndex;
            helmetBytes[11] = helmet.Stripe5ColorIndex;
            helmetBytes[12] = helmet.Stripe6ColorIndex;
            helmetBytes[13] = helmet.Stripe7ColorIndex;
            helmetBytes[14] = helmet.Stripe8ColorIndex;
            helmetBytes[15] = helmet.Stripe9ColorIndex;
            helmetBytes[16] = helmet.Stripe10ColorIndex;
            helmetBytes[17] = helmet.Stripe11ColorIndex;
            helmetBytes[18] = helmet.Stripe12ColorIndex;
            helmetBytes[19] = helmet.Stripe13ColorIndex;

            File.WriteAllBytes(path, helmetBytes);
        }
    }
}
