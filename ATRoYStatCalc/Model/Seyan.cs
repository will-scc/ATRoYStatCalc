using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;

namespace ATRoYStatCalc.Model
{
    public class Seyan : ObservableObject
    {
        public const long MaxExp = 1600000000;
        public bool MaxExpExceeded => CurrentExp > MaxExp;
        public int MaxBase => 202;
        public bool PvpChar { get; set; }
        public bool MissingProfessionBases => Profession.Base < Profession.Mod;
        
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

        public Skill Hitpoints { get; set; } = new Skill(true)
        {
            DisplayName = "Hitpoints",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 3,
            EquipmentBonus = 0
        };
        public Skill Endurance { get; set; } = new Skill(true)
        {
            DisplayName = "Endurance",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 3,
            EquipmentBonus = 0
        };
        public Skill Mana { get; set; } = new Skill(true)
        {
            DisplayName = "Mana",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 3,
            EquipmentBonus = 0
        };
        public Skill Wisdom { get; set; } = new Skill(true)
        {
            DisplayName = "Wisdom",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Intuition { get; set; } = new Skill(true)
        {
            DisplayName = "Intuition",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Agility { get; set; } = new Skill(true)
        {
            DisplayName = "Agility",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Strength { get; set; } = new Skill(true)
        {
            DisplayName = "Strength",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 2,
            EquipmentBonus = 0
        };
        public Skill Dagger { get; set; } = new Skill(true)
        {
            DisplayName = "Dagger",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill HandToHand { get; set; } = new Skill(true)
        {
            DisplayName = "Hand to Hand",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
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
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Heal { get; set; } = new Skill(true)
        {
            DisplayName = "Heal",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Freeze { get; set; } = new Skill(true)
        {
            DisplayName = "Freeze",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill MagicShield { get; set; } = new Skill(true)
        {
            DisplayName = "Magic Shield",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Lightning { get; set; } = new Skill(true)
        {
            DisplayName = "Lightning",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Fire { get; set; } = new Skill(true)
        {
            DisplayName = "Fire",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Pulse { get; set; } = new Skill(true)
        {
            DisplayName = "Pulse",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Meditate { get; set; } = new Skill(true)
        {
            DisplayName = "Meditate",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Bartering { get; set; } = new Skill(true)
        {
            DisplayName = "Bartering",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Perception { get; set; } = new Skill(true)
        {
            DisplayName = "Perception",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Stealth { get; set; } = new Skill(true)
        {
            DisplayName = "Stealth",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Immunity { get; set; } = new Skill(true)
        {
            DisplayName = "Immunity",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Profession { get; set; } = new Skill(true)
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
            //Unblessed WIAS is used to calculate Bless Mod)
            BlessActive = false;

            CalculateBlessMod();
            CalculateAttributes();

            BlessActive = true;

            CalculateAttributes();
            CalculateStats();
            CalculateLevel();
        }

        private void CalculateBlessMod()
        {
            Bless.Mod = Bless.Base + MaxMagicalBonus(Bless) + MaxAttributeBonus(Bless, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
        }

        private void CalculateAttributes()
        {
            int blessValue = BlessActive ? Bless.Mod / 4 : 0;

            Wisdom.Mod = (Wisdom.Base == 40 || Wisdom.Base == 80 ? Wisdom.Base - 1 : Wisdom.Base) + MaxMagicalBonus(Wisdom) + blessValue;
            Intuition.Mod = (Intuition.Base == 40 || Intuition.Base == 80 ? Intuition.Base - 1 : Intuition.Base) + MaxMagicalBonus(Intuition) + blessValue;
            Agility.Mod = (Agility.Base == 40 || Agility.Base == 80 ? Agility.Base - 1 : Agility.Base) + MaxMagicalBonus(Agility) + blessValue;
            Strength.Mod = (Strength.Base == 40 || Strength.Base == 80 ? Strength.Base - 1 : Strength.Base) + MaxMagicalBonus(Strength) + blessValue;
        }

        private void CalculateStats()
        {
            //ideally each skill could be done in a parallelforeach
            //but would need dictionary(?) of attributes used for each skill
            //how would skill know attributes for the character?
            //could pass WIAS but only use if required

            Hitpoints.Mod = Hitpoints.Base + MaxMagicalBonus(Hitpoints);
            Endurance.Mod = Endurance.Base + MaxMagicalBonus(Endurance);
            Mana.Mod = Mana.Base + MaxMagicalBonus(Mana);

            Dagger.Mod = Dagger.Base + MaxMagicalBonus(Dagger) + MaxAttributeBonus(Dagger, ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5));
            HandToHand.Mod = HandToHand.Base + MaxMagicalBonus(HandToHand) + MaxAttributeBonus(HandToHand, (Agility.Mod + Strength.Mod + Strength.Mod) / 5);
            Sword.Mod = Sword.Base + MaxMagicalBonus(Sword) + MaxAttributeBonus(Sword, (Intuition.Mod + Intuition.Mod + Agility.Mod) / 5);
            TwoHanded.Mod = TwoHanded.Base + MaxMagicalBonus(TwoHanded) + MaxAttributeBonus(TwoHanded, (Agility.Mod + Agility.Mod + Strength.Mod) / 5);
            
            ArmorSkill.Mod = ArmorSkill.Base + MaxMagicalBonus(ArmorSkill) + MaxAttributeBonus(ArmorSkill, (Agility.Mod + Agility.Mod + Strength.Mod) / 5);
            Attack.Mod = Attack.Base + MaxMagicalBonus(Attack) + MaxAttributeBonus(Attack, (Intuition.Mod + Intuition.Mod + Agility.Mod) / 5);
            Parry.Mod = Parry.Base + MaxMagicalBonus(Parry) + MaxAttributeBonus(Parry, (Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            Warcry.Mod = Warcry.Base + MaxMagicalBonus(Warcry) + MaxAttributeBonus(Warcry, (Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            Tactics.Mod = Tactics.Base + MaxMagicalBonus(Tactics) + MaxAttributeBonus(Tactics, (Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            SurroundHit.Mod = SurroundHit.Base + MaxMagicalBonus(SurroundHit) + MaxAttributeBonus(SurroundHit, (Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            BodyControl.Mod = BodyControl.Base + MaxMagicalBonus(BodyControl) + MaxAttributeBonus(BodyControl, (Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            SpeedSkill.Mod = SpeedSkill.Base + MaxMagicalBonus(SpeedSkill) + MaxAttributeBonus(SpeedSkill, (Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            
            Heal.Mod = Heal.Base + MaxMagicalBonus(Heal) + MaxAttributeBonus(Heal, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Freeze.Mod = Freeze.Base + MaxMagicalBonus(Freeze) + MaxAttributeBonus(Freeze, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            MagicShield.Mod = MagicShield.Base + MaxMagicalBonus(MagicShield) + MaxAttributeBonus(MagicShield, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Lightning.Mod = Lightning.Base + MaxMagicalBonus(Lightning) + MaxAttributeBonus(Lightning, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Fire.Mod = Fire.Base + MaxMagicalBonus(Fire) + MaxAttributeBonus(Fire, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Pulse.Mod = Pulse.Base + MaxMagicalBonus(Pulse) + MaxAttributeBonus(Pulse, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);

            Bartering.Mod = Bartering.Base + MaxMagicalBonus(Bartering) + MaxAttributeBonus(Bartering, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Perception.Mod = Perception.Base + MaxMagicalBonus(Perception) + MaxAttributeBonus(Perception, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Stealth.Mod = Stealth.Base + MaxMagicalBonus(Stealth) + MaxAttributeBonus(Stealth, (Agility.Mod + Agility.Mod + Intuition.Mod) / 5);
            Regenerate.Mod = Regenerate.Base + MaxMagicalBonus(Regenerate) + MaxAttributeBonus(Regenerate, (Wisdom.Mod + Wisdom.Mod + Wisdom.Mod) / 5);
            Meditate.Mod = Meditate.Base + MaxMagicalBonus(Meditate) + MaxAttributeBonus(Meditate, (Wisdom.Mod + Wisdom.Mod + Wisdom.Mod) / 5);
            Immunity.Mod = Immunity.Base + MaxMagicalBonus(Immunity) + MaxAttributeBonus(Immunity, (Intuition.Mod + Intuition.Mod + Strength.Mod) / 5);

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
            int maxNonPTMBase = HardCore ? 107 : 100;
            int nr = NextLevel - Skill.Start + 1 + 5;

            if (NextLevel < maxNonPTMBase)
            {
                return Math.Max(1, (nr * nr * nr * Skill.Cost * 4) / 30);
            }
            else
            {
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
            return PvpChar ? maxMod : Math.Min(skill.EquipmentBonus, maxMod);
        }

        public int MaxAttributeBonus(Skill Skill, int AttributeBonus)
        {
            int maxMod = Skill.Base * 2;
            return Math.Min(maxMod, Math.Max(15, AttributeBonus));
        }
    }
}
