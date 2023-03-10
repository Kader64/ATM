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
        public readonly int MAX_ACC = 3;

        public Cable CableHeld { get; set; }

        public int Jumps = 1;


        private int MaxJumpSpeed = 7;

        public int acc = 0;

        public bool isColiding = false;
        public bool affByGravity = true;
        public Player(int posX, int posY) : base(posX, posY)
        {
            PosX = posX;
            PosY = posY;
            Width = 5;
            Height = 10;
            Color = EscapeColor.Color("Red");
        }

        public void Move(int x, int y)
        {
            PosX += x;
            PosY += y;
        }

        public void SetPos(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        public override void Render(ASCIICanvas canvas)
        {
            canvas.fillStyle = Color;
            canvas.FillRect(PosX, PosY, 5, Height);

            canvas.fillStyle = EscapeColor.Color("Black");
            canvas.FillRect(PosX+1, PosY+2, 1, 1);

            canvas.fillStyle = EscapeColor.Color("Black");
            canvas.FillRect(PosX+3, PosY+2, 1, 1);
        }

        public void Control()
        {

            if(!affByGravity && (KeyboardManager.IsKeyPressed(Keys.W) || KeyboardManager.IsKeyPressed(Keys.S)))
            {
                if (KeyboardManager.IsKeyPressed(Keys.W)) PosY -= 1;
                else PosY += 1;
            }

            if ((KeyboardManager.IsKeyPressed(Keys.D) || KeyboardManager.IsKeyPressed(Keys.A)))
            {
                if (KeyboardManager.IsKeyPressed(Keys.A))
                {
                    PosX += -1;
                }
                else
                {
                    PosX += 1;
                }
            }

            if (KeyboardManager.IsKeyPressed(Keys.Space) && Jumps >= 0 && acc >= 0)
            {
                isColiding = false;
                acc = -MaxJumpSpeed;
                Jumps--;
            }

            if (acc < 3 && !isColiding) acc++;

            if(affByGravity) PosY += acc;
        }

        public bool Collides(GameObject obj)
        {
            if (this.PosY + this.Height >= obj.PosY && this.PosY <= obj.PosY + obj.Height && this.PosX <= obj.PosX + obj.Width && this.PosX + this.Width >= obj.PosX)
            {
                return true;
            }
 
            return false;
        }

    }
}
