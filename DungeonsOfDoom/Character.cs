using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    abstract class Character
    {
        public Character(int health)
        {
            Health = health;
        }

        public int Health { get; set; }

        public bool IsAlive { get { return Health > 0; } }
    }
}
