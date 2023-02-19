using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.BaseClasses
{
    class Floor : GameObject
    {
        public Floor(int posX, int posY, int objW, int objH, string objColor) : base(posX, posY)
        {
            this.Width = objW;
            this.Height = objH;
            this.PosX = posX;
            this.PosY = posY;
            this.Color = objColor;
        }
    }

}
