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

        private Timer runtime;

        public Action GameLogic;

        public int SleepTime = 10;

        private const int WINDOW_HEIGHT = 150;
        private const int WINDOW_WIDTH = 300;


        private int frames;

        private DateTime t1;

        public CGE() 
        { 
        
            canvas = new ASCIICanvas(WINDOW_WIDTH,WINDOW_HEIGHT);
            t1 = DateTime.Now;
        
        }

        public void run()
        {
            runtime = new Timer();
            Console.Title = "FPS: " + frames + " | " + runtime.GetElapsed();
            internalGameLoop();
        }
        private void internalGameLoop()
        {
            canvas.FlushBuffer();
    
            GameLogic();

            frames++;
            if (t1.Second - DateTime.Now.Second < 0)
            {
                t1 = DateTime.Now;
                Console.Title = "FPS: " + frames + " | " + runtime.GetElapsed();
                frames = 0;
            }


            canvas.RenderBuffer();
            //System.Threading.Thread.Sleep(SleepTime);
            internalGameLoop();
        }
    }
}
