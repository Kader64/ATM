using ATM.Resources.GameClasses;
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
        public Vector vector { get; set; }

        public int Jumps = 1;


        private int MaxJumpSpeed = 5;

        public Player(int posX, int posY) : base(posX, posY, 5, 10, EscapeColor.Color("Red"))
        {
            PosX = posX;
            PosY = posY;
            vector = new Vector(0, 0);
        }

        public void Move(Vector vector)
        {
            PosX += vector.X;
            PosY += vector.Y;
        }

        public override void Render(ASCIICanvas canvas)
        {
            canvas.fillStyle = Color;
            canvas.FillRect(PosX, PosY, 5, 10);

            canvas.fillStyle = EscapeColor.Color("Black");
            canvas.FillRect(PosX+1, PosY+2, 1, 1);

            canvas.fillStyle = EscapeColor.Color("Black");
            canvas.FillRect(PosX+3, PosY+2, 1, 1);
        }

        public void Control()
        {
            if (KeyboardManager.IsKeyPressed(Keys.D) || KeyboardManager.IsKeyPressed(Keys.A))
            {
                if (KeyboardManager.IsKeyPressed(Keys.A))
                {
                    vector.X = -1;
                }
                else
                {
                    vector.X = 1;
                }
            }
            else
            {
                vector.X = 0;
            }

            if (KeyboardManager.IsKeyPressed(Keys.Space) && Jumps > 0)
            {
                vector.Y = -MaxJumpSpeed;
                Jumps--;
            }

            if(Game.world.GRAVITY_TICK == 0 && vector.Y < MaxJumpSpeed)
            {
                vector.Y += 1;
            }


            Move(vector);
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
