using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ATRoYStatCalc.Model
{
    public class Skill : ObservableObject
    {
        public enum Types
        {
            [Display(Name = "Hitpoints")] 
            Hitpoints,
            [Display(Name = "Endurance")] 
            Endurance,
            [Display(Name = "Mana")]
            Mana,
            [Display(Name = "Profession")]
            Profession,
            [Display(Name = "Archery")]
            Archery,
            [Display(Name = "Armor Skill")]
            ArmorSkill,
            [Display(Name = "Attack")]
            Attack,
            [Display(Name = "Bartering")]
            Bartering,
            [Display(Name = "Bless")]
            Bless,
            [Display(Name = "Body Control")]
            BodyControl,
            [Display(Name = "Dagger")]
            Dagger,
            [Display(Name = "Duration")]
            Duration,
            [Display(Name = "Fire")]
            Fire,
            [Display(Name = "Freeze")]
            Freeze,
            [Display(Name = "Hand to Hand")]
            HandtoHand,
            [Display(Name = "Heal")]
            Heal,
            [Display(Name = "Immunity")]
            Immunity,
            [Display(Name = "Lightning")]
            Lightning,
            [Display(Name = "Magic Shield")]
            MagicShield,
            [Display(Name = "Meditate")]
            Meditate,
            [Display(Name = "Parry")]
            Parry,
            [Display(Name = "Perception")]
            Perception,
            [Display(Name = "Pulse")]
            Pulse,
            [Display(Name = "Rage")]
            Rage,
            [Display(Name = "Regenerate")]
            Regenerate,
            [Display(Name = "Speed Skill")]
            SpeedSkill,
            [Display(Name = "Staff")]
            Staff,
            [Display(Name = "Stealth")]
            Stealth,
            [Display(Name = "SurroundHit")]
            SurroundHit,
            [Display(Name = "Sword")]
            Sword,
            [Display(Name = "Tactics")]
            Tactics,
            [Display(Name = "Two-Handed")]
            TwoHanded,
            [Display(Name = "Warcry")]
            Warcry
        }

        public static Dictionary<Types, Attribute.Types[]> SkillModifiers = new Dictionary<Types, Attribute.Types[]>()
        {
            {Types.Hitpoints, new Attribute.Types[] {} }, //no attribute bonus
            {Types.Endurance, new Attribute.Types[] {} }, //no attribute bonus
            {Types.Mana, new Attribute.Types[] {} }, //no attribute bonus
            {Types.Profession, new Attribute.Types[] {} }, //no attribute bonus
            {Types.Archery, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Intuition, Attribute.Types.Strength } },
            {Types.ArmorSkill, new Attribute.Types[] { Attribute.Types.Agility, Attribute.Types.Agility, Attribute.Types.Strength } },
            {Types.Attack, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Agility, Attribute.Types.Strength } },
            {Types.Bartering, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Intuition, Attribute.Types.Wisdom } },
            {Types.Bless, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Intuition, Attribute.Types.Wisdom } },
            {Types.BodyControl, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Agility, Attribute.Types.Strength } },
            {Types.Dagger, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Agility, Attribute.Types.Strength } },
            {Types.Duration, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Wisdom, Attribute.Types.Strength } },
            {Types.Fire, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Intuition, Attribute.Types.Wisdom } },
            {Types.Freeze, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Intuition, Attribute.Types.Wisdom } },
            {Types.HandtoHand, new Attribute.Types[] { Attribute.Types.Agility, Attribute.Types.Strength, Attribute.Types.Strength } },
            {Types.Heal, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Intuition, Attribute.Types.Wisdom } },
            {Types.Immunity, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Intuition, Attribute.Types.Strength } },
            {Types.Lightning, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Intuition, Attribute.Types.Wisdom } },
            {Types.MagicShield, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Intuition, Attribute.Types.Wisdom } },
            {Types.Meditate, new Attribute.Types[] { Attribute.Types.Wisdom, Attribute.Types.Wisdom, Attribute.Types.Wisdom } },
            {Types.Parry, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Agility, Attribute.Types.Strength } },
            {Types.Perception, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Intuition, Attribute.Types.Wisdom } },
            {Types.Pulse, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Intuition, Attribute.Types.Wisdom } },
            {Types.Rage, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Strength, Attribute.Types.Strength } },
            {Types.Regenerate, new Attribute.Types[] { Attribute.Types.Strength, Attribute.Types.Strength, Attribute.Types.Strength } },
            {Types.SpeedSkill, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Agility, Attribute.Types.Strength } },
            {Types.Staff, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Agility, Attribute.Types.Strength } },
            {Types.Stealth, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Agility, Attribute.Types.Agility } },
            {Types.SurroundHit, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Agility, Attribute.Types.Strength } },
            {Types.Sword, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Intuition, Attribute.Types.Agility } },
            {Types.Tactics, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Wisdom, Attribute.Types.Strength } },
            {Types.TwoHanded, new Attribute.Types[] { Attribute.Types.Agility, Attribute.Types.Strength, Attribute.Types.Strength } },
            {Types.Warcry, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Agility, Attribute.Types.Strength } },
        };

        private readonly bool IsSeyan;
        
        public Skill(Types Type, bool IsSeyan = false)
        {
            this.Type = Type;
            this.IsSeyan = IsSeyan;
        }

        public Types Type { get; set; }
        public string DisplayName => Type.GetDisplayName();
        public string Modifiers => string.Join("/", SkillModifiers[Type].ToList());
        public int Start { get; set; }
        public int Base { get; set; }
        public int Cost { get; set; }
        public int AttributeBonus { get; set; }
        public int EquipmentBonus { get; set; }
        public int LevelBonus { get; set; }
        public int PtmBonus { get; set; }
        public int MaxAttributeMod => Base * 2;
        public int MaxEquipmentMod => IsSeyan
                    ? (int)Math.Floor(Base * 0.725)
                    : (int)Math.Floor(Base * 0.50);
        public bool MaxAttributeModExceeded => AttributeBonus > MaxAttributeMod;
        public bool MaxEquipmentModExceeded => EquipmentBonus > MaxEquipmentMod;
        public int Mod => CalculateMod();
        private int CalculateMod()
        {
            double newMod = 0;

            if (Type != Types.Profession)
            {
                newMod += Base;
                newMod += Math.Max(IsResource ? 15 : 0, Math.Min(AttributeBonus, MaxAttributeMod));
                newMod += Math.Min(EquipmentBonus, MaxEquipmentMod);
                newMod += LevelBonus;
                newMod += PtmBonus;
            }

            return (int)newMod;
        }

        private bool IsResource => Type == Types.Hitpoints || Type == Types.Endurance || Type == Types.Mana;

        public void SetAttributeBonus(List<Attribute> Attributes, int AdditionalBonus = 0)
        {
            var includedAttribs = new List<Attribute>();
            foreach(var mod in SkillModifiers[Type].ToList())
            {
                includedAttribs.AddRange(Attributes.Where(attrib => mod == attrib.Type));
            }

            int bonus = 0;
            foreach (var attr in includedAttribs)
            {
                bonus += attr.Mod;
            }
            bonus /= 5;

            AttributeBonus = bonus + AdditionalBonus;
        }
    }
}
