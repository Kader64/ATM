﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xMenu
{
    public class Title : TextLine
    {
        public string BorderColor { get; set; } = "\x1b[33m";

        public Title(string text) : base(text)
        {
            Text = text;
        }

        public Title(string text, string color, string aligment, string borderColor) : base(text, color, aligment)
        {
            Text = text;
            Color = color;
            Aligment = aligment;
            BorderColor = borderColor;
        }

        public string Build()
        {
            StringBuilder bob = new StringBuilder();            
            string span = new string(' ', (Console.BufferWidth - Text.Length-10) / 2);
            // POPRAWIĆ ALIGMENT
            bob.Append($"    {BorderColor}╔══════════════════════════════╗    \n");
            bob.Append($"    {BorderColor}║{span}{Color}{Text}{span}{BorderColor}║\n");
            bob.Append($"    {BorderColor}╚══════════════════════════════╝    ");
            return bob.ToString();
        }
    }
}
