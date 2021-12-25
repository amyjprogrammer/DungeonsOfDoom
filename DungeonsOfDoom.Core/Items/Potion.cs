using DungeonsOfDoom.Core.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.Core.Items
{
    public class Potion : Item
    {
        public Potion() : base("Potion")
        {

        }

        public override void Use(Player player)
        {
            player.Health += 10;
            player.X = 0;
            player.Y = 0;
        }
    }
}
