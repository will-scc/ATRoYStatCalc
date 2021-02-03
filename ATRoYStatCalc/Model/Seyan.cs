using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;

namespace ATRoYStatCalc.Model
{
    public class Seyan : ObservableObject
    {
        public const long MaxExp = 1600000000;
        public string CharacterName { get; set; } = "Unnamed Character";
        public bool MaxExpExceeded => CurrentExp > MaxExp;
        public int MaxBase => 202;
        public bool HardCore { get; set; } = false;
        public bool MasterAthlete { get; set; }
        public bool MasterWarrior { get; set; }
        public long CurrentExp { get; set; }
        public int CurrentLevel { get; set; } = 2;
        public int Speed { get; set; }
        
        public bool MissingProfessionBases => Profession.Base < Profession.Mod;

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

        public List<Skill> Skills { get; set; } = new List<Skill>();
        public Skill Hitpoints { get; set; } = new Skill(true)
        {
            DisplayName = "Hitpoints",
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Endurance { get; set; } = new Skill(true)
        {
            DisplayName = "Endurance",
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Mana { get; set; } = new Skill(true)
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

        public Seyan(bool initialize = false)
        {
            //when deserializing from json the list already gets created with these skills
            //so need to add only if not existing
            if (initialize)
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
        }

        public void UpdateCharacter()
        {
            CalculateLevel();
            CalculateAttributeBonuses();
        }

        private void CalculateAttributeBonuses()
        {
            //Unblessed attributes (WIAS) used to calculate bless mod
            foreach (Attribute attribute in Attributes)
            {
                attribute.BlessBonus = 0;
            }
            
            Bless.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;

            //Now apply bless mod to attributes for Skills
            foreach (Attribute attribute in Attributes)
            {
                attribute.BlessBonus = Bless.Mod / 4;
            }

            Dagger.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            HandToHand.AttributeBonus = (Agility.Mod + Strength.Mod + Strength.Mod) / 5;
            Sword.AttributeBonus = (Intuition.Mod + Intuition.Mod + Agility.Mod) / 5;
            TwoHanded.AttributeBonus = (Agility.Mod + Agility.Mod + Strength.Mod) / 5;
            
            ArmorSkill.AttributeBonus = (Agility.Mod + Agility.Mod + Strength.Mod) / 5;
            Attack.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            Parry.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            Warcry.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            Tactics.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            SurroundHit.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            BodyControl.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            SpeedSkill.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;

            Bless.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Heal.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Freeze.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            MagicShield.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Lightning.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Fire.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Pulse.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;

            Bartering.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Perception.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Stealth.AttributeBonus = (Agility.Mod + Agility.Mod + Intuition.Mod) / 5;
            Regenerate.AttributeBonus = (Wisdom.Mod + Wisdom.Mod + Wisdom.Mod) / 5;
            Meditate.AttributeBonus = (Wisdom.Mod + Wisdom.Mod + Wisdom.Mod) / 5;
            Immunity.AttributeBonus = (Intuition.Mod + Intuition.Mod + Strength.Mod) / 5;

            if (MasterAthlete)
            {
                Profession.EquipmentBonus += 30;
            }

            if (MasterWarrior)
            {
                Profession.EquipmentBonus += 30;
            }
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

        private int RaiseCost(Attribute Attribute, int NextLevel)
        {
            int maxNonPTMBase = HardCore ? 107 : 100;
            int nr = NextLevel - Attribute.Start + 1 + 5;

            if (NextLevel < maxNonPTMBase)
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