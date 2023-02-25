using ATM.Resources.BaseClasses;
using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.GameClasses
{
    class Ladder : GameObject
    {
        public Ladder(int posX, int posY, int height) : base(posX, posY)
        {

            Width = 4;
            Height = height;
            Color = EscapeColor.Color("Green");
            PosX = posX;
            PosY= posY;

        }

        public override void Render(ASCIICanvas canvas)
        {

            canvas.Brush = '║';

            canvas.fillStyle = Color;
            canvas.FillRect(PosX, PosY, 1, Height);
            canvas.FillRect(PosX+Width, PosY, 1, Height);

            canvas.Brush = '═';
            for (int y = PosY + 2; y < PosY + Height; y+=5)
            {
                canvas.FillRect(PosX+1, y, 3, 1);
            }

            canvas.ResetBrush();
        }

        public override void OnCollision(Player player)
        {
            player.affByGravity = false;
            player.Jumps = 1;
        }
    }
}
