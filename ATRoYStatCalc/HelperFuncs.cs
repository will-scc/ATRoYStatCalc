using System;
using System.Collections.Generic;
using System.Text;

namespace ATRoYStatCalc
{
    public static class HelperFuncs
    {
        public static int MaxBonus(this int Base, int Bonus)
        {
            return Bonus > Base / 2 ? Base + (Base / 2) : Base + Bonus;
        }
    }
}
