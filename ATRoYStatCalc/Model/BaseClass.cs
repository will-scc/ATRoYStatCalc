using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;

namespace ATRoYStatCalc.Model
{
    public class BaseClass : ObservableObject
    {
        public const long MaxExp = 1600000000;
        public bool MaxExpExceeded => CurrentExp > MaxExp;
        public int MaxBase => 230;
        public bool PvpChar { get; set; }
        public bool MissingProfessionBases => Profession.Base < Profession.Mod;

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
        private bool _masterLightWarrior;
        public bool MasterLightWarrior
        {
            get => _masterLightWarrior;
            set
            {
                _masterLightWarrior = value;
                RaisePropertyChanged("MasterLightWarrior");
            }
        }
        private bool _masterDarkWarrior;
        public bool MasterDarkWarrior
        {
            get => _masterDarkWarrior;
            set
            {
                _masterDarkWarrior = value;
                RaisePropertyChanged("MasterDarkWarrior");
            }
        }
        private long _currentExp = 0;
        public long CurrentExp
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
        public Skill Hitpoints { get; set; } = new Skill(false)
        {
            DisplayName = "Hitpoints",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 3,
            EquipmentBonus = 0
        };
        public Skill Endurance { get; set; } = new Skill(false)
        {
            DisplayName = "Endurance",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 3,
            EquipmentBonus = 0
        };
        public Skill Wisdom { get; set; } = new Skill(false)
        {
            DisplayName = "Wisdom",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Intuition { get; set; } = new Skill(false)
        {
            DisplayName = "Intuition",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Agility { get; set; } = new Skill(false)
        {
            DisplayName = "Agility",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Strength { get; set; } = new Skill(false)
        {
            DisplayName = "Strength",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Dagger { get; set; } = new Skill(false)
        {
            DisplayName = "Dagger",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill HandToHand { get; set; } = new Skill(false)
        {
            DisplayName = "Hand to Hand",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Bartering { get; set; } = new Skill(false)
        {
            DisplayName = "Bartering",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Perception { get; set; } = new Skill(false)
        {
            DisplayName = "Perception",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Stealth { get; set; } = new Skill(false)
        {
            DisplayName = "Stealth",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Immunity { get; set; } = new Skill(false)
        {
            DisplayName = "Immunity",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Profession { get; set; } = new Skill(false)
        {
            DisplayName = "Profession",
            Start = 1,
            Base = 1,
            Mod = 0,
            Cost = 3,
            EquipmentBonus = 0
        };
        public List<Skill> Skills { get; set; } = new List<Skill>();

        public BaseClass()
        {
            Skills.Add(Hitpoints);
            Skills.Add(Endurance);
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
            Wisdom.Mod = Wisdom.Base + MaxMagicalBonus(Wisdom);
            Intuition.Mod = Intuition.Base + MaxMagicalBonus(Intuition);
            Agility.Mod = Agility.Base + MaxMagicalBonus(Agility);
            Strength.Mod = Strength.Base + MaxMagicalBonus(Strength);
        }

        public virtual void CalculateStats()
        {
            Hitpoints.Mod = Hitpoints.Base + MaxMagicalBonus(Hitpoints);
            Endurance.Mod = Endurance.Base + MaxMagicalBonus(Endurance);

            Dagger.Mod = Dagger.Base + MaxMagicalBonus(Dagger) + MaxAttributeBonus(Dagger, ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5));
            HandToHand.Mod = HandToHand.Base + MaxMagicalBonus(HandToHand) + MaxAttributeBonus(HandToHand, (Agility.Mod + Strength.Mod + Strength.Mod) / 5);

            Bartering.Mod = Bartering.Base + MaxMagicalBonus(Bartering) + MaxAttributeBonus(Bartering, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Perception.Mod = Perception.Base + MaxMagicalBonus(Perception) + MaxAttributeBonus(Perception, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Stealth.Mod = Stealth.Base + MaxMagicalBonus(Stealth) + MaxAttributeBonus(Stealth, (Agility.Mod + Agility.Mod + Intuition.Mod) / 5);
            Immunity.Mod = Immunity.Base + MaxMagicalBonus(Immunity) + MaxAttributeBonus(Immunity, (Intuition.Mod + Intuition.Mod + Strength.Mod) / 5);

            Profession.Mod = 0;
            if (MasterAthlete)
            {
                Profession.Mod += 30;
            }

            if (MasterLightWarrior)
            {
                Profession.Mod += 30;
            }

            if (MasterDarkWarrior)
            {
                Profession.Mod += 30;
            }

            RaisePropertyChanged("MissingProfessionBases");
            RaisePropertyChanged("MaxExpExceeded");
        }

        public void CalculateLevel()
        {
            long totalSpentExp = 0;

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

        public int RaiseCost(Skill Skill, int NextLevel)
        {
            int maxNonPTMBase = HardCore ? 120 : 100;
            int nr = NextLevel - Skill.Start + 1 + 5;

            if (NextLevel < maxNonPTMBase)
            {
                return Math.Max(1, nr * nr * nr * Skill.Cost / 10);
            }
            else
            {
                int normalCost = Math.Max(1, nr * nr * nr * Skill.Cost / 10);

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

        public virtual int MaxMagicalBonus(Skill Skill)
        {
            int maxMod = Skill.DisplayName.In("Wisdom", "Intuition", "Agility", "Strength") ? Skill.Base : Skill.Base * 2;
            return PvpChar ? maxMod : Math.Min(Skill.EquipmentBonus, maxMod);
        }

        public int MaxAttributeBonus(Skill Skill, int AttributeBonus)
        {
            int maxMod = Skill.Base * 2;
            return Math.Min(maxMod, Math.Max(15, AttributeBonus));
        }
    }
}
