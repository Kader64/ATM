using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine
{
    public class Timer
    {

        private DateTime initTime;

        public Timer() 
        { 
            initTime = DateTime.Now;
        }

        public string GetHours() 
        {
            TimeSpan elapsed = DateTime.Now.Subtract(initTime);
            return elapsed.Hours<10?("0" + elapsed.Hours):elapsed.Hours.ToString();
        }

        public string GetMinutes()
        {
            TimeSpan elapsed = DateTime.Now.Subtract(initTime);
            return elapsed.Minutes < 10 ? ("0" + elapsed.Minutes) : elapsed.Minutes.ToString(); ;
        }

        public string GetSeconds()
        {
            TimeSpan elapsed = DateTime.Now.Subtract(initTime);
            return elapsed.Seconds < 10 ? ("0" + elapsed.Seconds) : elapsed.Seconds.ToString(); ;
        }

        public string GetElapsed()
        {
            TimeSpan elapsed = DateTime.Now.Subtract(initTime);
            return $"{GetHours()}:{GetMinutes()}:{GetSeconds()}";
        }
    }
}
