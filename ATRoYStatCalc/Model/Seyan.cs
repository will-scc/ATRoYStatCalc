using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
namespace ATRoYStatCalc.Model
{
    public class Seyan : ObservableObject
    {
        public const long MaxExp = 1600000000;
        public int MaxBase { get; } = 202;
        private int MaxNonPTMBase => HardCore ? 107 : 100; 
        public string CharacterName { get; set; } = "Unnamed Character";
        public bool MaxExpExceeded => CurrentExp > MaxExp;
        public bool PvP { get; set; }
        public bool HardCore { get; set; } = false;
        public long CurrentExp { get; set; }
        public double CurrentLevel { get; set; }
        public double WeaponValue { get; set; }
        public double ExtraWeaponValue { get; set; }
        public double ArmourValue { get; set; }
        public double ExtraArmourValue { get; set; }
        public int Speed { get; set; }
        public int ExtraSpeed { get; set; }
        public int Offence { get; set; }
        public int Defence { get; set; }
        public int AthleteBonus { get; set; }
        public int TimeWarriorBonus { get; set; }
        public int ClanWarriorBonus { get; set; }
        public bool IncludeTactics { get; set; }
        public int TacticsOffDefBonus { get; set; }
        public int TacticsSkillBonus { get; set; }
        public int TacticsImmunityBonus { get; set; }
        public bool Blessed { get; set; }
        public int BlessBonus { get; set; }
        public bool BlessBonusMaxed { get; set; }
        public bool MissingProfessionBases => Profession.Base < Profession.Mod;

        #region "Attributes"
        [JsonIgnore]
        public List<Attribute> Attributes { get; set; } = new List<Attribute>();
        public Attribute Wisdom { get; set; } = new Attribute(true)
        {
            DisplayName = "Wisdom",
            Start = 10,
            Base = 10,
            Cost = 2
        };
        public Attribute Intuition { get; set; } = new Attribute(true)
        {
            DisplayName = "Intuition",
            Start = 10,
            Base = 10,
            Cost = 2
        };
        public Attribute Agility { get; set; } = new Attribute(true)
        {
            DisplayName = "Agility",
            Start = 10,
            Base = 10,
            Cost = 2
        };
        public Attribute Strength { get; set; } = new Attribute(true)
        {
            DisplayName = "Strength",
            Start = 10,
            Base = 10,
            Cost = 2
        };
        #endregion

