using ConsoleGameEngine;
using System.Runtime.InteropServices;


class Program
{

    static void Main(string[] args)
    {

        Console.Title = "ATM";

        ConsoleManager.SetConsoleFont(3,3,0,0);
        ConsoleManager.blockWindowResize();
        Console.CursorVisible = false;
        Console.SetBufferSize(320, 180);
        Console.SetWindowSize(322, 182);

        Console.SetCursorPosition(0, 0);

        var canvas = new ASCIICanvas(Console.BufferWidth-1,Console.BufferHeight-1);

        int y = 90;

        int forceY = 10;

        int x = 40;

        int z = -2;
        int f = -2;

        while (true)
        {


            canvas.flushBuffer();

            canvas.fillStyle = EscapeColor.Color("Red");
            canvas.FillRect(x, y, 10, 10);

            x -= z;
            y -= f;

            if (x > 310 || x <= 0) z = -z;
            if (y > 170 || y <= 0) f = -f;

            canvas.renderBuffer();
            Thread.Sleep(10);
        }



    }
}


