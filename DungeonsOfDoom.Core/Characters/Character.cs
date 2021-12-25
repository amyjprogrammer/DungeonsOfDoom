using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.Core.Characters
{
    public abstract class Character
    {
        public Character(int health)
        {
            Health = health;
        }

        public virtual AttackResult Attack(Character opponent) 
        {
            int damage = 10;
            opponent.Health -= damage;

            return new AttackResult(this, opponent, damage);
        }

        public virtual int Health { get; set; }

        public bool IsAlive { get { return Health > 0; } }
    }
}
