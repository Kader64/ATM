using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine
{
    public class CGE
    {

        private ASCIICanvas canvas;
        private int TPS;

        private Timer gameTimer;

        public CGE() 
        { 
        
        
        }

        public void run()
        {
            internalGameLoop();
        }
        private void internalGameLoop()
        {
            var t1 = DateTime.Now;

            gameLogic(TPS);

            var t2 = DateTime.Now;

            TPS = Convert.ToInt32(t2.Subtract(t1).ToString());
        }

        public void gameLogic(int tps) { }

        //ConsoleKey key = Console.ReadKey().Key;

                    

    }
}
