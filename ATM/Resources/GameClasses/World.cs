﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources.BaseClasses
{
    public class World
    {
        public int GRAVITY_POWER = 1;
        public int GRAVITY_TICK = 0;
        public Player player = new Player(10, 130);
        public List<GameObject> WorldObjects = new List<GameObject>();
    }
}
