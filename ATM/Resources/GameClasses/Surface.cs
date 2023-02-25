using ATM.Resources.GameClasses;
using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.BaseClasses
{
    class Surface : GameObject
    {
        public Surface(int posX, int posY, int objW, int objH, string objColor) : base(posX, posY)
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

            if (player.PosX + player.Width <= PosX && player.PosY + player.Height >= PosY && player.PosY < PosY + Height)
            {
                player.SetPos(PosX - player.Width - 1, player.PosY);
                return;
            }
            else if (player.PosX >= PosX + Width)
            {
                player.SetPos(PosX + Width + 1, player.PosY);
                return;
            }

            if (player.PosY + player.Height >= PosY && player.PosY + player.Height <= PosY + Height)
            {
                player.isColiding = true;
                player.Jumps = 1;
                player.acc = 0;
                player.SetPos(player.PosX, PosY - player.Height - 1);
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
