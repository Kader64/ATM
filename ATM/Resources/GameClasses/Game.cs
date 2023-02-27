using ATM.Resources.BaseClasses;
using ConsoleGameEngine;
using System.Diagnostics;

namespace ATM.Resources
{
    public static class Game
    {
        public static World world;
        public static CGE GameEngine;
        public static int Level;
        public static int MaxLevel;
        public static Stopwatch Stopwatch;

        public static void Init()
        {
            world = new World();
            GameEngine = new CGE();
            Stopwatch = new Stopwatch();
            Level = 1;
            MaxLevel = 1;

            GameEngine.GameLogic = () => Loop(GameEngine);
            StartNextLevel();
        }

        public static void StartNextLevel()
        {
            Console.Clear();
            Stopwatch.Restart();
            GameEngine.canvas.SetupConsole();
            SoundManager.Music.PlayLoop(Sound.MUSIC_GAME, 0.3f);
            Console.ForegroundColor = ConsoleColor.White;
            world = new World();

            world.WorldObjects = FileManager.ReadGameObjectsData(Level).ToList();

            GameEngine.run();
        }

        private static void Loop(CGE ge)
        {
            for (int i = 0; i < world.WorldObjects.Count; i++)
            {
                world.WorldObjects[i].Render(ge.canvas);

                if(world.player.CableHeld != null)
                {
                    if (world.player.CableHeld.ChkIntersect(world.WorldObjects[i])) Menu.GameOver();
                }

                if (world.player.Collides(world.WorldObjects[i]))
                {
                    world.WorldObjects[i].OnCollision(world.player);
                }
                else
                {
                    world.player.affByGravity = true;
                    world.player.isColiding = false;
                }
            }

            world.GRAVITY_TICK++;

            if(world.GRAVITY_TICK == 4)
            {
                world.GRAVITY_TICK = 0;
            }

            world.player.Control();

            world.player.Render(ge.canvas);
        }
    }
}
