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
        public int MaxNonPTMBase => HardCore ? 122 : 115;
        public string CharacterName { get; set; } = "Unnamed Character";
        public bool MaxExpExceeded => CurrentExp > MaxExp;
        public bool PvP { get; set; }
        public bool HardCore { get; set; } = false;
        public long CurrentExp { get; set; }
        public double CurrentLevel { get; set; }
        public double WeaponValue { get; set; }
        public double ExtraWeaponValue { get; set; }
        public double ArmorValue { get; set; }
        public double ExtraArmorValue { get; set; }
        public int Speed { get; set; }
        public int ExtraSpeed { get; set; }
        public int Offence { get; set; }
        public int Defence { get; set; }
        public int AthleteBonus { get; set; }
        public int TimeWarriorBonus { get; set; }
        public int ClanWarriorBonus { get; set; }
        public bool MissingProfessionBases => Profession.Base < Profession.Mod;

        #region "Attributes"
        [JsonIgnore]
        public List<Attribute> Attributes { get; set; } = new List<Attribute>();
        public Attribute Wisdom { get; set; } = new Attribute(Attribute.Types.Wisdom)
        {
            Start = 10,
            Base = 10,
            Cost = 2
        };
        public Attribute Intuition { get; set; } = new Attribute(Attribute.Types.Intuition)
        {
            Start = 10,
            Base = 10,
            Cost = 2
        };
        public Attribute Agility { get; set; } = new Attribute(Attribute.Types.Agility)
        {
            Start = 10,
            Base = 10,
            Cost = 2
        };
        public Attribute Strength { get; set; } = new Attribute(Attribute.Types.Strength)
        {
            Start = 10,
            Base = 10,
            Cost = 2
        };
        #endregion

        #region "Skills"
        [JsonIgnore]
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public Skill Hitpoints { get; set; } = new Skill(Skill.Types.Hitpoints)
        {
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Endurance { get; set; } = new Skill(Skill.Types.Endurance)
        {
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Dagger { get; set; } = new Skill(Skill.Types.Dagger)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill HandToHand { get; set; } = new Skill(Skill.Types.HandtoHand)
        {
            Start = 1,
            Base = 1,
            Cost = 1,
        };
        public Skill Bartering { get; set; } = new Skill(Skill.Types.Bartering)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Perception { get; set; } = new Skill(Skill.Types.Perception)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Stealth { get; set; } = new Skill(Skill.Types.Stealth)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Immunity { get; set; } = new Skill(Skill.Types.Immunity)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Profession { get; set; } = new Skill(Skill.Types.Profession)
        {
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
            foreach (Attribute attribute in Attributes)
            {
                attribute.WarriorBonus = TimeWarriorBonus / 2;
            }

            foreach (Skill skill in Skills)
            {
                skill.SetAttributeBonus(Attributes);
            }
        }

        public virtual void CalculateAncillaryStats()
        {
            Profession.Base = AthleteBonus + TimeWarriorBonus;
        }

        public virtual int RaiseCost(Skill Skill, int NextLevel)
        {
            
            int nr = NextLevel - Skill.Start + 1 + 5;

            if (NextLevel < MaxNonPTMBase)
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

        public virtual int RaiseCost(Attribute Attribute, int NextLevel)
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

        public int GetPtmBonus()
        {
            int threshold = 225;
            int start = 152;
            int diff = 0;
            int nStats = 0;

            foreach (Skill skill in Skills)
            {
                if (skill.Type != Skill.Types.Hitpoints &&
                    skill.Type != Skill.Types.Endurance &&
                    skill.Type != Skill.Types.Mana &&
                    skill.Type != Skill.Types.Profession)
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
    }
}
