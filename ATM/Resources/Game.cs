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
        private List<GameObject> objects;

        private int GRAVITY_POWER = 1;
        private int GRAVITY_TICK = 0;

        public Game()
        {
            this.player = new Player(20, 20);
            this.objects = new List<GameObject>();
        }

        public void Start()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            var GameEngine = new CGE();
            GameEngine.GameLogic = () => Loop(GameEngine);

            objects.Add(new Floor(3, 140, 300, 2, EscapeColor.Color("White")));
            objects.Add(new Floor(3, 70, 150, 2, EscapeColor.Color("White")));
            objects.Add(new Atm(200, 100));

            GameEngine.run();
        }
        private void Loop(CGE ge)
        {
            player.renderObject(ge.canvas);

            foreach (var ob in objects)
            {
                ob.renderObject(ge.canvas);

                if (!ob.collides(player))
                {
                    player.move(0, player.acc);
                    if (player.acc < 3 && GRAVITY_TICK <= 0)
                    {   
                        player.acc += GRAVITY_POWER;
                        GRAVITY_TICK = 3;
                    }
                }
                else
                {
                    player.setPos(player.PosX, ob.PosY - player.Height);
                    player.jumps = 2;
                }
            }


            GRAVITY_TICK--;
            player.control();
        }
    }
}
