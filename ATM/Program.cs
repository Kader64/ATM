using ATM;
using ConsoleGameEngine;
using System.Runtime.InteropServices;
using ConsoleGameEngine;
using ATM.Resources.BaseClasses;





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
        music.PlayLoop();

        Menu.showMainMenu();

        music.Stop();

        const int GAME_GRAV = 1;

        int playerAcc = 1;

        var player = new Player(20,20);

        var floor = new Floor(0,90,100,5,EscapeColor.Color("White"));

        var gravTick = 0;

        int game(CGE ge)
        {

            player.renderPlayer(ge.canvas);
            floor.renderObject(ge.canvas);




            if (!floor.collides(player.getX(), player.getY(), player.getW(), player.getH()))
            {
                player.move(0, playerAcc);

                if (playerAcc < 3 && gravTick <= 0)
                {
                    playerAcc += GAME_GRAV;
                    gravTick = 3;
                }
            }
            else
            {
                player.setPos(player.getX(), floor.getY()-player.getH());
            }

            gravTick--;

            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if(key == ConsoleKey.D) player.move(1, 0);
                if (key == ConsoleKey.A) player.move(-1, 0);
                if (key == ConsoleKey.Spacebar)
                {
                    player.setPos(player.getX(), player.getY() - 1);
                    playerAcc = -5;
                }

            }

            return 0;
        }

        var GameEngine = new CGE();

        GameEngine.GameLogic = () => game(GameEngine);

        Console.Clear();

        GameEngine.run();



    }
}


