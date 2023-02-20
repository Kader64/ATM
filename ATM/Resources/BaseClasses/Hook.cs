using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.BaseClasses
{
    class Hook : GameObject
    {

        public Hook(int posX, int posY) : base(posX, posY)
        {
            PosX = posX;
            PosY = posY;
            Width = 5;
            Height = 5;
            Color = EscapeColor.Color("Purple");
        }
        public override void Render(ASCIICanvas canvas)
        {
            base.Render(canvas);
        }

        public override void OnCollision(Player player)
        {

        }
    }
}
