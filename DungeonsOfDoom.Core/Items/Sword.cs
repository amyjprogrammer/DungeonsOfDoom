using DungeonsOfDoom.Core.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.Core.Items
{
    public class Sword : Item
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
