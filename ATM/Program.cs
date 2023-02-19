using ATM;
using ConsoleGameEngine;
using System.Runtime.InteropServices;
using ConsoleGameEngine;
using ATM.Resources.BaseClasses;
using System.Threading;




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

        MusicManager music = new MusicManager("../../../../Assets/menuBG.mp3");
        music.setVolume(0.1f);
        //music.PlayLoop();

        Menu.showMainMenu();
    }
}


