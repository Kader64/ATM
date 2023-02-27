using ConsoleGameEngine;

namespace ATM.Resources
{
    internal static class LoadingPage
    {
        public static void RunIntro()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            generateText($"   Nazwa Konta: ");
            Menu.Username = Console.ReadLine();

            generateText($"   Kwota: ");
            Console.ReadLine();

            SoundManager.Music.Stop();

            showLoadingScreen();
            Console.Clear();

            Console.WriteLine();
            generateText($"  {EscapeColor.ColorRGB(255, 215, 0)}Ty: {EscapeColor.Color("White")}Co się stało,\n  czemu bankomat nie działa?\n");
            generateText($"  {EscapeColor.ColorRGB(255, 215, 0)}Starsza Pani: {EscapeColor.Color("White")}Chłopcze pospiesz się,\n  muszę wypłacić pieniądze!\n");
            generateText($"  {EscapeColor.ColorRGB(255, 215, 0)}Nieznajomy: {EscapeColor.Color("White")}Wtyczka wypadła,\n  podnieś ją i podłącz do gniazdka...\n");
            generateText($"  {EscapeColor.ColorRGB(255, 215, 0)}Starsza Pani: {EscapeColor.Color("White")}Tylko szybko!\n  Bo będzie minus za tempo.\n");
            generateText($"  {EscapeColor.ColorRGB(255, 215, 0)}Ty: {EscapeColor.Color("White")}Dobrze dobrze, zajmę się tym!\n");

            showLoadingScreen();

        }
        public static void showLoadingScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Random rnd = new Random();
            int i = 7000;
            while(i>0)
            {
                Console.SetCursorPosition(rnd.Next(0, Console.BufferWidth), rnd.Next(0, Console.BufferHeight));
                Console.Write(getRandomChar());
                Console.SetCursorPosition(rnd.Next(0, Console.BufferWidth), rnd.Next(0, Console.BufferHeight));
                Console.Write(getRandomChar());
                i--;
            }

            i = 800;
            while (i > 0)
            {
                Console.SetCursorPosition(rnd.Next(0, Console.BufferWidth), rnd.Next(0, Console.BufferHeight));
                Console.Write(" ");
                Console.SetCursorPosition(rnd.Next(0, Console.BufferWidth), rnd.Next(0, Console.BufferHeight));
                Console.Write(" ");
                i--;
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
                Thread.Sleep(65);
            }
        }
    }
}
