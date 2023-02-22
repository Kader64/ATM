using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.BaseClasses
{
    public class GameObject
    {
        public int PosX { get; set; }
        public int PosY { get; set;}
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }

        public GameObject(int posX, int posY, int width, int height, string color)
        {
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            Color = color;
        }

        public GameObject(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }

        public virtual void Render(ASCIICanvas canvas)
        {
            canvas.fillStyle = Color;
            canvas.FillRect(PosX, PosY, Width, Height);
        }

        public virtual void OnCollision(Player player)
        {

        }
    }
}
