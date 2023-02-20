using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.BaseClasses
{
    class Floor : GameObject
    {
        public Floor(int posX, int posY, int objW, int objH, string objColor) : base(posX, posY)
        {
            this.Width = objW;
            this.Height = objH;
            this.PosX = posX;
            this.PosY = posY;
            this.Color = objColor;
        }

        public override void Render(ASCIICanvas canvas)
        {
            base.Render(canvas);
        }

        public override void OnCollision(Player player)
        {
            player.SetPos(player.PosX, this.PosY - player.Height - Game.world.player.MAX_ACC);
            player.jumps = 2;
        }
    }
}
