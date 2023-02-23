using ATM.Resources.BaseClasses;
using ATM.Resources.GameClasses;
using ConsoleGameEngine;

namespace ATM.Resources
{
    internal class Game
    {
        public static World world = new World();
        public static CGE GameEngine = new CGE();

        public Game()
        {
            world = new World();
        }

        public void Start()
        {
            SoundManager.Music.PlayLoop(Sound.MUSIC_GAME);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            GameEngine.GameLogic = () => Loop(GameEngine);

            world.WorldObjects.Add(new Surface(10, 100, 70, 2, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Surface(185, 60, 5, 43, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Surface(100, 100, 70, 2, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Surface(0, 148, 300, 2, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Surface(200, 100, 70, 2, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Plug(255, 130));

            world.WorldObjects.Add(new Hook(90, 60));

            world.WorldObjects.Add(new Hook(181, 50));

            world.WorldObjects.Add(new Hook(90, 130));

            world.WorldObjects.Add(new Atm(100, 80));

            GameEngine.run();
        }
        private void Loop(CGE ge)
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
