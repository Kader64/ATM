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
            Width = 3;
            Height = 3;
            Color = EscapeColor.Color("Yellow");
        }

        public override void Render(ASCIICanvas canvas)
        {
            canvas.Brush = '░';
            base.Render(canvas);
            canvas.ResetBrush();
        }

        public override void OnCollision(Player player)
        {
            if (player.CableHeld == null) return;
            player.CableHeld.Target = this;
            player.CableHeld = null;
            Game.Stopwatch.Stop();
            SoundManager.SFX.Play(Sound.SFX_WIN);
            Thread.Sleep(2000);

            Menu.showNextLevelMenu();
        }
    }
}
