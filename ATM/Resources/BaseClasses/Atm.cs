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
            this.posX= posX;
            this.posY= posY;

        }

        public override void renderObject(ASCIICanvas canvas)
        {
            canvas.fillStyle = EscapeColor.Color("White");
            canvas.FillRect(posX, posY, 12, 20);

            canvas.fillStyle = EscapeColor.Color("Blue");
            canvas.FillRect(posX+3, posY+6, 6,5);

            canvas.strokeStyle = EscapeColor.Color("Yellow");
            canvas.StrokeRect(posX + 1, posY + 1, 10, 4);

            canvas.fillStyle = EscapeColor.Color("Black");
            canvas.FillRect(posX + 2, posY + 2, 2, 2);
            canvas.fillStyle = EscapeColor.Color("Black");
            canvas.FillRect(posX + 5, posY + 2, 2, 2);
            canvas.fillStyle = EscapeColor.Color("Black");
            canvas.FillRect(posX + 8, posY + 2, 2, 2);

            canvas.fillStyle = EscapeColor.Color("Black");
            canvas.FillRect(posX+2, posY + 12, 8, 4);

        }
    }
}
