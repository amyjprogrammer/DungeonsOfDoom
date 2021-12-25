using DungeonsOfDoom.Core.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Items
{
    public abstract class Item : ILuggable
    {
        public Item(string name)
        {
            Name = name;
        }

        public abstract void Use(Player player);
        public string Name { get; set; }
    }
}
