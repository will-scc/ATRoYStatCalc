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

        public static int GetLevelFromExp(long CurrentExp)
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
