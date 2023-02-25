using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATM.Resources.BaseClasses
{
    public class GameObject
    {
        public string Type { get; }
        public int PosX { get; set; }
        public int PosY { get; set;}
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }

        [JsonConstructor]
        public GameObject(string type, int posX, int posY, int width, int height, string color)
        {
            Type = type;
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
            var a = this.GetType().ToString().Split(".");
            Type = a[a.Length - 1];
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
