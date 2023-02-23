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

            if (player.PosY + player.Height >= PosY && player.PosY + player.Height <= PosY + Height && player.vector.Y > 0)
            {
                var vec = player.vector.getOpositeY();
                vec.Y -= player.PosY + player.Height - PosY;
                player.Move(vec);
                player.Jumps = 1;
                return;
            }
            if (player.PosY >= PosY && player.PosY <= PosY + Height && player.vector.Y < 0)
            {
                var vec = player.vector.getOpositeY();
                vec.Y += player.PosY - PosY + Height;
                player.Move(vec);
                return;
            }
            player.Move(player.vector.getOpositeX());
        }
    }
}
