using System.Collections.Generic;
using System.Linq;
using ArgEditor.Interactors;
using ArgEditor.ViewModels;
using FluentAssertions;
using Xunit;

namespace ArgEditor.Tests.Interactors
{
    public class DriverPerformanceCalculatorFacts
    {
        // TODO: reinstate the man!
        //[Fact]
        //public void TwoDriversWithDifferentSkillsAndSameHorsepower_FastestDriverIsFirst()
        //{
        //    var driver1 = new DriverViewModel(1, "Driver Slow", 2, 2);
        //    var driver2 = new DriverViewModel(2, "Driver Fast", 1, 1);
        //    var team = new TeamViewModel(0, "Team", "Engine", driver1, driver2);
        //    team.Horsepower = 716;
        //    var teams = new List<TeamViewModel> { team };
        //    var calculator = new DriverPerformanceCalculator();

        //    var result = calculator.Calculate(teams, PerformanceMetric.Race, TrackTypeValue.Medium);

        //    result.Count.Should().Be(2);
        //    result.First().DriverName.Should().Be("Driver Fast");
        //}


        //[Fact]
        //public void Hej()
        //{
        //    var grip = 1; //default
        //    var skill = 1; // Senna
        //    var bhp = 716;

        //    var sennaTajm = SilverTajm(1, 1, 716);
        //    var chavesTajm = SilverTajm(1, 34, 610);
        //    var martiniTajm = SilverTajm(1, 11, 665);

        //    //var handicap = -25 * grip + 4 * skill + 2500;

        //    sennaTajm.Should().Be(0);
        //}

        //private double SilverTajm(int grip, int skill, int bhp)
        //{
        //    //var grip = 1; //default
        //    //var skill = 1; // Senna
        //    //var bhp = 716;

        //    var handicap = -25 * grip + 4 * skill + 2500;

        //    // 8: 115912. - 42.3588 x + 0.0159304 x^2 - 24.3641 y + 0.00782616 y^2
        //    // x = bhp
        //    // y = handicap
        //    // 8: 115912. - 42.3588 bhp + 0.0159304 bhp^2 - 24.3641 handi + 0.00782616 handi^2

        //    var bhp1 = 42.3588 * bhp;
        //    //var bhp2 = 0.0159304 * (bhp ^ 2);
        //    var bhp2 = 0.0159304 * bhp * bhp;
        //    //var bhp3 = bhp2 * bhp2;

        //    var handi1 = 24.3641 * handicap;
        //    //var handi2 = 0.00782616 * (handicap ^ 2);
        //    var handi2 = 0.00782616 * handicap * handicap;
        //    //handi2 *= handi2;
        //    //var handi3 = handi2 * handi2;

        //    var tajm = 115912.0 - bhp1 + bhp2 - handi1 + handi2;

        //    return tajm;
        //}
    }
}
