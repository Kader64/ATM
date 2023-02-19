using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.BaseClasses
{
    public class Player : GameObject
    {

        public int jumps { get; set; }
        public int acc { get; set; }

        public Player(int posX, int posY) : base(posX, posY, 5, 10, EscapeColor.Color("Red"))
        {
            PosX = posX;
            PosY = posY;
        }

        public void control()
        {
            if (KeyboardManager.IsKeyPressed(Keys.D)) move(2, 0);
            if (KeyboardManager.IsKeyPressed(Keys.A)) move(-2, 0);
            if (KeyboardManager.IsKeyPressed(Keys.Space) && jumps > 0 && acc >= 0)
            {
                setPos(PosX, PosY - 5);
                acc = -4;
                jumps--;
            };
        }

        public void setPos(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        public void move(int x, int y)
        {
            PosX += x;
            PosY += y;
        }
    }
}
