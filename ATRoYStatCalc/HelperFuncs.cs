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

        public static int GetCurrentLevel(long CurrentExp)
        {
            return CurrentExp < 1 
                ? 1
                : Math.Max(1, (int)Math.Sqrt(Math.Sqrt(CurrentExp)));
        }

        public static double RequiredExp(int CurrentLevel, int NextLevel)
        {
            return Math.Pow(NextLevel, 4) - Math.Pow(CurrentLevel, 4);
        }
    }
}
