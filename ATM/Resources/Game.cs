using ATM.Resources.BaseClasses;
using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Resources
{
    internal class Game
    {
        public static World world = new World();

        public Game()
        {
            world = new World();
        }

        public void Start()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            var GameEngine = new CGE();
            GameEngine.GameLogic = () => Loop(GameEngine);

            world.WorldObjects.Add(new Floor(10, 100, 70, 1, EscapeColor.Color("White")));
            //world.WorldObjects.Add(new Floor(225, 100, 70, 4, EscapeColor.Color("White")));
            world.WorldObjects.Add(new Floor(100, 100, 70, 1, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Floor(200, 100, 70, 1, EscapeColor.Color("White")));
            //world.WorldObjects.Add(new Floor(3, 140, 300, 4, EscapeColor.Color("White")));
            //world.WorldObjects.Add(new Hook(50, 50));
            world.WorldObjects.Add(new Atm(255, 80));

            GameEngine.run();
        }
        private void Loop(CGE ge)
        {

            world.player.Render(ge.canvas);

            for (int i = 0; i < world.WorldObjects.Count; i++)
            {
                world.WorldObjects[i].Render(ge.canvas);

                if (!world.player.Collides(world.WorldObjects[i]))
                {
                    if (world.player.acc < world.player.MAX_ACC && world.GRAVITY_TICK <= 0)
                    {
                        world.player.acc += world.GRAVITY_POWER;
                        world.GRAVITY_TICK = 2;
                    }
                }
                else
                {
                    world.WorldObjects[i].OnCollision(world.player);
                }
            }

            world.player.Move(0, world.player.acc);

            world.GRAVITY_TICK--;

            world.player.Control();
        }
    }
}
