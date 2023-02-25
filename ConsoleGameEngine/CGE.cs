using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public int TimeStep = 20;

        private const int WINDOW_HEIGHT = 150;
        private const int WINDOW_WIDTH = 300;

        private bool isRunning = false;

        private int frames;

        private Stopwatch fpsTimer;
        private Stopwatch stopwatch;

        public CGE() 
        { 
            canvas = new ASCIICanvas(WINDOW_WIDTH,WINDOW_HEIGHT);
            stopwatch = new Stopwatch();
            runtime = new Timer();
            fpsTimer = new Stopwatch();
        }
        public void run()
        {
            fpsTimer.Start();
            Console.Title = "FPS: " + frames + " | " + runtime.GetElapsed();
            stopwatch.Start();
            isRunning = true;
            internalGameLoop();
        }

        public void stop()
        {
            isRunning = false;
            stopwatch.Stop();
            fpsTimer.Reset();
            fpsTimer.Stop();

            Console.Title = "";
        }
        private void internalGameLoop()
        {

            if (stopwatch.ElapsedMilliseconds > TimeStep)
            {
                canvas.FlushBuffer();
                GameLogic();
                stopwatch.Restart();
            }


            frames++;
            if (fpsTimer.ElapsedMilliseconds >= 1000)
            {
                fpsTimer.Restart();
                Console.Title = "FPS: " + frames + " | " + runtime.GetElapsed();
                frames = 0;
            }


            canvas.RenderBuffer();
            if(isRunning) internalGameLoop();
        }
    }
}
