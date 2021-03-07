using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATRoYStatCalc.Model
{
    public static class Stats
    {
        public enum Resource
        {
            [Display(Name = "Hitpoints")]
            Hitpoints,
            [Display(Name = "Endurance")]
            Endurance,
            [Display(Name = "Mana")]
            Mana
        }

        public enum Skill
        {
            [Display(Name="Archery")]
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

        public static Dictionary<Skill, Attribute.Types[]> SkillModifiers = new Dictionary<Skill, Attribute.Types[]>()
        {
            {Skill.Archery, new Attribute.Types[] { Attribute.Types.Intuition, Attribute.Types.Intuition, Attribute.Types.Strength } }

        };
    }
}
