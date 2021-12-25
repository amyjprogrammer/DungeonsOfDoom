using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace DungeonsOfDoom.Core.Characters
{
    public class Skeleton : Monster
    {
        public Skeleton() : base("Skeleton", RandomUtils.DiceRoll(6))
        {

        }

        public override AttackResult Attack(Character opponent)
        {
            int damage = 0;

            if (opponent.Health < 30)
            {
                damage = 5;
                opponent.Health -= damage;
            }

            return new AttackResult(this, opponent, damage);
        }
    }
}
