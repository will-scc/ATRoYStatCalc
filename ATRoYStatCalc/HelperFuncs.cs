using ATRoYStatCalc.Model;
using System;
using System.Collections.Generic;
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

        public static void AddDistinctAttribute(this List<Model.Attribute> list, Model.Attribute attribute)
        {
            if (!list.Any(p => p.DisplayName == attribute.DisplayName))
            {
                list.Add(attribute);
            }
        }

        public static void AddDistinctSkill(this List<Skill> list, Skill skill)
        {
            if (!list.Any(p => p.DisplayName == skill.DisplayName))
            {
                list.Add(skill);
            }
        }

        public static double GetLevelFromExp(long CurrentExp)
        {
            //if (CurrentExp < 1)
            //{
            //    return 1;
            //}
            //else
            //{
            //    double CurrentLevel = Math.Max(1, Math.Sqrt(Math.Sqrt(CurrentExp)));
            //    int FlooredCurrentLevel = (int)Math.Floor(CurrentLevel);

            //    double netRequiredExp = RequiredExp(FlooredCurrentLevel, FlooredCurrentLevel + 1);
            //    double remainingExp = CurrentExp - TotalExperience(FlooredCurrentLevel - 1);

            //    int percentage = (int)Math.Truncate((netRequiredExp / remainingExp) * 100);

            //    if (double.TryParse($"{FlooredCurrentLevel}.{percentage}", out double result))
            //    {
            //        return result;
            //    }
            //    else
            //    {
            //        return FlooredCurrentLevel;
            //    }
            //}

            return CurrentExp < 1
                ? 1
                : Math.Max(1, Math.Sqrt(Math.Sqrt(CurrentExp)));
        }

        public static double RequiredExp(int CurrentLevel, int NextLevel)
        {
            return Math.Pow(NextLevel, 4) - Math.Pow(CurrentLevel, 4);
        }

        public static double TotalExperience(int Level)
        {
            //probably a more efficient way to do this
            double totalExperience = 0;
            for (int i = 1; i < Level; i++)
            {
                totalExperience += Math.Pow(i + 1, 4) - Math.Pow(i, 4);
            }

            return totalExperience;
        }
    }
}
