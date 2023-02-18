using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xMenu
{
    public class TextLine
    {
        public string Text { get; set; } = "";
        public string Aligment { get; set; } = "left";
        public string Color { get; set; } = "\x1b[37m";

        public TextLine(string text)
        {
            Text = text;
        }

        public TextLine(string text, string aligment, string color) : this(text)
        {
            Aligment = aligment;
            Color = color;
        }

        public string Build()
        {
            return $"{AlignText()}{Color}{Text}";
        }
        protected string AlignText()
        {
            switch (Aligment)
            {
                case "right": return new string(' ', (Console.BufferWidth - Text.Length));
                case "center": return new string(' ', (Console.BufferWidth - Text.Length) / 2);
                default: return "";
            }
        }
    }
}
