using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.BaseClasses
{
    public class Plug : GameObject
    {
        public Plug(int posX, int posY) : base(posX, posY)
        {
            Width = 5;
            Height = 5;
            Color = EscapeColor.Color("Yellow");
        }

        public override void Render(ASCIICanvas canvas)
        {
            base.Render(canvas);
        }

        public override void OnCollision(Player player)
        {
            if (player.CableHeld == null) return;
            player.CableHeld.Target = this;
            player.CableHeld = null;

            Game.GameEngine.stop();
            Menu.showNextLevelMenu(1, "2:00", 100);
        }
    }
}
