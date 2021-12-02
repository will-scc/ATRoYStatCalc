using ATRoYStatCalc.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATRoYStatCalc
{
    public static class HelperFuncs
    {
        public static readonly string[] ValidBuildFileExtensions = new string[]
        {
            ".bmag",
            ".bwar",
            ".bsey",
            ".brog"
        };

        public static bool In(this string source, params string[] list)
        {
            if (null == source) throw new ArgumentNullException("source");
            return list.Contains(source, StringComparer.OrdinalIgnoreCase);
        }

        public static void AddDistinctAttribute(this List<Model.Attribute> list, Model.Attribute attribute)
        {
            if (!list.Any(p => p.Type == attribute.Type))
            {
                list.Add(attribute);
            }
        }

        public static void AddDistinctSkill(this List<Skill> list, Skill skill)
        {
            if (!list.Any(p => p.Type == skill.Type))
            {
                list.Add(skill);
            }
        }

        public static double GetLevelFromExp(long CurrentExp)
        {
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

        /// <summary>
        /// Difference is PlayerOff-EnemyDef
        /// </summary>
        /// <param name="Difference"></param>
        /// <returns></returns>
        public static Tuple<int, int> GetAccuracyAndEffectiveArmor(int Difference)
        {
            int Accuracy;
            int EnemyEffectiveArmor;

            if      (Difference < -146) { Accuracy = 10; EnemyEffectiveArmor = 90; }
            else if (Difference < -128) { Accuracy = 11; EnemyEffectiveArmor = 90; }
            else if (Difference < -112) { Accuracy = 12; EnemyEffectiveArmor = 90; }
            else if (Difference < -96)  { Accuracy = 13; EnemyEffectiveArmor = 90; }
            else if (Difference < -80)  { Accuracy = 14; EnemyEffectiveArmor = 90; }
            else if (Difference < -72)  { Accuracy = 15; EnemyEffectiveArmor = 90; }
            else if (Difference < -64)  { Accuracy = 16; EnemyEffectiveArmor = 90; }
            else if (Difference < -56)  { Accuracy = 17; EnemyEffectiveArmor = 90; }
            else if (Difference < -48)  { Accuracy = 18; EnemyEffectiveArmor = 90; }
            else if (Difference < -40)  { Accuracy = 19; EnemyEffectiveArmor = 90; }
            else if (Difference < -36)  { Accuracy = 20; EnemyEffectiveArmor = 90; }
            else if (Difference < -32)  { Accuracy = 22; EnemyEffectiveArmor = 90; }
            else if (Difference < -28)  { Accuracy = 24; EnemyEffectiveArmor = 90; }
            else if (Difference < -24)  { Accuracy = 26; EnemyEffectiveArmor = 90; }
            else if (Difference < -20)  { Accuracy = 28; EnemyEffectiveArmor = 90; }
            else if (Difference < -18)  { Accuracy = 30; EnemyEffectiveArmor = 90; }
            else if (Difference < -16)  { Accuracy = 32; EnemyEffectiveArmor = 90; }
            else if (Difference < -14)  { Accuracy = 34; EnemyEffectiveArmor = 90; }
            else if (Difference < -12)  { Accuracy = 36; EnemyEffectiveArmor = 90; }
            else if (Difference < -10)  { Accuracy = 38; EnemyEffectiveArmor = 90; }
            else if (Difference < -8)   { Accuracy = 40; EnemyEffectiveArmor = 90; }
            else if (Difference < -6)   { Accuracy = 42; EnemyEffectiveArmor = 90; }
            else if (Difference < -4)   { Accuracy = 44; EnemyEffectiveArmor = 90; }
            else if (Difference < -2)   { Accuracy = 46; EnemyEffectiveArmor = 90; }
            else if (Difference < 0)    { Accuracy = 48; EnemyEffectiveArmor = 90; }
            else if (Difference == 0)   { Accuracy = 50; EnemyEffectiveArmor = 90; }
            else if (Difference < 2)    { Accuracy = 52; EnemyEffectiveArmor = 90; }
            else if (Difference < 4)    { Accuracy = 54; EnemyEffectiveArmor = 90; }
            else if (Difference < 6)    { Accuracy = 56; EnemyEffectiveArmor = 90; }
            else if (Difference < 8)    { Accuracy = 58; EnemyEffectiveArmor = 90; }
            else if (Difference < 10)   { Accuracy = 60; EnemyEffectiveArmor = 90; }
            else if (Difference < 12)   { Accuracy = 62; EnemyEffectiveArmor = 90; }
            else if (Difference < 14)   { Accuracy = 64; EnemyEffectiveArmor = 90; }
            else if (Difference < 16)   { Accuracy = 66; EnemyEffectiveArmor = 85; }
            else if (Difference < 18)   { Accuracy = 68; EnemyEffectiveArmor = 80; }
            else if (Difference < 20)   { Accuracy = 70; EnemyEffectiveArmor = 75; }
            else if (Difference < 24)   { Accuracy = 72; EnemyEffectiveArmor = 70; }
            else if (Difference < 28)   { Accuracy = 74; EnemyEffectiveArmor = 65; }
            else if (Difference < 32)   { Accuracy = 76; EnemyEffectiveArmor = 60; }
            else if (Difference < 36)   { Accuracy = 78; EnemyEffectiveArmor = 55; }
            else if (Difference < 40)   { Accuracy = 80; EnemyEffectiveArmor = 50; }
            else if (Difference < 44)   { Accuracy = 81; EnemyEffectiveArmor = 45; }
            else if (Difference < 48)   { Accuracy = 82; EnemyEffectiveArmor = 40; }
            else if (Difference < 52)   { Accuracy = 83; EnemyEffectiveArmor = 35; }
            else if (Difference < 56)   { Accuracy = 84; EnemyEffectiveArmor = 30; }
            else if (Difference < 60)   { Accuracy = 85; EnemyEffectiveArmor = 25; }
            else if (Difference < 64)   { Accuracy = 86; EnemyEffectiveArmor = 20; }
            else if (Difference < 68)   { Accuracy = 87; EnemyEffectiveArmor = 15; }
            else if (Difference < 72)   { Accuracy = 89; EnemyEffectiveArmor = 10; }
            else                        { Accuracy = 90; EnemyEffectiveArmor = 5; }

            return new Tuple<int, int>(Accuracy, EnemyEffectiveArmor);
        }
    }
}
