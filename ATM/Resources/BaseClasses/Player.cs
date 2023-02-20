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
        public GameObject CableSource { get; set; }

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
                SetPos(PosX, PosY - 5);
                acc = -3;
                jumps--;
            };
        }

        public bool Collides(GameObject obj)
        {
            if (PosX + Width >= obj.PosX && PosX <= obj.PosX + obj.Width &&
                PosY + Height >= obj.PosY && PosY <= obj.PosY + obj.Height)
            {
                return true;
            }
            return false;
        }
    }
}
