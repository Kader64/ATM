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
        private Player player;
        public static World world = new World();

        public Game()
        {
            player = new Player(20, 20);
            world = new World();
        }

        public void Start()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            var GameEngine = new CGE();
            GameEngine.GameLogic = () => Loop(GameEngine);

            world.WorldObjects.Add(new Floor(3, 140, 300, 2, EscapeColor.Color("White")));
            world.WorldObjects.Add(new Floor(3, 70, 150, 2, EscapeColor.Color("White")));
            world.WorldObjects.Add(new Hook(50, 50));
            world.WorldObjects.Add(new Atm(200, 100));

            GameEngine.run();
        }
        private void Loop(CGE ge)
        {
            for(int i = 0; i < world.WorldObjects.Count; i++)
            {
                world.WorldObjects[i].Render(ge.canvas);

                if (!player.Collides(world.WorldObjects[i]))
                {
                    player.Move(0, player.acc);
                    if (player.acc < 3 && world.GRAVITY_TICK <= 0)
                    {
                        player.acc += world.GRAVITY_POWER;
                        world.GRAVITY_TICK = 3;
                    }
                }
                else
                {
                    world.WorldObjects[i].OnCollision(player);
                }
            }
            world.GRAVITY_TICK--;

            player.Render(ge.canvas);
            player.Control();
        }
    }
}
