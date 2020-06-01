using ArgEditor.Features.CarSet.CarColors;
using ArgEditor.Features.CarSet.HelmetColors;
using FluentAssertions;
using System.IO;
using Xunit;

namespace ArgEditor.Tests.Features.CarSet.HelmetColors
{
    public class LegacyHelmetFilesFacts
    {
        [Fact]
        public void Martini_Helmet_Has_Correct_Colors()
        {
            var path = ExampleDataHelper.GetExampleDataPath("MARTINI.HEL");
            var helmet = LegacyHelmetFiles.Load(path);

            helmet.Visor.Should().Be(0);
            helmet.VisorSurround.Should().Be(6);
            helmet.Stripes[0].Should().Be(111);
            helmet.Stripes[1].Should().Be(111);
            helmet.Stripes[2].Should().Be(63);
            helmet.Stripes[3].Should().Be(47);
            helmet.Stripes[4].Should().Be(47);
            helmet.Stripes[5].Should().Be(79);
            helmet.Stripes[6].Should().Be(47);
            helmet.Stripes[7].Should().Be(47);
            helmet.Stripes[8].Should().Be(63);
            helmet.Stripes[9].Should().Be(47);
            helmet.Stripes[10].Should().Be(47);
            helmet.Stripes[11].Should().Be(79);
            helmet.Stripes[12].Should().Be(47);
        }

        [Fact]
        public void Save_Helmet_Stored_Correctly()
        {
            var helmetViewModel = OrderedHelmetViewModel();

            var temp = Path.GetTempFileName();
            LegacyHelmetFiles.Save(helmetViewModel, temp);

            var savedHelmet = LegacyHelmetFiles.Load(temp);
            savedHelmet.Visor.Should().Be(100);
            savedHelmet.VisorSurround.Should().Be(200);
            savedHelmet.Stripes[0].Should().Be(11);
            savedHelmet.Stripes[1].Should().Be(12);
            savedHelmet.Stripes[2].Should().Be(13);
            savedHelmet.Stripes[3].Should().Be(14);
            savedHelmet.Stripes[4].Should().Be(15);
            savedHelmet.Stripes[5].Should().Be(16);
            savedHelmet.Stripes[6].Should().Be(17);
            savedHelmet.Stripes[7].Should().Be(18);
            savedHelmet.Stripes[8].Should().Be(19);
            savedHelmet.Stripes[9].Should().Be(20);
            savedHelmet.Stripes[10].Should().Be(21);
            savedHelmet.Stripes[11].Should().Be(22);
            savedHelmet.Stripes[12].Should().Be(23);

            try
            {
                File.Delete(temp);
            }
            catch
            {
            }
        }

        [Fact]
        public void Save_Helmet_Stores_HardCoded_Values()
        {
            var helmetViewModel = OrderedHelmetViewModel();

            var temp = Path.GetTempFileName();
            LegacyHelmetFiles.Save(helmetViewModel, temp);

            byte[] bytes = File.ReadAllBytes(temp);

            bytes[0].Should().Be(84);
            bytes[1].Should().Be(75);
            bytes[2].Should().Be(72);
            bytes[3].Should().Be(69);
            bytes[5].Should().Be(1);

            try
            {
                File.Delete(temp);
            }
            catch
            {
            }
        }

        private HelmetViewModel OrderedHelmetViewModel()
        {
            var helmetViewModel = new HelmetViewModel(null)
            {
                VisorColorIndex = 100,
                VisorSurroundColorIndex = 200,
                Stripe1ColorIndex = 11,
                Stripe2ColorIndex = 12,
                Stripe3ColorIndex = 13,
                Stripe4ColorIndex = 14,
                Stripe5ColorIndex = 15,
                Stripe6ColorIndex = 16,
                Stripe7ColorIndex = 17,
                Stripe8ColorIndex = 18,
                Stripe9ColorIndex = 19,
                Stripe10ColorIndex = 20,
                Stripe11ColorIndex = 21,
                Stripe12ColorIndex = 22,
                Stripe13ColorIndex = 23
            };

            return helmetViewModel;
        }
    }
}
