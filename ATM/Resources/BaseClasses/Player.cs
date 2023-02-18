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

        int posX,posY;

        private int playerW = 5, playerH = 10;

        private string playerColor = EscapeColor.Color("Red");

        public Player(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
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
