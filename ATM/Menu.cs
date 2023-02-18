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
        public static void showMainMenu()
        {
            string fgColor = EscapeColor.ColorRGB(0, 230, 230);

            MenuBuilder builder = new MenuBuilder();
            builder.Add(new Title("A.T.M."));
            builder.Add(new Option("Wpłać","center", fgColor, () =>
            {

                return 0;
            }));
            builder.Add(new Option("Wypłać", "center", fgColor, () =>
            {

                return 0;
            }));
            builder.Add(new Option("Użytkownicy", "center", fgColor, () =>
            {

                return 0;
            }));
            builder.Add(new Option("Wyjście", "center", fgColor, () =>
            {
                Exit();
                return 0;
            }));
            builder.pointerColor = EscapeColor.ColorRGB(0, 255, 0);
            builder.run();
        }
        public static void showUsers()
        {
            Console.Clear();
            FileManager file = new FileManager();

            UserData[] users = file.ReadData();
            users = users.OrderBy(x => x.score).ToArray();

            StringBuilder bob = new StringBuilder();
            int i = 0;

            foreach (var user in users)
            {
                bob.Append($"{i + 1}) {user.username}: {user.score}$\n");
                i++;
            }

            bob.Append($"Back {EscapeColor.ColorRGB(0, 255, 0)}◄");
            Console.WriteLine(bob.ToString());

            while (true)
            {
                if(Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    break;
                }
                Console.SetCursorPosition(0, i+5);
            }
            showMainMenu();

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
