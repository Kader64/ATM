﻿using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public static class Menu
    {
        public static void showMainMenu()
        {
            Console.Clear();
            Console.WriteLine(makeTitle());
            string[] options = { "Wpłać", "Wypłać", "Użytkownicy", "Wyjście" };
            switch (showOptions(options, "The Maze Runner"))
            {
                case 0:

                    return;
         
                case 1:
                    return;
                case 2:
                    showUsers();
                    Thread.Sleep(2000);
                    break;
                case 3:
                    Exit();
                    break;
            }
        }
        public static void showUsers()
        {
            Console.Clear();
            Console.WriteLine(makeTitle());
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
        private static int showOptions(string[] options, string title)
        {
            int chosenOption = 0;
            while (true)
            {
                StringBuilder bob = new StringBuilder();
                for (int i = 0; i < options.Length; i++)
                {
                    bob.Append(centerText(options[i])+ EscapeColor.ColorRGB(0, 230, 230) +""+ options[i]+"");
                    if (i == chosenOption)
                    {
                        bob.Append(EscapeColor.ColorRGB(0, 255, 0) + " ◄");
                    }
                    else
                    {
                        bob.Append("  ");
                    }
                    bob.Append("\n\n");
                }
                Console.Write(bob);
                Console.ForegroundColor = ConsoleColor.Black;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (chosenOption < options.Length - 1)
                        {
                            chosenOption++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (chosenOption > 0)
                        {
                            chosenOption--;
                        }
                        break;
                    case ConsoleKey.Enter: return chosenOption;
                }
                Console.SetCursorPosition(0, 4);
            }
        }
        private static string makeTitle()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{EscapeColor.ColorRGB(255, 204, 0)}    ╔══════════════════════════════╗\n");
            builder.Append("    ║            ");
            builder.Append($"{EscapeColor.ColorRGB(0, 255, 0)}A.T.M.");
            builder.Append($"            {EscapeColor.ColorRGB(255, 204, 0)}║\n");
            builder.Append("    ╚══════════════════════════════╝\n");
            return builder.ToString();
        }
        private static string centerText(String text)
        {
            return new string(' ', (Console.BufferWidth - text.Length) / 2);
        }
        private static void Exit()
        {
            Console.Clear();
            string msg = "<Naciśnij dowolny przycisk>";
            Console.Write("\n\n");
            Console.Write($"{centerText(msg)}{EscapeColor.ColorRGB(255, 255, 255)}{msg}");
            Console.ForegroundColor = ConsoleColor.Black;
            Environment.Exit(0);
        }
    }
}
