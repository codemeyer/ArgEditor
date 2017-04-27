using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArgEditor.Interactors;
using ArgEditor.Interactors.LegacyCarSets;
using FluentAssertions;
using Xunit;

namespace ArgEditor.Tests.Interactors
{
    public class LegacyCarSetFacts
    {
        public class ReadingDefault1991Carset
        {
            private readonly LegacyCarSet _carset;

            public ReadingDefault1991Carset()
            {
                var path = ExampleDataHelper.GetExampleDataPath("1991.1ED");
                _carset = LegacyCarSetLoader.Load(path);
            }

            [Fact]
            public void FirstTeamIsMcLaren()
            {
                var team = _carset.Teams[0];
                team.Name.Should().Be("McLaren");
                team.Engine.Should().Be("Honda");
                team.Driver1Number.Should().Be(1);
                team.Driver2Number.Should().Be(2);
                team.Horsepower.Should().Be(716);
            }

            [Fact]
            public void FirstTeamHasMcLarenCarColors()
            {
                var colors = _carset.Teams[0].CarColors;
                colors.Length.Should().Be(16);
                colors[0].Should().Be(33);
                colors[4].Should().Be(58);
                colors[8].Should().Be(47);
                colors[12].Should().Be(47);
                colors[15].Should().Be(47);
            }

            [Fact]
            public void FirstTeamHasCrewWithMcLarenPitCrewColors()
            {
                var colors = _carset.Teams[0].PitCrewColors;
                colors.Length.Should().Be(16);
                colors[3].Should().Be(40);
                colors[4].Should().Be(58);
                colors[11].Should().Be(56);
            }

            [Fact]
            public void EighteenthTeamIsModena()
            {
                var team = _carset.Teams[17];
                team.Name.Should().Be("Modena");
                team.Engine.Should().Be("Lamborghini");
                team.Driver1Number.Should().Be(34);
                team.Driver2Number.Should().Be(35);
                team.Horsepower.Should().Be(615);
            }

            [Fact]
            public void EighteenthTeamHasModenaColors()
            {
                var colors = _carset.Teams[17].CarColors;
                colors.Length.Should().Be(16);
                colors[0].Should().Be(33);
                colors[4].Should().Be(45);
                colors[8].Should().Be(40);
                colors[12].Should().Be(39);
                colors[15].Should().Be(47);
            }

            [Fact]
            public void Driver1IsAyrtonSenna()
            {
                var driver = _carset.Drivers[0];
                driver.Name.Should().Be("Ayrton Senna");
                driver.QualifyingPerformance.Should().Be(1);
                driver.RacePerformance.Should().Be(1);
            }

            [Fact]
            public void Driver5IsNigelMansell()
            {
                var driver = _carset.Drivers[4];
                driver.Name.Should().Be("Nigel Mansell");
                driver.QualifyingPerformance.Should().Be(3);
                driver.RacePerformance.Should().Be(2);
            }

            [Fact]
            public void McLarenFirstDriverByNumberIsAyrtonSenna()
            {
                var number = _carset.Teams[0].Driver1Number;
                var driver = _carset.Drivers.FirstOrDefault(d => d.Number == number);

                driver.Name.Should().Be("Ayrton Senna");
            }

            [Fact]
            public void AyrtonSennaHasCorrectHelmetColors()
            {
                var driver = _carset.Drivers[0];
                driver.HelmetColors.Length.Should().Be(16);
                driver.HelmetColors[0].Should().Be(0);
                driver.HelmetColors[2].Should().Be(111);
                driver.HelmetColors[11].Should().Be(95);
            }

            [Fact]
            public void NigelMansellHasCorrecthelmetColors()
            {
                var driver = _carset.Drivers[4];
                driver.HelmetColors.Length.Should().Be(16);
                driver.HelmetColors[0].Should().Be(0);
                driver.HelmetColors[2].Should().Be(63);
                driver.HelmetColors[10].Should().Be(47);
            }

