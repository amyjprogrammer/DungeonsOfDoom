using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class Sword : Item
    {
        public Sword() : base("Sword")
        {

        }

        public override void Use(Player player)
        {
            player.Health++;
        }
    }
}
