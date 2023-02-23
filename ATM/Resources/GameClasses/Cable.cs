﻿using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic.Devices;

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
            if (obj is Hook || obj is Atm || obj is Player || obj is Cable)
            {
                return false;
            }

            var a = new Point(Target.PosX, Target.PosY);
            var b = new Point(Source.PosX, Source.PosY);
            var r = new Rectangle(obj.PosX, obj.PosY, obj.Width, obj.Height - 14);

            if (a.Y < r.Y) return false;

            return r.IntersectsWith(new Rectangle(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y)));
        }



        public override void Render(ASCIICanvas canvas)
        {
            canvas.strokeStyle = Color;
            canvas.StrokeLine(PosX, PosY, Target.PosX + Target.Width / 2, Target.PosY + Target.Height / 2);
        }

    }
}