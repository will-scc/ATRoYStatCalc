using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ATRoYStatCalc.Model
{
    public class Warrior : BaseClass
    {
        public bool IncludeTactics { get; set; }
        public int TacticsOffDefBonus { get; set; }
        public int TacticsSkillBonus { get; set; }
        public int TacticsImmunityBonus { get; set; }

        #region "Skills"
        [JsonIgnore]
        public Skill Sword { get; set; } = new Skill(Skill.Types.Sword)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill TwoHanded { get; set; } = new Skill(Skill.Types.TwoHanded)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Rage { get; set; } = new Skill(Skill.Types.Rage)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill ArmorSkill { get; set; } = new Skill(Skill.Types.ArmorSkill)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Attack { get; set; } = new Skill(Skill.Types.Attack)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Parry { get; set; } = new Skill(Skill.Types.Parry)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Warcry { get; set; } = new Skill(Skill.Types.Warcry)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Tactics { get; set; } = new Skill(Skill.Types.Tactics)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill SurroundHit { get; set; } = new Skill(Skill.Types.SurroundHit)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill BodyControl { get; set; } = new Skill(Skill.Types.BodyControl)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill SpeedSkill { get; set; } = new Skill(Skill.Types.SpeedSkill)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Regenerate { get; set; } = new Skill(Skill.Types.Regenerate)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        #endregion
        public Warrior() { }

        public override void SetupSkills()
        {
            base.SetupSkills();

            Skills.AddDistinctSkill(Sword);
            Skills.AddDistinctSkill(TwoHanded);
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
            int levelBonus = 0;
            if (CurrentLevel > 90)
            {
                levelBonus = 1;
            }
            else if (CurrentLevel > 140)
            {
                levelBonus = 3;
            }

            int ptmBonus = GetPtmBonus();
            int tacBonus = GetTacticsSkillBonus(); //will be 0 if not shown
            int tacImmBonus = GetTacticsSkillBonus(true); //will be 0 if not shown

            base.CalculateAttributeBonuses();

            foreach (Attribute attribute in Attributes)
            {
                attribute.LevelBonus = levelBonus;
            }

            //these get tactics bonus so do separately
            Attack.SetAttributeBonus(Attributes, tacBonus);
            Parry.SetAttributeBonus(Attributes, tacBonus);
            Warcry.SetAttributeBonus(Attributes, tacBonus);
            Immunity.SetAttributeBonus(Attributes, tacImmBonus);

            foreach (Skill skill in Skills)
            {
                skill.LevelBonus = levelBonus;

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

            Speed = ((Agility.Mod + Agility.Mod + Strength.Mod) / 5) + (AthleteBonus * 3) + (SpeedSkill.Mod / 2);

            WeaponValue = (BodyControl.Mod / 4);
            ArmorValue = (BodyControl.Mod + ArmorSkill.Mod) * 0.25;

            List<Skill> weaponSkills = new List<Skill>()
            {
                Dagger,
                HandToHand,
                Sword,
                TwoHanded
            };

            int weaponSkillMod = weaponSkills.Max(s => s.Mod);

            //tactics bonus to off/def is always included
            Offence = (Attack.Mod * 2) + weaponSkillMod + (int)Math.Floor(Tactics.Mod * 0.375);
            Defence = (Parry.Mod * 2) + weaponSkillMod + (int)Math.Floor(Tactics.Mod * 0.375);

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

        public override int RaiseCost(Skill Skill, int NextLevel)
        {
            int maxNonPTMBase = HardCore ? 122 : 115;
            int nr = NextLevel - Skill.Start + 1 + 5;

            if (NextLevel < maxNonPTMBase)
            {
                return (int)(Math.Max(1, nr * nr * nr * Skill.Cost / 10) / 1.245275);
            }
            else
            {
                int normalCost = (int)(Math.Max(1, nr * nr * nr * Skill.Cost / 10) / 1.245275);
                int ptmCost = (int)(3000000 * 0.8771);
                return 1 + normalCost + ptmCost;
            }
        }

        public override int RaiseCost(Attribute Attribute, int NextLevel)
        {
            int maxNonPTMBase = HardCore ? 122 : 115;
            int nr = NextLevel - Attribute.Start + 1 + 5;

            if (NextLevel < maxNonPTMBase)
            {
                return (int)Math.Ceiling(Math.Max(1, nr * nr * nr * Attribute.Cost / 10) / 1.245275);
            }
            else
            {
                int normalCost = (int)(Math.Max(1, nr * nr * nr * Attribute.Cost / 10) / 1.245275);
                int ptmCost = 6000000;
                return 2 + normalCost + ptmCost;
            }
        }
    }
}
