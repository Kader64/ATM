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

            world.WorldObjects.Add(new Floor(10, 100, 70, 2, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Floor(185, 60, 5, 43, EscapeColor.Color("White")));

            //world.WorldObjects.Add(new Floor(225, 100, 70, 4, EscapeColor.Color("White")));
            world.WorldObjects.Add(new Floor(100, 100, 70, 2, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Floor(0, 148, 300, 2, EscapeColor.Color("White")));

            world.WorldObjects.Add(new Floor(200, 100, 70, 2, EscapeColor.Color("White")));
            //world.WorldObjects.Add(new Floor(3, 140, 300, 4, EscapeColor.Color("White")));
            world.WorldObjects.Add(new Plug(255, 130));

            world.WorldObjects.Add(new Hook(90, 60));
            world.WorldObjects.Add(new Hook(181, 50));

            world.WorldObjects.Add(new Hook(90, 130));

            world.WorldObjects.Add(new Atm(255, 80));

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

            world.player.Render(ge.canvas);
        }
    }
}
