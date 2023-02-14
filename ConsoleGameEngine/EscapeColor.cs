using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine
{
    public class EscapeColor
    {

        private static string White = "\x1b[37m";
        private static string Red = "\x1b[31m";
        private static string Green = "\x1b[32m";
        private static string Blue = "\x1b[34m";
        private static string Yellow = "\x1b[33m";
        private static string Purple = "\x1b[35m";
        private static string Teal = "\x1b[36m";

        private static string[] colors = { White, Red, Green, Blue, Yellow, Purple, Teal };

        public static string Color(string color)
        {
            switch (color)
            {

                case "White": return White;

                case "Red": return Red;

                case "Green": return Green;

                case "Blue": return Blue;

                case "Yellow": return Yellow;

                case "Purple": return Purple;

                case "Teal": return Teal;

                default: return White;

            }
        }
        public static string ColorRGB(int r, int g, int b)
        {
            return $"\x1b[38;2;{r};{g};{b}m";
        }

        public static string Random()
        {
            Random r = new Random();
            return colors[r.Next(colors.Length)];
        }

    }
}
