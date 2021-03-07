using GalaSoft.MvvmLight;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ATRoYStatCalc.Model
{
    public class Attribute : ObservableObject
    {
        public enum Types
        {
            [Display(Name = "Wisdom")]
            Wisdom,
            [Display(Name = "Intuition")]
            Intuition,
            [Display(Name = "Agility")]
            Agility,
            [Display(Name = "Strength")]
            Strength
        }

        public string Modifies => ModifyingSkills();
        private string ModifyingSkills()
        {
            var sm = Skill.SkillModifiers.Where(x => x.Value.Contains(Type));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Modifies:");
            foreach (var dict in sm)
            {
                string skill = dict.Key.GetDisplayName();
                int count = dict.Value.Where(x => x == Type).Count();
                sb.AppendLine($"{skill} ({count})");
            }
            string ret = sb.ToString();
            sb = null;
            
            return ret;
        }

        private readonly bool IsSeyan;
        public Attribute(Types Type, bool IsSeyan = false)
        {
            this.IsSeyan = IsSeyan;
            this.Type = Type;
        }
        public Types Type { get; set; }
        public string DisplayName => Type.GetDisplayName();
        public int Start { get; set; }
        public int Cost { get; set; }
        public int Base { get; set; }
        public int BlessBonus { get; set; }
        public int EquipmentBonus { get; set; }
        public int LevelBonus { get; set; }
        public int WarriorBonus { get; set; }
        public int Mod => CalculateMod();
        private int CalculateMod()
        {
            double newMod = 0;

            newMod += Base;

            if (IsSeyan)
            {
                //changed ptm scaling to balance classes
                if (Base > 107)
                {
                    //Seyans mods includes bless + eq
                    newMod += Math.Min(Math.Floor(107 * 0.725), EquipmentBonus + BlessBonus);
                    newMod += Math.Min(Math.Floor((Base - 107) * 0.29), EquipmentBonus + BlessBonus);
                }
                else
                {
                    newMod += Math.Min(EquipmentBonus + BlessBonus, MaxMod);
                }
            }
            else
            {
                //other class ptms scale differently
                if (Base > 122)
                {
                    newMod += Math.Min(Math.Floor(122 * 0.5), EquipmentBonus);
                    newMod += Math.Min(Math.Floor(122 * 0.5), BlessBonus);
                    newMod += Math.Min(Math.Floor((Base - 122) * 0.2), EquipmentBonus); 
                    newMod += Math.Min(Math.Floor((Base - 122) * 0.2), BlessBonus);
                }
                else
                {
                    newMod += Math.Min(EquipmentBonus, MaxMod);
                    newMod += Math.Min(BlessBonus, MaxMod);
                }
            }

            newMod += WarriorBonus;
            newMod += LevelBonus;

            return (int)newMod;
        }

        public int MaxMod => IsSeyan
                    ? (int)Math.Floor((double)(Base * 0.725))
                    : (int)Math.Floor((double)(Base * 0.5));
        public bool MaxEquipmentModExceeded => EquipmentBonus > MaxMod;
        public bool MaxBlessModExceeded => BlessBonus > MaxMod;
        public bool MaxModExceeded => MaxEquipmentModExceeded && MaxBlessModExceeded;
    }
}
