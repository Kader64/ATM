using ATM.Resources.BaseClasses;
using ConsoleGameEngine;
using Xunit;

namespace xUnitTests
{
    public class PlayerTests
    {
        [Fact]
        public void Constructor_InitializesProperties()
        {
            int posX = 10;
            int posY = 20;
            Player player = new Player(posX, posY);
            Assert.Equal(posX, player.PosX);
            Assert.Equal(posY, player.PosY);
            Assert.Equal(5, player.Width);
            Assert.Equal(10, player.Height);
            Assert.Equal(EscapeColor.Color("Red"), player.Color);
        }

        [Fact]
        public void Move_UpdatesPosition()
        {
            Player player = new Player(0, 0);
            player.Move(10, 20);
            Assert.Equal(10, player.PosX);
            Assert.Equal(20, player.PosY);
        }

        [Fact]
        public void SetPos_UpdatesPosition()
        {
            Player player = new Player(0, 0);
            player.SetPos(10, 20);
            Assert.Equal(10, player.PosX);
            Assert.Equal(20, player.PosY);
        }

        [Fact]
        public void Collides_ReturnsTrue_IfColliding()
        {
            Player player = new Player(0, 0);
            GameObject obj = new GameObject("Obj",0, 0, 5, 5, "Red");

            bool collides = player.Collides(obj);
            Assert.True(collides);
        }
    }
}