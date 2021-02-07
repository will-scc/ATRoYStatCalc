using System;
using System.Collections.Generic;
using System.Linq;

namespace ATRoYStatCalc.Model
{
    public class Rogue : BaseClass
    {
        public bool IncludeTactics { get; set; }
        public int TacticsOffDefBonus { get; set; }
        public int TacticsSkillBonus { get; set; }
        public int TacticsImmunityBonus { get; set; }

        #region "Skills"
        public Skill Sword { get; set; } = new Skill(false)
        {
            DisplayName = "Sword",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Archery { get; set; } = new Skill(false)
        {
            DisplayName = "Archery",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Rage { get; set; } = new Skill(false)
        {
            DisplayName = "Rage",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill ArmorSkill { get; set; } = new Skill(false)
        {
            DisplayName = "Armor Skill",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Attack { get; set; } = new Skill(false)
        {
            DisplayName = "Attack",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Parry { get; set; } = new Skill(false)
        {
            DisplayName = "Parry",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Warcry { get; set; } = new Skill(false)
        {
            DisplayName = "Warcry",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Tactics { get; set; } = new Skill(false)
        {
            DisplayName = "Tactics",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill SurroundHit { get; set; } = new Skill(false)
        {
            DisplayName = "Surround Hit",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill BodyControl { get; set; } = new Skill(false)
        {
            DisplayName = "Body Control",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill SpeedSkill { get; set; } = new Skill(false)
        {
            DisplayName = "Speed Skill",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Regenerate { get; set; } = new Skill(false)
        {
            DisplayName = "Regenerate",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        #endregion
        public Rogue() { }

        public override void SetupSkills()
        {
            base.SetupSkills();

            Skills.AddDistinctSkill(Sword);
            Skills.AddDistinctSkill(Archery);
            Skills.AddDistinctSkill(Rage);
            Skills.AddDistinctSkill(ArmorSkill);
            Skills.AddDistinctSkill(Attack);
            Skills.AddDistinctSkill(Parry);
            Skills.AddDistinctSkill(Warcry);
            Skills.AddDistinctSkill(Tactics);
            Skills.AddDistinctSkill(SurroundHit);
            Skills.AddDistinctSkill(BodyControl);
            Skills.AddDistinctSkill(SpeedSkill);
            Skills.AddDistinctSkill(Regenerate);
        }

        public override void CalculateAttributeBonuses()
        {
            base.CalculateAttributeBonuses();

            Sword.AttributeBonus = (Intuition.Mod + Intuition.Mod + Agility.Mod) / 5;
            Archery.AttributeBonus = (Intuition.Mod + Intuition.Mod + Strength.Mod) / 5;
            ArmorSkill.AttributeBonus = (Agility.Mod + Agility.Mod + Strength.Mod) / 5;
            Attack.AttributeBonus = ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5) + GetTacticsSkillBonus();
            Parry.AttributeBonus = ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5) + GetTacticsSkillBonus();
            Warcry.AttributeBonus = ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5) + GetTacticsSkillBonus();
            Tactics.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            SurroundHit.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            BodyControl.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            SpeedSkill.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            Rage.AttributeBonus = (Strength.Mod + Strength.Mod + Intuition.Mod) / 5;

            Immunity.AttributeBonus = ((Intuition.Mod + Intuition.Mod + Strength.Mod) / 5) + GetTacticsSkillBonus(true);
        }

        public override void CalculateAncillaryStats()
        {
            base.CalculateAncillaryStats();

            Speed = ((Agility.Mod * 3) / 5) + (AthleteBonus * 3) + (SpeedSkill.Mod / 3);

            WeaponValue = (BodyControl.Mod / 4);
            ArmourValue = (BodyControl.Mod + ArmorSkill.Mod) * 0.25;

            List<Skill> weaponSkills = new List<Skill>()
            {
                Dagger,
                HandToHand,
                Sword,
                Archery
            };

            int weaponSkillMod = weaponSkills.Max(s => s.Mod);

            Offence = (Attack.Mod * 2) + weaponSkillMod + GetTacticsOffDefBonus();
            Defence = (Parry.Mod * 2) + weaponSkillMod + GetTacticsOffDefBonus();

            TacticsOffDefBonus = (int)Math.Floor(Tactics.Mod * 0.375);
            TacticsSkillBonus = (int)Math.Floor((double)Tactics.Mod / 8);
            TacticsImmunityBonus = (int)Math.Floor(Tactics.Mod / 8.08);
        }

        private int GetTacticsSkillBonus(bool IsImmunity = false)
        {
            return IncludeTactics
                ? IsImmunity
                    ? (int)Math.Floor(Tactics.Mod / 8.08)
                    : (int)Math.Floor((double)Tactics.Mod / 8)
                : 0;
        }

        private int GetTacticsOffDefBonus()
        {
            return IncludeTactics ? (int)Math.Floor(Tactics.Mod * 0.375) : 0;
        }
    }
}
