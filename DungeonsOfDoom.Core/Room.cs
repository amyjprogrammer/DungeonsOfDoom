using DungeonsOfDoom.Core.Characters;
using DungeonsOfDoom.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    public class Room
    {
        public Monster Monster { get; set; }
        public Item Item { get; set; }
    }
}
