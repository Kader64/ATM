using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources
{
    internal class LoadingPage
    {

        public void Run()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            FirstStage();
        }
        private void FirstStage()
        {
            generateText("   Nazwa Konta: ");
            string name = Console.ReadLine();

            generateText("   Kwota: ");
            Console.ReadLine();

            SecondStage();
        }
        private void SecondStage()
        {
            showLoadingScreen();
            Console.Clear();
            generateText($"  {EscapeColor.Color("Yellow")}Ty: {EscapeColor.Color("White")}Co się stało,\n  czemu bankomat nie działa?\n");
            generateText($"  {EscapeColor.Color("Yellow")}Starsza Pani: {EscapeColor.Color("White")}Chłopcze pospiesz się,\n  muszę wypłacić pieniądze!\n");
            generateText($"  {EscapeColor.Color("Yellow")}Nieznajomy: {EscapeColor.Color("White")}Wtyczka wypadła,\n  podnieś ją i podłącz do gniazdka...\n");
            generateText($"  {EscapeColor.Color("Yellow")}Starsza Pani: {EscapeColor.Color("White")}Tylko szybko!\n  Bo będzie minus za tempo.\n");
            generateText($"  {EscapeColor.Color("Yellow")}Ty: {EscapeColor.Color("White")}Dobrze dobrze, zajmę się tym!\n");

            showLoadingScreen();
        }
        private void showLoadingScreen()
        {
            Random rnd = new Random();
            for (int i = 0; i < 1500; i++)
            {
                Console.SetCursorPosition(rnd.Next(0, Console.BufferWidth), rnd.Next(0, Console.BufferHeight));

                Console.Write(getRandomChar());
                Thread.Sleep(1);
            }

            for (int i = 0; i < 1500; i++)
            {
                Console.SetCursorPosition(rnd.Next(0, Console.BufferWidth), rnd.Next(0, Console.BufferHeight));

                Console.Write(" ");
                Thread.Sleep(1);
            }
        }
        private char getRandomChar()
        {
            Random rnd = new Random();

            int asciiValue = rnd.Next(32, 127);
            char randomChar = (char) asciiValue;
            return randomChar;
        }
        private void generateText(string text)
        {
            Console.WriteLine();
            foreach (char a in text)
            {
                Console.Write(a);
                Thread.Sleep(70);
            }
        }
    }
}
