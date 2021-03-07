using Newtonsoft.Json;
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
        [JsonIgnore]
        public Skill Mana { get; set; } = new Skill(Skill.Types.Mana)
        {
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Staff { get; set; } = new Skill(Skill.Types.Staff)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Bless { get; set; } = new Skill(Skill.Types.Bless)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Heal { get; set; } = new Skill(Skill.Types.Heal)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Freeze { get; set; } = new Skill(Skill.Types.Freeze)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill MagicShield { get; set; } = new Skill(Skill.Types.MagicShield)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Lightning { get; set; } = new Skill(Skill.Types.Lightning)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Fire { get; set; } = new Skill(Skill.Types.Fire)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Pulse { get; set; } = new Skill(Skill.Types.Pulse)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Duration { get; set; } = new Skill(Skill.Types.Duration)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Meditate { get; set; } = new Skill(Skill.Types.Meditate)
        {
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
            int levelBonus = 0;
            if (CurrentLevel > 130)
            {
                levelBonus = 2;
            }
            else if (CurrentLevel > 140)
            {
                levelBonus = 3;
            }

            int ptmBonus = GetPtmBonus();

            //Unblessed attributes (WIAS) used to calculate bless attribute mod
            foreach (Attribute attribute in Attributes)
            {
                attribute.WarriorBonus = TimeWarriorBonus / 2;
                attribute.LevelBonus = levelBonus;
                attribute.BlessBonus = 0;
            }

            Bless.SetAttributeBonus(Attributes);
            Bless.LevelBonus = levelBonus;
            Bless.PtmBonus = 0;

            //Now apply bless mod to attributes for Skills
            //This whole bit looks overly complicated but does give the right numbers...
            if (Blessed)
            {
                foreach (Attribute attribute in Attributes)
                {
                    attribute.BlessBonus = (int)Math.Ceiling((double)Bless.Mod / 4);
                }

                Bless.SetAttributeBonus(Attributes);

                foreach (Attribute attribute in Attributes)
                {
                    attribute.BlessBonus = (int)Math.Ceiling((double)Bless.Mod / 4);
                }

                Bless.SetAttributeBonus(Attributes);
                Bless.PtmBonus = ptmBonus;
            }

            base.CalculateAttributeBonuses();

            //Arbitrary bonuses added for balance
            //Makes PTMs less linear
            foreach (Skill skill in Skills)
            {
                skill.LevelBonus = levelBonus;

                if (skill.Type == Skill.Types.MagicShield && CurrentLevel > 140)
                {
                    skill.LevelBonus -= 1;
                }

                if (skill.Type != Skill.Types.Hitpoints &&
                    skill.Type != Skill.Types.Endurance &&
                    skill.Type != Skill.Types.Mana &&
                    skill.Type != Skill.Types.Profession)
                {
                    skill.PtmBonus = ptmBonus;
                }
            }
        }

        public override void CalculateAncillaryStats()
        {
            base.CalculateAncillaryStats();

            Speed = ((Agility.Mod * 3) / 5) + (AthleteBonus * 3);

            WeaponValue = 0; //Mage only gets wv from wep

            double spellAvg = SpellsAverageMod();

            ArmorValue = (spellAvg * 17.5) / 20;

            List<Skill> weaponSkills = new List<Skill>()
            {
                Dagger,
                Staff,
                HandToHand
            };

            int weaponSkillMod = weaponSkills.Max(s => s.Mod);

            Offence = (int)Math.Floor(weaponSkillMod + (spellAvg * 2) - Math.Truncate(CurrentLevel));
            Defence = weaponSkillMod + (MagicShield.Mod * 2);

            BlessBonus = (int)Math.Ceiling((double)Bless.Mod / 4);
            BlessBonusMaxed = Attributes.Count(a => a.MaxBlessModExceeded) == 4;
        }

        private double SpellsAverageMod()
        {
            return (Lightning.Mod + Fire.Mod + Freeze.Mod + Heal.Mod + Bless.Mod + MagicShield.Mod + Pulse.Mod) / 7;
        }
    }
}
