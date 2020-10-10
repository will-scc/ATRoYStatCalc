using System;

namespace ATRoYStatCalc
{
    public static class HelperFuncs
    {
        public static int MaxMagicalBonus(this int Base, int Bonus)
        {
            return Bonus > Base / 2 ? Base + (Base / 2) : Base + Bonus;
        }

        public static int GetCurrentLevel(int CurrentExp)
        {
            int level = 0;
            int usedExp = 0;

            do
            {
                level++;
                usedExp += (int)Math.Round(RequiredExp(level, level+1), MidpointRounding.ToZero);
            } while (CurrentExp >= usedExp);

            return level;
        }

        public static double RequiredExp(int CurrentLevel, int NextLevel)
        {
            return Math.Pow(NextLevel, 4) - Math.Pow(CurrentLevel, 4);
        }
    }
}
