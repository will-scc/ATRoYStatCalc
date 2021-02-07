using System;
using System.Collections.Generic;
using System.Linq;

namespace ATRoYStatCalc.Model
{
    public class Mage : BaseClass
    {
        public bool Blessed { get; set; }
        public int BlessBonus { get; set; }
        public bool BlessBonusMaxed { get; set; }

        #region "Skills"
        public Skill Mana { get; set; } = new Skill(false)
        {
            DisplayName = "Mana",
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Staff { get; set; } = new Skill(false)
        {
            DisplayName = "Staff",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Bless { get; set; } = new Skill(false)
        {
            DisplayName = "Bless",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Heal { get; set; } = new Skill(false)
        {
            DisplayName = "Heal",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Freeze { get; set; } = new Skill(false)
        {
            DisplayName = "Freeze",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill MagicShield { get; set; } = new Skill(false)
        {
            DisplayName = "Magic Shield",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Lightning { get; set; } = new Skill(false)
        {
            DisplayName = "Lightning",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Fire { get; set; } = new Skill(false)
        {
            DisplayName = "Fire",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Pulse { get; set; } = new Skill(false)
        {
            DisplayName = "Pulse",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Duration { get; set; } = new Skill(false)
        {
            DisplayName = "Duration",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Meditate { get; set; } = new Skill(false)
        {
            DisplayName = "Meditate",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        #endregion
        public Mage() { }

        public override void SetupSkills()
        {
            base.SetupSkills();

            Skills.AddDistinctSkill(Mana);
            Skills.AddDistinctSkill(Staff);
            Skills.AddDistinctSkill(Bless);
            Skills.AddDistinctSkill(Heal);
            Skills.AddDistinctSkill(Freeze);
            Skills.AddDistinctSkill(MagicShield);
            Skills.AddDistinctSkill(Lightning);
            Skills.AddDistinctSkill(Fire);
            Skills.AddDistinctSkill(Pulse);
            Skills.AddDistinctSkill(Duration);
            Skills.AddDistinctSkill(Meditate);
        }

        public override void UpdateCharacter()
        {
            CalculateLevel();
            CalculateAttributeBonuses();
            CalculateAncillaryStats();
        }

        public override void CalculateAttributeBonuses()
        {
            //Unblessed attributes (WIAS) used to calculate bless attribute mod
            foreach (Attribute attribute in Attributes)
            {
                attribute.BlessBonus = 0;
                attribute.WarriorBonus = TimeWarriorBonus / 2;
            }

            Bless.AttributeBonus = ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);

            //Now apply bless mod to attributes for Skills
            //This whole bit looks overly complicated but does give the right numbers...
            if (Blessed)
            {
                foreach (Attribute attribute in Attributes)
                {
                    attribute.BlessBonus = (int)Math.Ceiling((double)Bless.Mod / 4);
                }

                Bless.AttributeBonus = ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);

                foreach (Attribute attribute in Attributes)
                {
                    attribute.BlessBonus = (int)Math.Ceiling((double)Bless.Mod / 4);
                }

                Bless.AttributeBonus = ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            }

            base.CalculateAttributeBonuses();

            Staff.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;

            Bless.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Heal.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Freeze.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            MagicShield.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Lightning.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Fire.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Pulse.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;

            Duration.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Strength.Mod) / 5;
            Meditate.AttributeBonus = (Wisdom.Mod + Wisdom.Mod + Wisdom.Mod) / 5;
        }

        public override void CalculateAncillaryStats()
        {
            base.CalculateAncillaryStats();
            
            Speed = ((Agility.Mod * 3) / 5) + (AthleteBonus * 3);

            WeaponValue = 0; //Mage only gets wv from wep

            double spellAvg = SpellsAverageMod();

            ArmourValue = (spellAvg * 17.5) / 20;

            List<Skill> weaponSkills = new List<Skill>()
            {
                Dagger,
                Staff,
                HandToHand
            };

            int weaponSkillMod = weaponSkills.Max(s => s.Mod);

            Offence = (int)Math.Floor(weaponSkillMod + (spellAvg * 2) - Math.Truncate(CurrentLevel));
            Defence = weaponSkillMod + (MagicShield.Mod * 2);
        }

        private double SpellsAverageMod()
        {
            return (Lightning.Mod + Fire.Mod + Freeze.Mod + Heal.Mod + Bless.Mod + MagicShield.Mod + Pulse.Mod) / 7;
        }
    }
}
