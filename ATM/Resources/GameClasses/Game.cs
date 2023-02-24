using ATM.Resources.BaseClasses;
using ConsoleGameEngine;

namespace ATM.Resources
{
    public static class Game
    {
        public static World world;
        public static CGE GameEngine;

        public static void Init()
        {
            world = new World();
            GameEngine = new CGE();

            GameEngine.GameLogic = () => Loop(GameEngine);
            StartNextLevel();
        }

        public static void StartNextLevel()
        {
            Console.Clear();
            GameEngine.canvas.SetupConsole();
            SoundManager.Music.PlayLoop(Sound.MUSIC_GAME);
            Console.ForegroundColor = ConsoleColor.White;
            world = new World();

            // READ FROM FILE
            // ADD To WORLD

            world.WorldObjects.Add(new Surface(10, 100, 70, 2, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Surface(185, 60, 5, 43, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Surface(100, 100, 70, 2, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Surface(0, 148, 300, 2, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Surface(200, 100, 70, 2, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Plug(255, 130));

            world.WorldObjects.Add(new Hook(90, 60));

            world.WorldObjects.Add(new Hook(181, 50));

            world.WorldObjects.Add(new Hook(90, 130));

            world.WorldObjects.Add(new Atm(255, 80));

            GameEngine.run();
        }

        private static void Loop(CGE ge)
        {
            for (int i = 0; i < world.WorldObjects.Count; i++)
            {
                world.WorldObjects[i].Render(ge.canvas);

                if(world.player.CableHeld != null)
                {
                    if (world.player.CableHeld.ChkIntersect(world.WorldObjects[i])) ge.stop();
                }

                if (world.player.Collides(world.WorldObjects[i]))
                {
                    world.WorldObjects[i].OnCollision(world.player);
                }
                else
                {
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
