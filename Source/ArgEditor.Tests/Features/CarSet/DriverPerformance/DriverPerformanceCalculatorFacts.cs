using System.Collections.Generic;
using System.Linq;
using ArgEditor.Features.CarSet;
using ArgEditor.Features.CarSet.DriverPerformance;
using ArgEditor.Features.Main;
using FluentAssertions;
using Xunit;

namespace ArgEditor.Tests.Features.CarSet.DriverPerformance
{
    public class DriverPerformanceCalculatorFacts
    {
        [Fact]
        public void TwoDriversWithDifferentSkillsAndSameHorsepower_FastestDriverIsFirst()
        {
            var driver1 = new DriverViewModel(1, "Driver Slow", 2, 2);
            var driver2 = new DriverViewModel(2, "Driver Fast", 1, 1);
            var team = new TeamViewModel(0, "Team", "Engine", driver1, driver2);
            team.Horsepower = 716;
            var teams = new List<TeamViewModel> { team };
            var calculator = new DriverPerformanceCalculator();

            var result = calculator.Calculate(teams, PerformanceMetric.Race, TrackTypeValue.Medium);

            result.Count.Should().Be(2);
            result.First().DriverName.Should().Be("Driver Fast");
        }
    }
}
