using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Item : ILuggable
    {
        public Item(string name)
        {
            Name = name;
        }

        public abstract void Use(Player player);
        public string Name { get; set; }
    }
}