        #region "Skills"
        [JsonIgnore]
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public Skill Hitpoints { get; set; } = new Skill(true, true)
        {
            DisplayName = "Hitpoints",
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Endurance { get; set; } = new Skill(true, true)
        {
            DisplayName = "Endurance",
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Mana { get; set; } = new Skill(true, true)
        {
            DisplayName = "Mana",
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Dagger { get; set; } = new Skill(true)
        {
            DisplayName = "Dagger",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill HandToHand { get; set; } = new Skill(true)
        {
            DisplayName = "Hand to Hand",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Sword { get; set; } = new Skill(true)
        {
            DisplayName = "Sword",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill TwoHanded { get; set; } = new Skill(true)
        {
            DisplayName = "TwoHanded",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill ArmorSkill { get; set; } = new Skill(true)
        {
            DisplayName = "Armor Skill",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Attack { get; set; } = new Skill(true)
        {
            DisplayName = "Attack",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Parry { get; set; } = new Skill(true)
        {
            DisplayName = "Parry",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Warcry { get; set; } = new Skill(true)
        {
            DisplayName = "Warcry",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Tactics { get; set; } = new Skill(true)
        {
            DisplayName = "Tactics",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill SurroundHit { get; set; } = new Skill(true)
        {
            DisplayName = "Surround Hit",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill BodyControl { get; set; } = new Skill(true)
        {
            DisplayName = "Body Control",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill SpeedSkill { get; set; } = new Skill(true)
        {
            DisplayName = "Speed Skill",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Regenerate { get; set; } = new Skill(true)
        {
            DisplayName = "Regenerate",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Bless { get; set; } = new Skill(true)
        {
            DisplayName = "Bless",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Heal { get; set; } = new Skill(true)
        {
            DisplayName = "Heal",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Freeze { get; set; } = new Skill(true)
        {
            DisplayName = "Freeze",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill MagicShield { get; set; } = new Skill(true)
        {
            DisplayName = "Magic Shield",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Lightning { get; set; } = new Skill(true)
        {
            DisplayName = "Lightning",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Fire { get; set; } = new Skill(true)
        {
            DisplayName = "Fire",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Pulse { get; set; } = new Skill(true)
        {
            DisplayName = "Pulse",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Meditate { get; set; } = new Skill(true)
        {
            DisplayName = "Meditate",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Bartering { get; set; } = new Skill(true)
        {
            DisplayName = "Bartering",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Perception { get; set; } = new Skill(true)
        {
            DisplayName = "Perception",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Stealth { get; set; } = new Skill(true)
        {
            DisplayName = "Stealth",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Immunity { get; set; } = new Skill(true)
        {
            DisplayName = "Immunity",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Profession { get; set; } = new Skill(true)
        {
            DisplayName = "Profession",
            Start = 1,
            Base = 1,
            Cost = 3
        };
        #endregion

        public Seyan() { }

        public void SetupSkills()
        {
            Attributes.AddDistinctAttribute(Wisdom);
            Attributes.AddDistinctAttribute(Intuition);
            Attributes.AddDistinctAttribute(Agility);
            Attributes.AddDistinctAttribute(Strength);

            Skills.AddDistinctSkill(Hitpoints);
            Skills.AddDistinctSkill(Endurance);
            Skills.AddDistinctSkill(Mana);
            Skills.AddDistinctSkill(Dagger);
            Skills.AddDistinctSkill(HandToHand);
            Skills.AddDistinctSkill(Sword);
            Skills.AddDistinctSkill(TwoHanded);
            Skills.AddDistinctSkill(ArmorSkill);
            Skills.AddDistinctSkill(Attack);
            Skills.AddDistinctSkill(Parry);
            Skills.AddDistinctSkill(Warcry);
            Skills.AddDistinctSkill(Tactics);
            Skills.AddDistinctSkill(SurroundHit);
            Skills.AddDistinctSkill(BodyControl);
            Skills.AddDistinctSkill(SpeedSkill);
            Skills.AddDistinctSkill(Regenerate);
            Skills.AddDistinctSkill(Bless);
            Skills.AddDistinctSkill(Heal);
            Skills.AddDistinctSkill(Freeze);
            Skills.AddDistinctSkill(MagicShield);
            Skills.AddDistinctSkill(Lightning);
            Skills.AddDistinctSkill(Fire);
            Skills.AddDistinctSkill(Pulse);
            Skills.AddDistinctSkill(Meditate);
            Skills.AddDistinctSkill(Bartering);
            Skills.AddDistinctSkill(Perception);
            Skills.AddDistinctSkill(Stealth);
            Skills.AddDistinctSkill(Immunity);
            Skills.AddDistinctSkill(Profession);
        }

        public void UpdateCharacter()
        {
            CalculateLevel();
            CalculateAttributeBonuses();
            CalculateAncillaryStats();
        }

        private void CalculateLevel()
        {
            long totalSpentExp = 0;

            foreach (Attribute attribute in Attributes)
            {
                int attributeExp = 0;
                for (int i = attribute.Start; i < attribute.Base; i++)
                {
                    attributeExp += RaiseCost(attribute, i);
                }
                totalSpentExp += attributeExp;
            }

            foreach (Skill skill in Skills)
            {
                int skillExp = 0;
                for (int i = skill.Start; i < skill.Base; i++)
                {
                    skillExp += RaiseCost(skill, i);
                }
                totalSpentExp += skillExp;
            }

            CurrentExp = totalSpentExp;
            CurrentLevel = HelperFuncs.GetLevelFromExp(CurrentExp);
        }

        private void CalculateAttributeBonuses()
        {
            int levelBonus = CurrentLevel > 160 ? 1 : 0;
            int ptmBonus = GetPtmBonus();
            int tacBonus = GetTacticsSkillBonus(); //will be 0 if not shown
            int tacImmBonus = GetTacticsSkillBonus(true); //will be 0 if not shown

            //Unblessed attributes (WIAS) used to calculate bless attribute mod
            foreach (Attribute attribute in Attributes)
            {
                attribute.WarriorBonus = TimeWarriorBonus / 2;
                attribute.LevelBonus = levelBonus;
                attribute.BlessBonus = 0;
            }

            //Calculate bless mod from unblessed WIAS
            Bless.AttributeBonus = ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5) + tacBonus;
            Bless.LevelBonus = levelBonus;
            Bless.PtmBonus = 0;
            Tactics.LevelBonus = levelBonus;

            if (Blessed)
            {
                //Calculate attribute bonus from unblessed bless mod
                foreach (Attribute attribute in Attributes)
                {
                    attribute.BlessBonus = (int)Math.Ceiling((double)((Bless.Mod + (Tactics.Mod * 0.125)) / 4));
                }

                //Calculate bless mod from bless
                Bless.AttributeBonus = ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5) + tacBonus;

                //Calculate attribute bonus from new bless mod
                foreach (Attribute attribute in Attributes)
                {
                    attribute.BlessBonus = (int)Math.Ceiling((double)(Bless.Mod / 4));
                }

                //Calculate blessed bless mod for other skills
                Bless.AttributeBonus = ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5) + tacBonus;
                Bless.PtmBonus = ptmBonus;
            }

            Dagger.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            HandToHand.AttributeBonus = (Agility.Mod + Strength.Mod + Strength.Mod) / 5;
            Sword.AttributeBonus = (Intuition.Mod + Intuition.Mod + Agility.Mod) / 5;
            TwoHanded.AttributeBonus = (Agility.Mod + Agility.Mod + Strength.Mod) / 5;

            ArmorSkill.AttributeBonus = (Agility.Mod + Agility.Mod + Strength.Mod) / 5;
            Attack.AttributeBonus = ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5) + tacBonus;
            Parry.AttributeBonus = ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5) + tacBonus;
            Warcry.AttributeBonus = ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5) + tacBonus;
            Tactics.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Strength.Mod) / 5;
            SurroundHit.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            BodyControl.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            SpeedSkill.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;

            Heal.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Freeze.AttributeBonus = ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5) + tacBonus;
            MagicShield.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Lightning.AttributeBonus = ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5) + tacBonus;
            Fire.AttributeBonus = ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5) + tacBonus;
            Pulse.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;

            Bartering.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Perception.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Stealth.AttributeBonus = (Agility.Mod + Agility.Mod + Intuition.Mod) / 5;
            Regenerate.AttributeBonus = (Strength.Mod + Strength.Mod + Strength.Mod) / 5;
            Meditate.AttributeBonus = (Wisdom.Mod + Wisdom.Mod + Wisdom.Mod) / 5;
            Immunity.AttributeBonus = ((Intuition.Mod + Intuition.Mod + Strength.Mod) / 5) + tacImmBonus;

            //Arbitrary bonuses added for balance
            //Makes PTMs less linear
            foreach (Skill skill in Skills)
            {
                skill.LevelBonus = levelBonus;

                if (skill.DisplayName != "Hitpoints" &&
                    skill.DisplayName != "Endurance" &&
                    skill.DisplayName != "Mana" &&
                    skill.DisplayName != "Profession")
                {
                    skill.PtmBonus = ptmBonus;
                }
            }
        }

        private void CalculateAncillaryStats()
        {
            Profession.Base = AthleteBonus + TimeWarriorBonus;

            Speed = ((Agility.Mod + Agility.Mod + Strength.Mod) / 5) + (AthleteBonus * 3) + (SpeedSkill.Mod / 2) + ExtraSpeed; 
            WeaponValue = ExtraWeaponValue + (BodyControl.Mod / 4);
            ArmourValue = ExtraArmourValue + (BodyControl.Mod + ArmorSkill.Mod) * 0.25;

            List<Skill> weaponSkills = new List<Skill>()
            {
                Dagger,
                HandToHand,
                Sword,
                TwoHanded
            };

            int weaponSkillMod = weaponSkills.Max(s => s.Mod);

            Offence = (Attack.Mod * 2) + weaponSkillMod + GetTacticsOffDefBonus();
            Defence = (Parry.Mod * 2) + weaponSkillMod + GetTacticsOffDefBonus();

            TacticsOffDefBonus = (int)Math.Floor(Tactics.Mod * 0.375);
            TacticsSkillBonus = (int)Math.Floor((double)Tactics.Mod / 8);
            TacticsImmunityBonus = (int)Math.Floor(Tactics.Mod / 8.08);

            BlessBonus = (int)Math.Ceiling((double)Bless.Mod / 4);
            BlessBonusMaxed = Attributes.Count(a => a.MaxBlessModExceeded) == 4;
        }

        private int GetPtmBonus()
        {
            int threshold = 200;
            int start = 132;
            int diff = 0;
            int nStats = 0;

            foreach (Skill skill in Skills)
            {
                //Should be a better way to identify these rather than by DisplayName
                if (skill.DisplayName != "Hitpoints" &&
                    skill.DisplayName != "Endurance" &&
                    skill.DisplayName != "Mana" &&
                    skill.DisplayName != "Profession")
                {
                    if (skill.Base >= threshold) nStats++;
                    if (skill.Base >= start) diff += skill.Base - start;
                }
            }

            if (diff != 0 && nStats > 1)
            {
                int startDiff = (threshold - start) * 4;
                if (startDiff < 1) startDiff = 1;

                int boost = 11;
                boost = (int)Math.Floor((double)(boost * diff) / startDiff);
                boost = (int)Math.Floor((double)(boost * nStats) / 4);

                return boost;
            }
            return 0;
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

        private int RaiseCost(Attribute Attribute, int NextLevel)
        {
            int nr = NextLevel - Attribute.Start + 1 + 5;

            if (NextLevel < MaxNonPTMBase)
            {
                return Math.Max(1, (nr * nr * nr * Attribute.Cost * 4) / 30);
            }
            else
            {
                int normalCost = Math.Max(1, (nr * nr * nr * Attribute.Cost * 4) / 30);
                int ptmCost = 6000000;
                return normalCost + ptmCost;
            }
        }

        private int RaiseCost(Skill Skill, int NextLevel)
        {
            int maxNonPTMBase = HardCore ? 107 : 100;
            int nr = NextLevel - Skill.Start + 1 + 5;

            if (NextLevel < maxNonPTMBase)
            {
                return Math.Max(1, (nr * nr * nr * Skill.Cost * 4) / 30);
            }
            else
            {
                int normalCost = Math.Max(1, (nr * nr * nr * Skill.Cost * 4) / 30);
                int ptmCost = 3000000;
                return normalCost + ptmCost;
            }
        }
    }
}