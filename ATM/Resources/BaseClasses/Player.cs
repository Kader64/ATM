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
        public Cable CableHeld { get; set; }

        public Player(int posX, int posY) : base(posX, posY, 5, 10, EscapeColor.Color("Red"))
        {
            PosX = posX;
            PosY = posY;
        }

        public void SetPos(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        public void Move(int x, int y)
        {
            PosX += x;
            PosY += y;
        }

        public void Control()
        {
            if (KeyboardManager.IsKeyPressed(Keys.D)) Move(2, 0);
            if (KeyboardManager.IsKeyPressed(Keys.A)) Move(-2, 0);
            if (KeyboardManager.IsKeyPressed(Keys.Space) && jumps > 0 && acc >= 0)
            {
                SetPos(PosX, PosY - 1);
                acc = -5;
                jumps--;
            };
        }

        public bool Collides(GameObject obj)
        {
            if (this.PosY + this.Height >= obj.PosY && this.PosY <= obj.PosY && this.PosX <= obj.PosX + obj.Width && this.PosX+this.Width >= obj.PosX)
            {
                return true;
            }
 
            return false;
        }
    }
}
