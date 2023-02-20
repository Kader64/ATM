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
        private int EndX, EndY;
        public Cable(int startX, int startY, int endX, int endY) : base(startX, startY)
        {
            PosX = startX;
            PosY = startY;
            EndX = endX;
            EndY = endY;
            Color = EscapeColor.Color("Blue");
        }

        public override void OnCollision(Player player)
        {
            base.OnCollision(player);
        }

        public override void Render(ASCIICanvas canvas)
        {
            canvas.strokeStyle = Color;
            canvas.StrokeLine(PosX, PosY, EndX, EndY);
        }
    }
}
