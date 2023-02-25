using ATM.Resources;
using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xMenu;

namespace ATM
{
    public static class Menu
    {
        private static string FG_COLOR = EscapeColor.ColorRGB(0, 230, 230);
        private static string POINTER_COLOR = EscapeColor.ColorRGB(0, 255, 0);
        private static string TITLE_COLOR = EscapeColor.ColorRGB(0, 255, 0);
        public static void showMainMenu()
        {
            MenuBuilder builder = new MenuBuilder();

            builder.Add(new Title("A.T.M.", TITLE_COLOR));
            builder.Add(new Option("Wpłać","center", FG_COLOR, () =>
            {
                LoadingPage.RunIntro();
                Game.Init();
                return 0;
            }));
            builder.Add(new Option("Wypłać", "center", FG_COLOR, () =>
            {
                Game.Init();
                return 0;
            }));
            builder.Add(new Option("Użytkownicy", "center", FG_COLOR, () =>
            {
                showUsers();
                return 0;
            }));
            builder.Add(new Option("Wyjście", "center", FG_COLOR, () =>
            {
                Exit();
                return 0;
            }));

            builder.pointerColor = POINTER_COLOR;
            builder.run();
        }
        public static void showUsers()
        {
            MenuBuilder builder = new MenuBuilder();
            builder.Add(new Title("Użytkownicy", TITLE_COLOR));

            var users = FileManager.ReadUsersData();
            users = users.OrderByDescending(x => x.score).ToArray();
            int i = 0;
            while(i<10 && i<users.Length)
            {
                builder.Add(new TextLine($"  {users[i].username}: {EscapeColor.ColorRGB(255, 204, 0)}{users[i].score}$"));
                i++;
            }

            builder.Add(new Option("Wyjście", "center", FG_COLOR, () =>
            {
                showMainMenu();
                return 0;
            }));

            builder.pointerColor = POINTER_COLOR;
            builder.run();
        }

        public static void showNextLevelMenu(int lvl, string time,int points)
        {
            Console.Clear();
            Game.GameEngine.stop();

            SoundManager.Music.Stop();
            Console.SetWindowSize(40, 20);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            ConsoleManager.SetConsoleFont(20, 40, 0, 0);

            LoadingPage.showLoadingScreen();

            MenuBuilder builder = new MenuBuilder();

            builder.Add(new TextLine($"\n   Ukończono z czasem: {EscapeColor.Color("Yellow")}{time}"));

            builder.Add(new TextLine($"   Ilość zdobytych punktów: {EscapeColor.Color("Yellow")}{points}"));

            builder.Add(new TextLine("\n\n\n"));

            builder.Add(new Title("POZIOM "+lvl+" ZAKOŃCZONY!", TITLE_COLOR));

            builder.Add(new Option("Następny", "center", FG_COLOR, () =>
            {
                LoadingPage.showLoadingScreen();
                Game.StartNextLevel();
                return 0;
            }));

            builder.Add(new Option("Wyjście", "center", FG_COLOR, () =>
            {
                Exit();
                return 0;
            }));

            builder.pointerColor = POINTER_COLOR;
            builder.run();
        }
        private static void Exit()
        {
            Console.Clear();
            string msg = "<Naciśnij dowolny przycisk>";
            Console.Write("\n\n");
            Console.Write($"{new string(' ', (Console.BufferWidth - msg.Length) / 2)}{EscapeColor.ColorRGB(255, 255, 255)}{msg}");
            Console.ForegroundColor = ConsoleColor.Black;
            Environment.Exit(0);
        }
    }
}
