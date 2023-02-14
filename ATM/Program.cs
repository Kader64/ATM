using ConsoleGameEngine;
using System.Runtime.InteropServices;


class Program
{

    static void Main(string[] args)
    {

        ConsoleManager.SetConsoleFont(3,3,0,0);
        ConsoleManager.blockWindowResize();
        Console.CursorVisible = false;
        Console.SetWindowSize((int)Console.LargestWindowWidth / 2, (int)Console.LargestWindowHeight / 2);
        Console.SetBufferSize((int)Console.LargestWindowWidth / 2, (int)Console.LargestWindowHeight / 2);



        var canvas = new ASCIICanvas(100, 100);

        int y = 90;

        int forceY = 10;

        int x = 40;

        while (true)
        {


            canvas.flushBuffer();

            canvas.strokeStyle = EscapeColor.Color("Yellow");
            canvas.strokeLine(0, 0, x , y);
            canvas.strokeStyle = EscapeColor.Color("Blue");
            canvas.strokeLine(0, 100, x, y + 10);
            canvas.strokeStyle = EscapeColor.Color("Teal");
            canvas.strokeLine(100, 100, x + 10, y + 10);
            canvas.strokeStyle = EscapeColor.Color("Green");
            canvas.strokeLine(100, 0, x + 10, y);

            canvas.fillStyle = EscapeColor.Color("Red");
            canvas.FillRect(x,y,10,10);

            y -= forceY;

            forceY--;

            if (y + 10 >= 100) forceY = 10;

            canvas.renderBuffer();
            Thread.Sleep(10);
        }

        
        
    }
}


