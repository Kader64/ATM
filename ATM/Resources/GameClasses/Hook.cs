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
            Width = 3;
            Height = 3;
            Color = EscapeColor.Color("Purple");
        }

        public override void Render(ASCIICanvas canvas)
        {
            canvas.Brush = '▒';
            base.Render(canvas);
            canvas.ResetBrush();
        }

        public override void OnCollision(Player player)
        {
            if (player.CableHeld == null) return;
            if (player.CableHeld.Source == this) return;

            player.CableHeld.Target = this;
            var cable = new Cable(this);
            player.CableHeld = cable;
            player.CableHeld.Target = player;
            Game.world.WorldObjects.Insert(0,cable);
        }
    }
}
