using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic.Devices;
using ATM.Resources.GameClasses;

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
            if (obj is Hook || obj is Atm || obj is Player || obj is Cable || obj is Ladder || obj is Trapdoor)
            {
                return false;
            }

            int x1 = Source.PosX + Source.Width / 2;
            int y1 = Source.PosY + Source.Height / 2;

            int x2 = Target.PosX + Target.Width / 2;
            int y2 = Target.PosY + Target.Height / 2;

            int w = x2 - x1;
            int h = y2 - y1;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                if (x1 >= obj.PosX && x1 <= obj.PosX + obj.Width && y1 >= obj.PosY && y1 <= obj.PosY + obj.Height) return true;
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x1 += dx1;
                    y1 += dy1;
                }
                else
                {
                    x1 += dx2;
                    y1 += dy2;
                }
            }

            return false;
        }


        

        public override void Render(ASCIICanvas canvas)
        {
            canvas.strokeStyle = Color;
            canvas.Brush = '■';
            canvas.StrokeLine(PosX, PosY, Target.PosX + Target.Width / 2, Target.PosY + Target.Height / 2);
            canvas.ResetBrush();
        }

    }
}
