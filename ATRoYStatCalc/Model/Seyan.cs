using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;

namespace ATRoYStatCalc.Model
{
    public class Seyan : ObservableObject
    {
        public const long MaxExp = 1600000000;
        public bool MaxExpExceeded => CurrentExp > MaxExp;
        public bool MissingProfessionBases => Profession.Base < Profession.Mod;
        public int MaxBase => 202;
        
        private bool BlessActive = true;
        
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
        public Skill Sword { get; set; } = new Skill
        {
            DisplayName = "Sword",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill TwoHanded { get; set; } = new Skill
        {
            DisplayName = "TwoHanded",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill ArmorSkill { get; set; } = new Skill
        {
            DisplayName = "Armor Skill",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Attack { get; set; } = new Skill
        {
            DisplayName = "Attack",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Parry { get; set; } = new Skill
        {
            DisplayName = "Parry",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Warcry { get; set; } = new Skill
        {
            DisplayName = "Warcry",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Tactics { get; set; } = new Skill
        {
            DisplayName = "Tactics",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill SurroundHit { get; set; } = new Skill
        {
            DisplayName = "Surround Hit",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill BodyControl { get; set; } = new Skill
        {
            DisplayName = "Body Control",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill SpeedSkill { get; set; } = new Skill
        {
            DisplayName = "Speed Skill",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Regenerate { get; set; } = new Skill
        {
            DisplayName = "Regenerate",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Bless { get; set; } = new Skill()
        {
            DisplayName = "Bless",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Heal { get; set; } = new Skill()
        {
            DisplayName = "Heal",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Freeze { get; set; } = new Skill()
        {
            DisplayName = "Freeze",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill MagicShield { get; set; } = new Skill()
        {
            DisplayName = "Magic Shield",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Lightning { get; set; } = new Skill()
        {
            DisplayName = "Lightning",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Fire { get; set; } = new Skill()
        {
            DisplayName = "Fire",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Pulse { get; set; } = new Skill()
        {
            DisplayName = "Pulse",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Meditate { get; set; } = new Skill()
        {
            DisplayName = "Meditate",
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
        public List<Skill> Skills { get; set; } = new List<Skill>();

        public Seyan()
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
            Skills.Add(Sword);
            Skills.Add(TwoHanded);
            Skills.Add(ArmorSkill);
            Skills.Add(Attack);
            Skills.Add(Parry);
            Skills.Add(Warcry);
            Skills.Add(Tactics);
            Skills.Add(SurroundHit);
            Skills.Add(BodyControl);
            Skills.Add(SpeedSkill);
            Skills.Add(Regenerate);
            Skills.Add(Bless);
            Skills.Add(Heal);
            Skills.Add(Freeze);
            Skills.Add(MagicShield);
            Skills.Add(Lightning);
            Skills.Add(Fire);
            Skills.Add(Pulse);
            Skills.Add(Meditate);
            Skills.Add(Bartering);
            Skills.Add(Perception);
            Skills.Add(Stealth);
            Skills.Add(Immunity);
            Skills.Add(Profession);
        }

        public void UpdateCharacter()
        {
            CalculateLevel();

            BlessActive = false;

            CalculateAttributes();
            CalculateBlessMod();

            BlessActive = true;

            CalculateAttributes();
            CalculateStats();
            
        }

        private void CalculateBlessMod()
        {
            Bless.Mod = Bless.Base + MaxMagicalBonus(Bless) + MaxAttributeBonus(Bless, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
        }

        private void CalculateAttributes()
        {
            //blessValue is ignored when Bless isn't active (non-blessed WIAS is used to calculate Bless Mod)
            int blessValue = BlessActive ? Bless.Mod / 4 : 0;

            //Wisdom.Mod = Wisdom.Base.MaxMagicalBonus(Wisdom.EquipmentBonus + blessValue);
            Wisdom.Mod = Wisdom.Base + MaxMagicalBonus(Wisdom) + blessValue;
            Intuition.Mod = Intuition.Base + MaxMagicalBonus(Intuition) + blessValue;
            Agility.Mod = Agility.Base + MaxMagicalBonus(Agility) + blessValue;
            Strength.Mod = Strength.Base + MaxMagicalBonus(Strength) + blessValue;
        }

        private void CalculateStats()
        {
            Hitpoints.Mod = Hitpoints.Base + MaxMagicalBonus(Hitpoints);
            Endurance.Mod = Endurance.Base + MaxMagicalBonus(Endurance);
            Mana.Mod = Mana.Base + MaxMagicalBonus(Mana);

            Sword.Mod = Sword.Base + MaxMagicalBonus(Sword) + MaxAttributeBonus(Sword, ((Intuition.Mod + Intuition.Mod + Agility.Mod) / 5));
            
            
            
            Attack.Mod = Attack.Base + MaxMagicalBonus(Attack) + MaxAttributeBonus(Attack, ((Intuition.Mod + Intuition.Mod + Agility.Mod) / 5));
            //change these:

            //TwoHanded.Mod = TwoHanded.Base.MaxMagicalBonus(TwoHanded.EquipmentBonus) + ((Agility.Mod + Agility.Mod + Strength.Mod) / 5);
            //BodyControl.Mod = BodyControl.Base.MaxMagicalBonus(BodyControl.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            //ArmorSkill.Mod = ArmorSkill.Base.MaxMagicalBonus(ArmorSkill.EquipmentBonus) + ((Agility.Mod + Agility.Mod + Strength.Mod) / 5);
            //Attack.Mod = Attack.Base.MaxMagicalBonus(Attack.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            //Parry.Mod = Parry.Base.MaxMagicalBonus(Parry.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            //Warcry.Mod = Warcry.Base.MaxMagicalBonus(Warcry.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            //Tactics.Mod = Tactics.Base.MaxMagicalBonus(Tactics.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Strength.Mod) / 5);
            //SurroundHit.Mod = SurroundHit.Base.MaxMagicalBonus(SurroundHit.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            //SpeedSkill.Mod = SpeedSkill.Base.MaxMagicalBonus(SpeedSkill.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            //Heal.Mod = Heal.Base.MaxMagicalBonus(Heal.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            //Freeze.Mod = Freeze.Base.MaxMagicalBonus(Freeze.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            //MagicShield.Mod = MagicShield.Base.MaxMagicalBonus(MagicShield.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            //Lightning.Mod = Lightning.Base.MaxMagicalBonus(Lightning.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            //Fire.Mod = Fire.Base.MaxMagicalBonus(Fire.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            //Pulse.Mod = Pulse.Base.MaxMagicalBonus(Pulse.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            //Meditate.Mod = Meditate.Base.MaxMagicalBonus(Meditate.EquipmentBonus) + ((Wisdom.Mod + Wisdom.Mod + Wisdom.Mod) / 5);
            //Dagger.Mod = Dagger.Base + MaxMagicalBonus(Dagger) + MaxAttributeBonus(Dagger, ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5));

            //HandToHand.Mod = HandToHand.Base + MaxMagicalBonus(HandToHand) + ((Agility.Mod + Strength.Mod + Strength.Mod) / 5);
            //Bartering.Mod = Bartering.Base.MaxMagicalBonus(Bartering.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            //Perception.Mod = Perception.Base.MaxMagicalBonus(Perception.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            //Stealth.Mod = Stealth.Base.MaxMagicalBonus(Stealth.EquipmentBonus) + ((Agility.Mod + Agility.Mod + Intuition.Mod) / 5);
            //Immunity.Mod = Immunity.Base.MaxMagicalBonus(Immunity.EquipmentBonus) + ((Intuition.Mod + Intuition.Mod + Strength.Mod) / 5);

            Speed = MasterAthlete
                ? (SpeedSkill.Mod / 2) + ((Agility.Mod + Agility.Mod + Strength.Mod) / 5) + (30 * 3)
                : (SpeedSkill.Mod / 2) + ((Agility.Mod + Agility.Mod + Strength.Mod) / 5);

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

        private void CalculateLevel()
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

        private int RaiseCost(Skill Skill, int NextLevel)
        {
            //Seyan has slightly different skill costs
            int maxNonPTMBase = HardCore ? 107 : 100;

            if (NextLevel <= maxNonPTMBase)
            {
                int nr = NextLevel - Skill.Start + 1 + 5;
                return Math.Max(1, (nr * nr * nr * Skill.Cost * 4) / 30);
            }
            else
            {
                int nr = NextLevel - Skill.Start + 1 + 5;
                int normalCost = Math.Max(1, (nr * nr * nr * Skill.Cost * 4) / 30);

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

        private int MaxMagicalBonus(Skill skill)
        {
            int maxMod = (int)Math.Floor(((double)skill.Base / 100) * 72.5);
            return Math.Min(skill.EquipmentBonus, maxMod);
        }

        public int MaxAttributeBonus(Skill Skill, int AttributeBonus)
        {
            int maxMod = Skill.Base * 2;
            return Math.Min(maxMod, Math.Max(15, AttributeBonus));
        }

       
    }
}
