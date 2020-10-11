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
        public int MaxBasePTM { get; set; } = 202;

        private bool _hardCore = false;
        public bool HardCore
        {
            get => _hardCore;
            set
            {
                _hardCore = value;
                RaisePropertyChanged("HardCore");
                RaisePropertyChanged("MaxBase");
            }
        }

        private bool _masterAthlete;
        public bool MasterAthlete
        {
            get => _masterAthlete;
            set
            {
                _masterAthlete = value;
                RaisePropertyChanged("MasterAthlete");
            }
        }

        private bool _masterWarrior;
        public bool MasterWarrior
        {
            get => _masterWarrior;
            set
            {
                _masterWarrior = value;
                RaisePropertyChanged("MasterWarrior");
            }
        }

        private int _currentExp = 0;
        public int CurrentExp
        {
            get => _currentExp;
            set
            {
                _currentExp = value;
                RaisePropertyChanged("CurrentExp");
            }
        }

        private int _currentLevel = 1;
        public int CurrentLevel
        {
            get => _currentLevel;
            set
            {
                _currentLevel = value;
                RaisePropertyChanged("CurrentLevel");
            }
        }

        private int _speed;
        public int Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                RaisePropertyChanged("Speed");
            }
        }

        public List<Skill> Skills { get; set; } = new List<Skill>();

        public Skill Hitpoints { get; set; } = new Skill()
        {
            DisplayName = "Hitpoints",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 3,
            EquipmentBonus = 0
        };
        public Skill Endurance { get; set; } = new Skill()
        {
            DisplayName = "Endurance",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 3,
            EquipmentBonus = 0
        };
        public Skill Mana { get; set; } = new Skill()
        {
            DisplayName = "Mana",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 3,
            EquipmentBonus = 0
        };

        public Skill Wisdom { get; set; } = new Skill()
        {
            DisplayName = "Wisdom",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Intuition { get; set; } = new Skill()
        {
            DisplayName = "Intuition",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Agility { get; set; } = new Skill()
        {
            DisplayName = "Agility",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Strength { get; set; } = new Skill()
        {
            DisplayName = "Strength",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };

        public Skill Dagger { get; set; } = new Skill()
        {
            DisplayName = "Dagger",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill HandToHand { get; set; } = new Skill()
        {
            DisplayName = "Hand to Hand",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };

        public Skill Bartering { get; set; } = new Skill()
        {
            DisplayName = "Bartering",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Perception { get; set; } = new Skill()
        {
            DisplayName = "Perception",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Stealth { get; set; } = new Skill()
        {
            DisplayName = "Stealth",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };

        public Skill Immunity { get; set; } = new Skill()
        {
            DisplayName = "Immunity",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };

        public Skill Profession { get; set; } = new Skill()
        {
            DisplayName = "Profession",
            Start = 1,
            Base = 1,
            Mod = 0,
            Cost = 3,
            EquipmentBonus = 0
        };

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

            Skills.Add(Profession);
        }

        public virtual void UpdateCharacter()
        {
            CalculateAttributes();
            CalculateStats();
            CalculateLevel();
        }

        public virtual void CalculateAttributes()
        {
            Wisdom.Mod = Wisdom.Base.MaxMagicalBonus(Wisdom.EquipmentBonus);
            Intuition.Mod = Intuition.Base.MaxMagicalBonus(Intuition.EquipmentBonus);
            Agility.Mod = Agility.Base.MaxMagicalBonus(Agility.EquipmentBonus);
            Strength.Mod = Strength.Base.MaxMagicalBonus(Strength.EquipmentBonus);
        }

        public virtual void CalculateStats()
        {
            //Armour
            //Weapon
            Hitpoints.Mod = Hitpoints.Base.MaxMagicalBonus(Hitpoints.EquipmentBonus);
            Endurance.Mod = Endurance.Base.MaxMagicalBonus(Endurance.EquipmentBonus);
            Mana.Mod = Mana.Base.MaxMagicalBonus(Endurance.EquipmentBonus);

            Dagger.Mod = Dagger.Base.MaxMagicalBonus(Dagger.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5); 
            HandToHand.Mod = HandToHand.Base.MaxMagicalBonus(HandToHand.EquipmentBonus) + ((Agility.Mod + Strength.Mod + Strength.Mod) / 5);

            Bartering.Mod = Bartering.Base.MaxMagicalBonus(Bartering.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Perception.Mod = Perception.Base.MaxMagicalBonus(Perception.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Stealth.Mod = Stealth.Base.MaxMagicalBonus(Stealth.EquipmentBonus) + ((Agility.Mod + Agility.Mod + Intuition.Mod) / 5);

            //Immunity was changed from Wis+Int+Str to Int+Int+Str
            Immunity.Mod = Immunity.Base.MaxMagicalBonus(Immunity.EquipmentBonus) + ((Intuition.Mod + Intuition.Mod + Strength.Mod) / 5);

            Profession.Mod = 0;
            if (MasterAthlete)
            {
                Profession.Mod += 30;
            }

            if (MasterWarrior)
            {
                Profession.Mod += 30;
            }    
        }

        public void CalculateLevel()
        {
            int totalSpentExp = 0;

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
            CurrentLevel = HelperFuncs.GetCurrentLevel(CurrentExp);
        }

        public virtual int RaiseCost(Skill Skill, int NextLevel)
        {
            if (NextLevel <= MaxBase)
            {
                int nr = NextLevel - Skill.Start + 1 + 5;
                return Math.Max(1, (nr * nr * nr * Skill.Cost) / 10);
            }
            else
            {
                int nr = NextLevel - Skill.Start + 1 + 5;
                int normalCost = Math.Max(1, (nr * nr * nr * Skill.Cost) / 10);

                int ptmCost;
                if (Skill.DisplayName == "Wisdom" ||
                    Skill.DisplayName == "Intuition" ||
                    Skill.DisplayName == "Agility" ||
                    Skill.DisplayName == "Strength")
                {
                    ptmCost = 6000000;
                }
                else
                {
                    ptmCost = 3000000;
                }

                return normalCost + ptmCost;
            }
            
        }
    }
}
