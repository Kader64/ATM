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

            world.WorldObjects = FileManager.ReadGameObjectsData(1).ToList();

            world.WorldObjects.Add(new Ladder(30, 20, 80));

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
