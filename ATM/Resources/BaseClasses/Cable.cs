using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.BaseClasses
{
    public class Cable : GameObject
    {
        public Cable(int startX, int startY) : base(startX, startY)
        {
            PosX = startX;
            PosY = startY;
            Color = EscapeColor.Color("Blue");
        }

        public override void OnCollision(Player player)
        {
            base.OnCollision(player);
        }

        public override void Render(ASCIICanvas canvas)
        {
            canvas.strokeStyle = Color;
            canvas.StrokeLine(PosX, PosY, Game.world.player.PosX, Game.world.player.PosY);
        }
    }
}
