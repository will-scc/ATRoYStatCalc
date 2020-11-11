using System;
using System.Diagnostics;
using System.Linq;

namespace ATRoYStatCalc
{
    public static class HelperFuncs
    {
        public static bool In(this string source, params string[] list)
        {
            if (null == source) throw new ArgumentNullException("source");
            return list.Contains(source, StringComparer.OrdinalIgnoreCase);
        }

        //public static int MaxMagicalBonus(this int Base, int Bonus)
        //{
        //    if (Bonus > (Base / 2))
        //    {
        //        return Base + (Base / 2);
        //    }
        //    else
        //    {
        //        return Base + Bonus;
        //    }
        //}

        public static int GetCurrentLevel(long CurrentExp)
        {
            int level = 0;
            long usedExp = 0;

            do
            {
                level++;
                usedExp += (long)Math.Round(RequiredExp(level, level+1), MidpointRounding.ToZero);
            } while (CurrentExp >= usedExp);

            return level;
        }

        public static double RequiredExp(int CurrentLevel, int NextLevel)
        {
            return Math.Pow(NextLevel, 4) - Math.Pow(CurrentLevel, 4);
        }
    }
}
