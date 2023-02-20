using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.BaseClasses
{
    public class Cable : GameObject
    {
        public GameObject Target { get; set; }
        public GameObject Source { get; set; }
        public Cable(GameObject source) : base(source.PosX+source.Width/2, source.PosY+source.Height/2)
        {
            Source = source;
            Color = EscapeColor.Color("Teal");
        }

        public override void OnCollision(Player player)
        {
            base.OnCollision(player);
        }

        public override void Render(ASCIICanvas canvas)
        {
            canvas.strokeStyle = Color;
            canvas.StrokeLine(PosX, PosY, Target.PosX + Target.Width / 2, Target.PosY + Target.Height / 2);
        }
    }
}
