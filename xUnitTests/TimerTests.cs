using ConsoleGameEngine;
using Xunit;

namespace xUnitTests
{
    public class TimerTests
    {
        [Fact]
        public void GetHours_Returns_CorrectValue()
        {
            Timer timer = new Timer();
            string hours = timer.GetHours();
            Assert.Equal("00", hours);
        }

        [Fact]
        public void GetMinutes_Returns_CorrectValue()
        {
            Timer timer = new Timer();
            string minutes = timer.GetMinutes();
            Assert.Equal("00", minutes);
        }

        [Fact]
        public void GetSeconds_Returns_CorrectValue()
        {
            Timer timer = new Timer();
            string seconds = timer.GetSeconds();
            Assert.Equal("00", seconds);
        }

        [Fact]
        public void GetElapsed_Returns_CorrectValue()
        {
            Timer timer = new Timer();
            string elapsed = timer.GetElapsed();
            Assert.Equal("00:00:00", elapsed);
        }
    }
}
