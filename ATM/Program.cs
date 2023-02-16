using ATM;
using ConsoleGameEngine;
using System.Runtime.InteropServices;


class Program
{

    

    static void Main(string[] args)
    {

        Console.Title = "ATM";
        ConsoleManager.blockWindowResize();
        Console.SetWindowSize(40, 20);
        Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        ConsoleManager.SetConsoleFont(20, 40, 0, 0);
        Console.CursorVisible = false;
        Menu.showMainMenu();


        int y = 90;

        int forceY = 10;

        int x = 40;

        int z = -5;
        int f = -4;

        int game(CGE ge)
        {
            ge.canvas.fillStyle = EscapeColor.Color("Red");
            ge.canvas.FillRect(x, y, 10, 10);

            x -= z;
            y -= f;

            if (x > 340 || x <= 0) z = -z;
            if (y > 190 || y <= 0) f = -f;

            return 0;
        }

        var GameEngine = new CGE();

        GameEngine.GameLogic = () => game(GameEngine);

        Console.Clear();

        GameEngine.run();



    }
}


