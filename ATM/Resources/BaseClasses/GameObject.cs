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
        protected int posX, posY;
        protected int objW, objH;
        protected string objColor;

        public GameObject(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public int[] getSizes()
        {
            return new int[] { objW, objH };
        }

        public virtual void renderObject(ASCIICanvas canvas)
        {
            canvas.fillStyle = this.objColor;
            canvas.FillRect(posX, posY, objW, objH);
        }

        public int getX()
        {
            return posX;
        }
        public int getY()
        {
            return posY;
        }

        public void setPos(int x, int y)
        {
            posY = y;
            posX = x;
        }

        public bool collides(int chkX, int chkY, int chkW, int chkH)
        {
            //if (chkX > posX && chkX + chkW < posX && chkY + chkH >= posY)
            //{
            //    return true;
            //}
            if (chkY + chkH >= posY && chkX >= posX && chkX + chkW <= posX+objW)
            {
                return true;
            }
            return false;
        }
    }
}
