using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class ConsoleGame
    {
        Player player;
        Room[,] world;
        Random random = new Random();

        public void Play()
        {
            CreatePlayer();
            CreateWorld();

            do
            {
                Console.Clear();
                DisplayWorld();
                DisplayStats();
                AskForMovement();
            } while (player.IsAlive);

            GameOver();
        }

        private void CreatePlayer()
        {
            player = new Player(30, 0, 0);
        }

        private void CreateWorld()
        {
            world = new Room[20, 5];
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = new Room();

                    int percentage = random.Next(0, 100);
                    if (percentage < 5)
                        world[x, y].Monster = new Ogre();
                    else if (percentage < 10)
                        world[x, y].Monster = new Skeleton();
                    else if (percentage < 15)
                        world[x, y].Item = new Potion();
                    else if (percentage < 20)
                        world[x, y].Item = new Sword();
                }
            }
        }

        private void DisplayWorld()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];
                    if (player.X == x && player.Y == y)
                        Console.Write("P");
                    else if (room.Monster != null)
                        Console.Write("M");
                    else if (room.Item != null)
                        Console.Write("I");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        private void DisplayStats()
        {
            Console.WriteLine($"Health: {player.Health}");
            foreach (var item in player.Backpack)
            {
                Console.WriteLine(item.Name);
            }
        }

        private void AskForMovement()
        {
            int newX = player.X;
            int newY = player.Y;
            bool isValidKey = true;

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                default: isValidKey = false; break;
            }

            if (isValidKey &&
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;

                EnterRoom();
            }
        }

        private void EnterRoom()
        {
            Room currentRoom = world[player.X, player.Y];
            var monster = currentRoom.Monster;

            if(monster != null)
            {
                AttackResult result = monster.Attack(player);
                Console.WriteLine($"Monster damaged player by {result.Damage}");
                Console.ReadKey(true);

                if (player.IsAlive)
                {
                    result = player.Attack(monster);
                    Console.WriteLine($"Player damaged monters by {result.Damage}");
                    Console.ReadKey(true);
                }

                if (!monster.IsAlive)
                {
                    player.Backpack.Add(currentRoom.Monster);
                    currentRoom.Monster = null;
                }
            }

            if (player.IsAlive && currentRoom.Item != null)
            {
                player.Backpack.Add(currentRoom.Item);
                currentRoom.Item.Use(player);
                currentRoom.Item = null;
            }
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.ReadKey();
            Play();
        }
    }
}
