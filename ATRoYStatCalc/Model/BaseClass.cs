using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ATRoYStatCalc.Model
{
    public class BaseClass : ObservableObject
    {
        public const long MaxExp = 1600000000;
        public int MaxBase { get; } = 230;
        public string CharacterName { get; set; } = "Unnamed Character";
        public bool MaxExpExceeded => CurrentExp > MaxExp;
        public bool PvP { get; set; }
        public bool HardCore { get; set; } = false;
        public long CurrentExp { get; set; }
        public double CurrentLevel { get; set; }
        public double WeaponValue { get; set; }
        public double ArmourValue { get; set; }
        public int Speed { get; set; }
        public int Offence { get; set; }
        public int Defence { get; set; }
        public int AthleteBonus { get; set; }
        public int TimeWarriorBonus { get; set; }
        public int ClanWarriorBonus { get; set; }
        public bool MissingProfessionBases => Profession.Base < Profession.Mod;
        
        #region "Attributes"
        [JsonIgnore]
        public List<Attribute> Attributes { get; set; } = new List<Attribute>();
        public Attribute Wisdom { get; set; } = new Attribute(false)
        {
            DisplayName = "Wisdom",
            Start = 10,
            Base = 10,
            Cost = 2
        };
        public Attribute Intuition { get; set; } = new Attribute(false)
        {
            DisplayName = "Intuition",
            Start = 10,
            Base = 10,
            Cost = 2
        };
        public Attribute Agility { get; set; } = new Attribute(false)
        {
            DisplayName = "Agility",
            Start = 10,
            Base = 10,
            Cost = 2
        };
        public Attribute Strength { get; set; } = new Attribute(false)
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
        public Skill Hitpoints { get; set; } = new Skill(false, true)
        {
            DisplayName = "Hitpoints",
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Endurance { get; set; } = new Skill(false, true)
        {
            DisplayName = "Endurance",
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Dagger { get; set; } = new Skill(false)
        {
            DisplayName = "Dagger",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill HandToHand { get; set; } = new Skill(false)
        {
            DisplayName = "Hand to Hand",
            Start = 1,
            Base = 1,
            Cost = 1,
        };
        public Skill Bartering { get; set; } = new Skill(false)
        {
            DisplayName = "Bartering",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Perception { get; set; } = new Skill(false)
        {
            DisplayName = "Perception",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Stealth { get; set; } = new Skill(false)
        {
            DisplayName = "Stealth",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Immunity { get; set; } = new Skill(false)
        {
            DisplayName = "Immunity",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Profession { get; set; } = new Skill(false)
        {
            DisplayName = "Profession",
            Start = 1,
            Base = 1,
            Cost = 3
        };
        #endregion

        public BaseClass() { }

        //Required for setup
        //Must be done this way to work when deserializing from json
        public virtual void SetupSkills()
        {
            Attributes.AddDistinctAttribute(Wisdom);
            Attributes.AddDistinctAttribute(Intuition);
            Attributes.AddDistinctAttribute(Agility);
            Attributes.AddDistinctAttribute(Strength);

            Skills.AddDistinctSkill(Hitpoints);
            Skills.AddDistinctSkill(Endurance);
            Skills.AddDistinctSkill(Dagger);
            Skills.AddDistinctSkill(HandToHand);
            Skills.AddDistinctSkill(Bartering);
            Skills.AddDistinctSkill(Perception);
            Skills.AddDistinctSkill(Stealth);
            Skills.AddDistinctSkill(Immunity);
            Skills.AddDistinctSkill(Profession);
        }

        public virtual void UpdateCharacter()
        {
            CalculateLevel();
            CalculateAttributeBonuses();
            CalculateAncillaryStats();
        }
       
        public void CalculateLevel()
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
        
        public virtual void CalculateAttributeBonuses()
        {
            Dagger.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            HandToHand.AttributeBonus = (Agility.Mod + Strength.Mod + Strength.Mod) / 5;

            Bartering.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Perception.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Stealth.AttributeBonus = (Agility.Mod + Agility.Mod + Intuition.Mod) / 5;
            Immunity.AttributeBonus = (Intuition.Mod + Intuition.Mod + Strength.Mod) / 5;
        }

        public virtual void CalculateAncillaryStats()
        {
            Profession.Base = AthleteBonus + TimeWarriorBonus;
        }

        public int RaiseCost(Skill Skill, int NextLevel)
        {
            int maxNonPTMBase = HardCore ? 122 : 115;
            int nr = NextLevel - Skill.Start + 1 + 5;

            if (NextLevel < maxNonPTMBase)
            {
                return Math.Max(1, nr * nr * nr * Skill.Cost / 10);
            }
            else
            {
                int normalCost = Math.Max(1, nr * nr * nr * Skill.Cost / 10);
                int ptmCost = 3000000;
                return normalCost + ptmCost;
            }
        }

        public int RaiseCost(Attribute Attribute, int NextLevel)
        {
            int maxNonPTMBase = HardCore ? 122 : 115;
            int nr = NextLevel - Attribute.Start + 1 + 5;

            if (NextLevel < maxNonPTMBase)
            {
                return Math.Max(1, nr * nr * nr * Attribute.Cost / 10);
            }
            else
            {
                int normalCost = Math.Max(1, nr * nr * nr * Attribute.Cost / 10);
                int ptmCost = 6000000;
                return normalCost + ptmCost;
            }
        }
    }
}
