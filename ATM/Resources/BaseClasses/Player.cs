using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.BaseClasses
{
    public class Player
    {

        private int posX,posY;
        public int jumps { get; set; }
        public int acc { get; set; }
        private int playerW = 5, playerH = 10;
        private string playerColor = EscapeColor.Color("Red");

        public Player(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            this.jumps = 0;
        }
        public int getX() { return posX; }
        public int getY() { return posY;}
        public int getW() { return playerW;}
        public int getH() { return playerH;}

        public void renderPlayer(ASCIICanvas canvas)
        {
            canvas.fillStyle= playerColor;
            canvas.FillRect(posX, posY, playerW, playerH);
        }

        public void control()
        {
            if (KeyboardManager.IsKeyPressed(Keys.D)) move(2, 0);
            if (KeyboardManager.IsKeyPressed(Keys.A)) move(-2, 0);
            if (KeyboardManager.IsKeyPressed(Keys.Space) && jumps > 0 && acc >= 0)
            {
                setPos(posX, posY - 5);
                acc = -4;
                jumps--;
            };
        }

        public void setPos(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }

        public void move(int x, int y)
        {
            this.posX += x;
            this.posY += y;
        }
    }
}
