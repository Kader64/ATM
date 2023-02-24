using ConsoleGameEngine;

namespace ATM.Resources
{
    internal static class LoadingPage
    {

        public static void RunIntro()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            generateText("   Nazwa Konta: ");
            string name = Console.ReadLine();

            generateText("   Kwota: ");
            Console.ReadLine();

            showLoadingScreen();
            Console.Clear();

            Console.WriteLine();
            generateText($"  {EscapeColor.Color("Yellow")}Ty: {EscapeColor.Color("White")}Co się stało,\n  czemu bankomat nie działa?\n");
            generateText($"  {EscapeColor.Color("Yellow")}Starsza Pani: {EscapeColor.Color("White")}Chłopcze pospiesz się,\n  muszę wypłacić pieniądze!\n");
            generateText($"  {EscapeColor.Color("Yellow")}Nieznajomy: {EscapeColor.Color("White")}Wtyczka wypadła,\n  podnieś ją i podłącz do gniazdka...\n");
            generateText($"  {EscapeColor.Color("Yellow")}Starsza Pani: {EscapeColor.Color("White")}Tylko szybko!\n  Bo będzie minus za tempo.\n");
            generateText($"  {EscapeColor.Color("Yellow")}Ty: {EscapeColor.Color("White")}Dobrze dobrze, zajmę się tym!\n");

            showLoadingScreen();

        }
        public static void showLoadingScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Random rnd = new Random();
            for (int i = 0; i < 300; i++)
            {
                Console.SetCursorPosition(rnd.Next(0, Console.BufferWidth), rnd.Next(0, Console.BufferHeight));
                Console.Write(getRandomChar());
                Console.SetCursorPosition(rnd.Next(0, Console.BufferWidth), rnd.Next(0, Console.BufferHeight));
                Console.Write(getRandomChar());
                Thread.Sleep(1);
            }

            for (int i = 0; i < 300; i++)
            {
                Console.SetCursorPosition(rnd.Next(0, Console.BufferWidth), rnd.Next(0, Console.BufferHeight));
                Console.Write(" ");
                Console.SetCursorPosition(rnd.Next(0, Console.BufferWidth), rnd.Next(0, Console.BufferHeight));
                Console.Write(" ");
                Thread.Sleep(1);
            }
        }
        private static char getRandomChar()
        {
            Random rnd = new Random();

            int asciiValue = rnd.Next(32, 127);
            char randomChar = (char) asciiValue;
            return randomChar;
        }
        private static void generateText(string text)
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
