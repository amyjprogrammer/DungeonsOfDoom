using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    static class RandomUtils
    {
        static Random random = new Random();
        public static int Percentage()
        {
            return random.Next(1, 100 + 1);
        }

        public static int DiceRoll(int sides)
        {
            return random.Next(1, sides + 1);
        }
    }
}
