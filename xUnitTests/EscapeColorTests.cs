using ConsoleGameEngine;
using Xunit;

namespace xUnitTests
{
    public class EscapeColorTests
    {
        [Fact]
        public void Color_ReturnsCorrectColor_WhenValidColorNameIsPassed()
        {
            string expected = "\x1b[37m";
            string colorName = "White";

            string actual = EscapeColor.Color(colorName);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Color_ReturnsDefaultColor_WhenInvalidColorNameIsPassed()
        {
            string expected = "\x1b[37m";
            string colorName = "InvalidColor";

            string actual = EscapeColor.Color(colorName);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ColorRGB_ReturnsCorrectColor_WhenValidRGBValuesArePassed()
        {
            string expected = "\x1b[38;2;255;255;255m";
            int r = 255;
            int g = 255;
            int b = 255;

            string actual = EscapeColor.ColorRGB(r, g, b);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Random_ReturnsValidColor()
        {
            string[] validColors = { "\x1b[37m", "\x1b[31m", "\x1b[32m", "\x1b[34m", "\x1b[33m", "\x1b[35m", "\x1b[36m" };

            string actual = EscapeColor.Random();

            Assert.Contains(actual, validColors);
        }
    }
}