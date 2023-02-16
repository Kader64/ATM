using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine
{
    public class CGE
    {

        public ASCIICanvas canvas;

        private Timer gameTimer;

        public Func<int> GameLogic;

        public int SleepTime = 20;

        private const int WINDOW_HEIGHT = 200;
        private const int WINDOW_WIDTH = 350;


        private int frames;

        private DateTime t1;

        public CGE() 
        { 
        
            canvas = new ASCIICanvas(WINDOW_WIDTH,WINDOW_HEIGHT);
            t1 = DateTime.Now;
        
        }

        public void run()
        {
            Console.Title = "FPS: " + frames;
            internalGameLoop();
        }
        private void internalGameLoop()
        {
            canvas.flushBuffer();
    
            GameLogic();


            frames++;
            if (t1.Second - DateTime.Now.Second < 0)
            {
                t1 = DateTime.Now;
                Console.Title = "FPS: " + frames;
                frames = 0;
            }


            canvas.renderBuffer();
            System.Threading.Thread.Sleep(SleepTime);
            internalGameLoop();
        }

       

        //ConsoleKey key = Console.ReadKey().Key;

                    

    }
}
