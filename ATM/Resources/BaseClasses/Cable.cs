using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;

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

        public bool ChkIntersect(GameObject obj)
        {

            if (obj is Hook || obj is Atm || obj is Player || obj is Cable) return false;

            var a = new Point();
            a.X = Target.PosX;
            a.Y = Target.PosY;

            var b = new Point();
            b.X = Source.PosX;
            b.Y = Source.PosY;

            var r = new Rectangle();
            r.X = obj.PosX;
            r.Y = obj.PosY;

            r.Height = obj.Height;
            r.Width = obj.Width-14;

            if (Math.Min(a.X, b.X) > r.Right) return false;  
            if (Math.Max(a.X, b.X) < r.Left) return false;  
            if (Math.Min(a.Y, b.Y) > r.Bottom) return false;   
            if (Math.Max(a.Y, b.Y) < r.Top) return false;  

            if (r.Contains(a)) return true; 
            if (r.Contains(b)) return true;  

            return true;
        }

        public override void Render(ASCIICanvas canvas)
        {
            canvas.strokeStyle = Color;
            canvas.StrokeLine(PosX, PosY, Target.PosX + Target.Width / 2, Target.PosY + Target.Height / 2);
        }

    }
}
