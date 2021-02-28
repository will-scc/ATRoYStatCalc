using ATRoYStatCalc.Model;
using ATRoYStatCalc.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        public static Tuple<int, int> GetAccuracyAndEffectiveArmour(int Difference)
        {
            int Accuracy;
            int EnemyEffectiveArmour;

            if      (Difference < -146) { Accuracy = 10; EnemyEffectiveArmour = 90; }
            else if (Difference < -128) { Accuracy = 11; EnemyEffectiveArmour = 90; }
            else if (Difference < -112) { Accuracy = 12; EnemyEffectiveArmour = 90; }
            else if (Difference < -96)  { Accuracy = 13; EnemyEffectiveArmour = 90; }
            else if (Difference < -80)  { Accuracy = 14; EnemyEffectiveArmour = 90; }
            else if (Difference < -72)  { Accuracy = 15; EnemyEffectiveArmour = 90; }
            else if (Difference < -64)  { Accuracy = 16; EnemyEffectiveArmour = 90; }
            else if (Difference < -56)  { Accuracy = 17; EnemyEffectiveArmour = 90; }
            else if (Difference < -48)  { Accuracy = 18; EnemyEffectiveArmour = 90; }
            else if (Difference < -40)  { Accuracy = 19; EnemyEffectiveArmour = 90; }
            else if (Difference < -36)  { Accuracy = 20; EnemyEffectiveArmour = 90; }
            else if (Difference < -32)  { Accuracy = 22; EnemyEffectiveArmour = 90; }
            else if (Difference < -28)  { Accuracy = 24; EnemyEffectiveArmour = 90; }
            else if (Difference < -24)  { Accuracy = 26; EnemyEffectiveArmour = 90; }
            else if (Difference < -20)  { Accuracy = 28; EnemyEffectiveArmour = 90; }
            else if (Difference < -18)  { Accuracy = 30; EnemyEffectiveArmour = 90; }
            else if (Difference < -16)  { Accuracy = 32; EnemyEffectiveArmour = 90; }
            else if (Difference < -14)  { Accuracy = 34; EnemyEffectiveArmour = 90; }
            else if (Difference < -12)  { Accuracy = 36; EnemyEffectiveArmour = 90; }
            else if (Difference < -10)  { Accuracy = 38; EnemyEffectiveArmour = 90; }
            else if (Difference < -8)   { Accuracy = 40; EnemyEffectiveArmour = 90; }
            else if (Difference < -6)   { Accuracy = 42; EnemyEffectiveArmour = 90; }
            else if (Difference < -4)   { Accuracy = 44; EnemyEffectiveArmour = 90; }
            else if (Difference < -2)   { Accuracy = 46; EnemyEffectiveArmour = 90; }
            else if (Difference < 0)    { Accuracy = 48; EnemyEffectiveArmour = 90; }
            else if (Difference == 0)   { Accuracy = 50; EnemyEffectiveArmour = 90; }
            else if (Difference < 2)    { Accuracy = 52; EnemyEffectiveArmour = 90; }
            else if (Difference < 4)    { Accuracy = 54; EnemyEffectiveArmour = 90; }
            else if (Difference < 6)    { Accuracy = 56; EnemyEffectiveArmour = 90; }
            else if (Difference < 8)    { Accuracy = 58; EnemyEffectiveArmour = 90; }
            else if (Difference < 10)   { Accuracy = 60; EnemyEffectiveArmour = 90; }
            else if (Difference < 12)   { Accuracy = 62; EnemyEffectiveArmour = 90; }
            else if (Difference < 14)   { Accuracy = 64; EnemyEffectiveArmour = 90; }
            else if (Difference < 16)   { Accuracy = 66; EnemyEffectiveArmour = 85; }
            else if (Difference < 18)   { Accuracy = 68; EnemyEffectiveArmour = 80; }
            else if (Difference < 20)   { Accuracy = 70; EnemyEffectiveArmour = 75; }
            else if (Difference < 24)   { Accuracy = 72; EnemyEffectiveArmour = 70; }
            else if (Difference < 28)   { Accuracy = 74; EnemyEffectiveArmour = 65; }
            else if (Difference < 32)   { Accuracy = 76; EnemyEffectiveArmour = 60; }
            else if (Difference < 36)   { Accuracy = 78; EnemyEffectiveArmour = 55; }
            else if (Difference < 40)   { Accuracy = 80; EnemyEffectiveArmour = 50; }
            else if (Difference < 44)   { Accuracy = 81; EnemyEffectiveArmour = 45; }
            else if (Difference < 48)   { Accuracy = 82; EnemyEffectiveArmour = 40; }
            else if (Difference < 52)   { Accuracy = 83; EnemyEffectiveArmour = 35; }
            else if (Difference < 56)   { Accuracy = 84; EnemyEffectiveArmour = 30; }
            else if (Difference < 60)   { Accuracy = 85; EnemyEffectiveArmour = 25; }
            else if (Difference < 64)   { Accuracy = 86; EnemyEffectiveArmour = 20; }
            else if (Difference < 68)   { Accuracy = 87; EnemyEffectiveArmour = 15; }
            else if (Difference < 72)   { Accuracy = 89; EnemyEffectiveArmour = 10; }
            else                        { Accuracy = 90; EnemyEffectiveArmour = 5; }

            return new Tuple<int, int>(Accuracy, EnemyEffectiveArmour);
        }
    }
}
