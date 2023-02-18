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
                // START GRY
                return 0;
            }));
            builder.Add(new Option("Wypłać", "center", FG_COLOR, () =>
            {
                // NWM
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

            FileManager fileManager = new FileManager();
            var users = fileManager.ReadData();
            users = users.OrderByDescending(x => x.score).ToArray();

            foreach (var user in users)
            {
                builder.Add(new TextLine($"  {user.username}: {EscapeColor.ColorRGB(255, 204, 0)}{user.score}$"));
            }

            builder.Add(new Option("Wyjście", "center", FG_COLOR, () =>
            {
                showMainMenu();
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
