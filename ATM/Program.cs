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
        ConsoleManager.SetConsoleFont(20,40,0,0);
        Console.CursorVisible = false;
        Menu.showMainMenu();


      
    }
}


