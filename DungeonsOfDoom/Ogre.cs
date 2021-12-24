using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class Ogre : Monster
    {
        public Ogre() : base("Ogre", RandomUtils.Percentage() < 50 ? 10 :20)
        {
        }
    }
}
