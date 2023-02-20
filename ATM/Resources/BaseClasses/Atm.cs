using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.BaseClasses
{
    class Atm : GameObject
    {
        public Atm(int posX, int posY) : base(posX, posY)
        {
            PosX = posX;
            PosY = posY;
        }

        public override void Render(ASCIICanvas canvas)
        {
            canvas.fillStyle = EscapeColor.Color("White");
            canvas.FillRect(PosX, PosY, 12, 20);

            canvas.fillStyle = EscapeColor.Color("Blue");
            canvas.FillRect(PosX+3, PosY + 6, 6,5);

            canvas.strokeStyle = EscapeColor.Color("Yellow");
            canvas.StrokeRect(PosX + 1, PosY + 1, 10, 4);

            canvas.fillStyle = EscapeColor.Color("Black");
            canvas.FillRect(PosX + 2, PosY + 2, 2, 2);
            canvas.fillStyle = EscapeColor.Color("Black");
            canvas.FillRect(PosX + 5, PosY + 2, 2, 2);
            canvas.fillStyle = EscapeColor.Color("Black");
            canvas.FillRect(PosX + 8, PosY + 2, 2, 2);

            canvas.fillStyle = EscapeColor.Color("Black");
            canvas.FillRect(PosX+2, PosY + 12, 8, 4);

        }
        public override void OnCollision(Player player)
        {
            if (player.CableSource != this)
            {
                var cable = new Cable(PosX, PosY);

                player.CableSource = this;
                Game.world.WorldObjects.Add(cable);
            }
        }
    }
}
