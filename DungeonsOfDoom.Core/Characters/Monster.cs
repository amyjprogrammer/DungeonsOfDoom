using DungeonsOfDoom.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Characters
{
    public abstract class Monster : Character, ILuggable
    {
        public Monster(string name, int health) : base(health)
        {
            Name = name;
            MonsterCount++;
        }

        public string Name { get; set; }

        public static int MonsterCount { get; set; }

        public override int Health
        {
            get => base.Health; 
            set
            {
                base.Health = value;

                if (base.Health <= 0)
                    MonsterCount--;
            }
        }
    }
}
