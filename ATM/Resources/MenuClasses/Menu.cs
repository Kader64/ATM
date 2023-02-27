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
        private static string TITLE_COLOR = EscapeColor.ColorRGB(0, 255, 0);
        public static string Username;
        public static void showMainMenu()
        {
            if (SoundManager.Music.Path != Sound.MUSIC_MENU)
            {
                SoundManager.Music.PlayLoop(Sound.MUSIC_MENU);
            }

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

            builder.run();
        }
        public static void showUsers()
        {
            if (SoundManager.Music.Path != Sound.MUSIC_MENU)
            {
                SoundManager.Music.PlayLoop(Sound.MUSIC_MENU);
            }
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

            builder.run();
        }

        public static void showNextLevelMenu()
        {
            Game.GameEngine.stop();

            SoundManager.Music.PlayLoop(Sound.MUSIC_NEXTLEVEL, 0.7f);

            Console.SetWindowSize(40, 20);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            ConsoleManager.SetConsoleFont(20, 40, 0, 0);

            var time = Game.Stopwatch.ElapsedMilliseconds;
            int timeInt = Convert.ToInt32(time / 1000);
            int score = (int)(500 - (0.75 * timeInt));
            score = score >= 0 ? score : 0;

            updateLeaderboard(score);
            LoadingPage.showLoadingScreen();

            MenuBuilder builder = new MenuBuilder();
            builder.Add(new TextLine($"\n   Ukończono z czasem: {EscapeColor.Color("Yellow")}{timeInt} s"));
            builder.Add(new TextLine($"   Ilość zdobytych punktów: {EscapeColor.Color("Yellow")}{score}"));
            builder.Add(new TextLine("\n\n\n"));
            builder.Add(new Title("POZIOM "+Game.Level+" ZAKOŃCZONY!", TITLE_COLOR));
            builder.Add(new Option("Następny", "center", FG_COLOR, () =>
            {
                LoadingPage.showLoadingScreen();

                Game.Level++;
                if (Game.Level > Game.MaxLevel)
                {
                    GameWin();
                }
                else
                {
                    Game.StartNextLevel();
                }
                return 0;
            }));
            builder.Add(new Option("Wyjście", "center", FG_COLOR, () =>
            {
                Exit();
                return 0;
            }));

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
        public static void GameOver()
        {
            if (SoundManager.Music.Path != Sound.MUSIC_NEXTLEVEL)
            {
                SoundManager.Music.PlayLoop(Sound.MUSIC_NEXTLEVEL);
            }

            Console.SetWindowSize(40, 20);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            ConsoleManager.SetConsoleFont(20, 40, 0, 0);

            LoadingPage.showLoadingScreen();

            string[] deathPrompt =
            {
                "Cóż, przynajmniej próbowałeś.",
                "Nie jest łatwo zwyciężyć, /n ale nie poddawaj się.",
                "Może powinieneś zmienić swoją strategię?",
                "Nie bądź zbyt zawiedziony,/n poziom był dosyć trudny.",
                "Twoja gra zakończyła się porażką, /n ale przynajmniej zdobyłeś doświadczenie.",
                "Nie zawsze można wygrać /n ale liczą się chęci!",
                "Cóż, wydaje się, /n że musisz jeszcze nad czymś popracować.",
                "Nie martw się, /n każdy ma swoje złe dni.",
                "Jesteś diobeł, i tyle!"
            };

            Random prompt = new Random();

            MenuBuilder builder = new MenuBuilder();
            builder.Add(new Title("KONIEC GRY", EscapeColor.ColorRGB(255,0,0)));
            string chosenPrompt = deathPrompt[prompt.Next(deathPrompt.Length - 1)];
            if(chosenPrompt.Split("/n").Length > 0)
            {
                foreach(string promptSilce in chosenPrompt.Split("/n"))
                {
                    builder.Add(new TextLine(promptSilce, "center"));
                }
            }
            else
            {
                builder.Add(new TextLine(chosenPrompt, "center"));
            }
            builder.Add(new TextLine("\n\n\n"));
            builder.Add(new Option("Restart", "center", FG_COLOR, () =>
            {
                LoadingPage.showLoadingScreen();
                Game.Init();
                return 0;
            }));
            builder.Add(new Option("Wyjście", "center", FG_COLOR, () =>
            {
                Exit();
                return 0;
            }));
            builder.run();
        }
        public static void GameWin()
        {
            LoadingPage.showLoadingScreen();

            MenuBuilder builder = new MenuBuilder();
            builder.Add(new Title("GRA UKOŃCZONA", TITLE_COLOR));
            builder.Add(new TextLine("\n\n\n"));
            builder.Add(new Option("Sprawdź Wynik", "center", FG_COLOR, () =>
            {
                showUsers();
                return 0;
            }));
            builder.Add(new Option("Wyjście", "center", FG_COLOR, () =>
            {
                Exit();
                return 0;
            }));
            builder.run();
        }
        private static void updateLeaderboard(int score)
        {
            if (Username == null) return;

            var data = FileManager.ReadUsersData().ToList();

            bool found = false;
            for (int i=0; i<data.Count; i++)
            {
                if(data[i].username == Username)
                {
                    data[i].score += score;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                data.Add(new UserData(Username,score));
            }
            FileManager.WriteUsersData(data.ToArray());
        }
    }
}