            [Fact]
            public void KnownSettingsAreRead()
            {
                _carset.Settings.GeneralGripLevel.Should().Be(1);
                _carset.Settings.PlayerHorsepower.Should().Be(716);
                _carset.Settings.ChanceOfRain.Should().Be(6);
                _carset.Settings.RainAtFirstTrack.Should().BeFalse();

                _carset.Settings.RetireHitWall.Should().Be(7424);
                _carset.Settings.RetireHitCar.Should().Be(8192);
                _carset.Settings.DamageHitCar.Should().Be(1792);
                _carset.Settings.DamageHitWall.Should().Be(1792);
                _carset.Settings.YellowFlags.Should().Be(20);
                _carset.Settings.RemoveCars.Should().Be(15);
            }
        }

        public class Write1991
        {
            private readonly List<string> _lines;
            private readonly LegacyCarSet _sourceCarSet;

            public Write1991()
            {
                var path = ExampleDataHelper.GetExampleDataPath("1991.1ED");
                _sourceCarSet = LegacyCarSetLoader.Load(path);
                _lines = LegacyCarSetSaver.GenerateLines(_sourceCarSet);
            }

            [Fact]
            public void WritingToFile()
            {
                var path = Path.GetTempFileName();
                LegacyCarSetSaver.Save(_sourceCarSet, path);

                var savedLines = File.ReadAllLines(path);

                savedLines.Should().BeEquivalentTo(_lines);

                try
                {
                    File.Delete(path);
                }
                catch { }
            }

            [Fact]
            public void DriversAreWritten()
            {
                _lines[0].Should().Be("[Drivers]");
                _lines[1].Should().Be("1=Ayrton Senna,1,1,0");
                _lines[35].Should().Be("35=Eric van de Poele,33,33,0");
                _lines[40].Should().Be("40=Spare40,0,0,0");
            }

            [Fact]
            public void TeamsAreWritten()
            {
                _lines[41].Should().Be("[Teams]");
                _lines[42].Should().Be("1=McLaren,Honda,716,1,2");
                _lines[59].Should().Be("18=Modena,Lamborghini,615,34,35");
                _lines[61].Should().Be("20=Not Used,Not Used,0,0,0");
            }

            [Fact]
            public void CarColorsAreWritten()
            {
                _lines[62].Should().Be("[CarColours]");

                _lines[63].Should().Be("1=33,47,62,44,58,32,44,47,47,56,36,46,47,47,62,47");
                _lines[80].Should().Be("18=33,94,40,45,45,45,45,47,40,45,36,39,39,39,39,47");
                _lines[82].Should().Be("20=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
            }

            [Fact]
            public void PitCrewColorsAreWritten()
            {
                _lines[83].Should().Be("[PitColours]");

                _lines[84].Should().Be("1=0,1,202,40,58,43,46,7,8,205,10,56,12,13,14,15");
                _lines[101].Should().Be("18=0,1,202,40,74,43,46,7,8,205,10,70,12,13,14,15");
                //_lines[103].Should().Be("20=0,1,202,0,0,0,0,7,8,205,10,0,12,13,14,15");
                _lines[103].Should().Be("20=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
                // TODO: we'll see?
            }

            [Fact]
            public void HelmetColorsAreWritten()
            {
                _lines[104].Should().Be("[HelmetColours]");

                _lines[105].Should().Be("1=0,1,111,111,111,111,6,79,79,111,111,95,111,111,111,111");
                _lines[139].Should().Be("35=0,1,63,63,95,95,6,79,63,79,79,63,79,95,63,63");
                _lines[144].Should().Be("40=0,1,79,79,79,79,6,79,79,79,79,79,79,79,79,79");  //?
                //_lines[144].Should().Be("40=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");  //?
                // TODO: we'll see?
            }

            [Fact]
            public void Settings()
            {
                _lines[145].Should().Be("[F1Ed]");
                _lines[146].Should().Be("AIGrip=1");
                _lines[147].Should().Be("HumanBHP=716");
                _lines[167].Should().Be("WetRacePhoenix=0");
                _lines[168].Should().Be("WetRace=6");
            }

            [Fact]
            public void HardcodedStuff()
            {
                //
                _lines[207].Should().Be("[ComputerCarSetup]");
                _lines[383].Should().Be("16Gear6=61");
            }

            [Fact]
            public void ShouldHave384Lines()
            {
                _lines.Count.Should().Be(384);
            }

            //[Fact]
            //public void CleanupTheLegacyCodeMaaan()
            //{
            //    // LOL
            //    true.Should().BeFalse();
            //}
        }
    }
}
