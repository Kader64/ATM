using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.GameClasses
{
    public class Vector
    {
        public int X;
        public int Y;

        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Vector getOpositeX()
        {
            return new Vector(-X, Y);
        }
        public Vector getOpositeY()
        {
            return new Vector(X, -Y);
        }
    }
}
