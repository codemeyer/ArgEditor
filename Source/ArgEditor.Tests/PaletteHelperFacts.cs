using FluentAssertions;
using Xunit;

namespace ArgEditor.Tests
{
    public class PaletteHelperFacts
    {
        [Fact]
        public void GetColor_ReturnsExpectedColor()
        {
            var color = PaletteHelper.GetColor(123);

            color.R.Should().Be(92);
            color.G.Should().Be(44);
            color.B.Should().Be(0);
        }
    }
}
