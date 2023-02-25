using ATM.Resources.BaseClasses;
using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.GameClasses
{
    class Trapdoor : GameObject
    {
        public Trapdoor(int posX, int posY, int objW, int objH) : base(posX, posY)
        {
            this.Width = objW;
            this.Height = objH;
            this.PosX = posX;
            this.PosY = posY;
            this.Color = EscapeColor.Color("Yellow");
        }

        public override void Render(ASCIICanvas canvas)
        {
            canvas.Brush = '░';
            base.Render(canvas);
            canvas.ResetBrush();
        }

        public override void OnCollision(Player player)
        {

            if (player.PosX + player.Width <= PosX && player.PosY + player.Height > PosY && player.PosY <= PosY + Height - 1)
            {
                player.SetPos(PosX - player.Width - 1, player.PosY);
                return;
            }
            else if (player.PosX >= PosX + Width && player.PosY + player.Height > PosY && player.PosY <= PosY + Height - 1)
            {
                player.SetPos(PosX + Width + 1, player.PosY);
                return;
            }

            if (player.PosY + player.Height >= PosY && player.PosY + player.Height <= PosY + Height)
            {
                return;
            }
            else
            {
                player.acc = 0;
                player.SetPos(player.PosX, PosY + Height + 1);
                return;
            }

        }
    }
}
