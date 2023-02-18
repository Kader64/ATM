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
            this.objW = objW;
            this.objH = objH;
            this.posX = posX;
            this.posY = posY;
            this.objColor = objColor;
        }
    }

}
