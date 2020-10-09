using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ATRoYStatCalc.Model
{
    public class BaseClass : ObservableObject
    {
        public const int MaxExp = 1600000000;
        public int MaxBase => HardCore ? 107 : 100;

        public bool HardCore { get; set; } = false;

        public List<Skill> Skills { get; set; } = new List<Skill>();

        public Skill Hitpoints { get; set; } = new Skill()
        {
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 3,
            EquipmentBonus = 0
        };
        public Skill Endurance { get; set; } = new Skill()
        {
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 3,
            EquipmentBonus = 0
        };
        public Skill Mana { get; set; } = new Skill()
        {
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 3,
            EquipmentBonus = 0
        };

        public Skill Wisdom { get; set; } = new Skill()
        {
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Intuition { get; set; } = new Skill()
        {
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Agility { get; set; } = new Skill()
        {
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Strength { get; set; } = new Skill()
        {
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };

        public Skill Dagger { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill HandToHand { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };

        public Skill Bartering { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Perception { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Stealth { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Regenerate { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Meditate { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Immunity { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };

        //public Skill Profession { get; set; } = new Skill()
        //{
        //    Start = 1,
        //    Base = 1,
        //    Mod = 0,
        //    Cost = 3,
        //    EquipmentBonus = 0
        //};

        public BaseClass()
        {
            Skills.Add(Hitpoints);
            Skills.Add(Endurance);
            Skills.Add(Mana);

            Skills.Add(Wisdom);
            Skills.Add(Intuition);
            Skills.Add(Agility);
            Skills.Add(Strength);

            Skills.Add(Dagger);
            Skills.Add(HandToHand);
            
            Skills.Add(Bartering);
            Skills.Add(Perception);
            Skills.Add(Stealth);
            
            Skills.Add(Immunity);

            //Skills.Add(Profession);
        }

        public virtual void UpdateCharacter()
        {
            CalculateAttributes();
            CalculateStats();
        }

        public virtual void CalculateAttributes()
        {
            Wisdom.Mod = Wisdom.Base.MaxBonus(Wisdom.EquipmentBonus);
            Intuition.Mod = Intuition.Base.MaxBonus(Intuition.EquipmentBonus);
            Agility.Mod = Agility.Base.MaxBonus(Agility.EquipmentBonus);
            Strength.Mod = Strength.Base.MaxBonus(Strength.EquipmentBonus);
        }

        public virtual void CalculateStats()
        {
            Hitpoints.Mod = Hitpoints.Base + Hitpoints.EquipmentBonus;
            Endurance.Mod = Endurance.Base + Endurance.EquipmentBonus;
            Mana.Mod = Mana.Base + Mana.EquipmentBonus;

            Dagger.Mod = Dagger.Base.MaxBonus(Dagger.EquipmentBonus + (Agility.Mod + Intuition.Mod + Strength.Mod / 5));
            HandToHand.Mod = HandToHand.Base.MaxBonus(HandToHand.EquipmentBonus + (Agility.Mod + Strength.Mod + Strength.Mod / 5));

            Bartering.Mod = Bartering.Base.MaxBonus(Bartering.EquipmentBonus + (Wisdom.Mod + Intuition.Mod + Intuition.Mod / 5));
            Perception.Mod = Perception.Base.MaxBonus(Perception.EquipmentBonus + (Wisdom.Mod + Intuition.Mod + Intuition.Mod / 5));
            Stealth.Mod = Stealth.Base.MaxBonus(Stealth.EquipmentBonus + (Agility.Mod + Agility.Mod + Intuition.Mod / 5));

            Immunity.Mod = Immunity.Base.MaxBonus(Immunity.EquipmentBonus + (Wisdom.Mod + Intuition.Mod + Strength.Mod / 5));
        }

        public virtual int RaiseCost(Skill skill, int nextLevel)
        {
            int nr = nextLevel - skill.Start + 1 + 5;
            return Math.Max(1, nr * 3 * skill.Cost / 10);
        }
    }
}
