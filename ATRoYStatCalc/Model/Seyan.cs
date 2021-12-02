using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Toolkit.Mvvm.ComponentModel;
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
        public double ArmorValue { get; set; }
        public double ExtraArmorValue { get; set; }
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
        public Attribute Wisdom { get; set; } = new Attribute(Attribute.Types.Wisdom, true)
        {
            Start = 10,
            Base = 10,
            Cost = 2
        };
        public Attribute Intuition { get; set; } = new Attribute(Attribute.Types.Intuition, true)
        {
            Start = 10,
            Base = 10,
            Cost = 2
        };
        public Attribute Agility { get; set; } = new Attribute(Attribute.Types.Agility, true)
        {
            Start = 10,
            Base = 10,
            Cost = 2
        };
        public Attribute Strength { get; set; } = new Attribute(Attribute.Types.Strength, true)
        {
            Start = 10,
            Base = 10,
            Cost = 2
        };
        #endregion

        #region "Skills"
        [JsonIgnore]
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public Skill Hitpoints { get; set; } = new Skill(Skill.Types.Hitpoints, true)
        {
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Endurance { get; set; } = new Skill(Skill.Types.Endurance, true)
        {
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Mana { get; set; } = new Skill(Skill.Types.Mana, true)
        {
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Dagger { get; set; } = new Skill(Skill.Types.Dagger, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill HandToHand { get; set; } = new Skill(Skill.Types.HandtoHand, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Sword { get; set; } = new Skill(Skill.Types.Sword, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill TwoHanded { get; set; } = new Skill(Skill.Types.TwoHanded, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill ArmorSkill { get; set; } = new Skill(Skill.Types.ArmorSkill, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Attack { get; set; } = new Skill(Skill.Types.Attack, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Parry { get; set; } = new Skill(Skill.Types.Parry, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Warcry { get; set; } = new Skill(Skill.Types.Warcry, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Tactics { get; set; } = new Skill(Skill.Types.Tactics, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill SurroundHit { get; set; } = new Skill(Skill.Types.SurroundHit, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill BodyControl { get; set; } = new Skill(Skill.Types.BodyControl, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill SpeedSkill { get; set; } = new Skill(Skill.Types.SpeedSkill, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Regenerate { get; set; } = new Skill(Skill.Types.Regenerate, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Bless { get; set; } = new Skill(Skill.Types.Bless, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Heal { get; set; } = new Skill(Skill.Types.Heal, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Freeze { get; set; } = new Skill(Skill.Types.Freeze, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill MagicShield { get; set; } = new Skill(Skill.Types.MagicShield, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Lightning { get; set; } = new Skill(Skill.Types.Lightning, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Fire { get; set; } = new Skill(Skill.Types.Fire, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Pulse { get; set; } = new Skill(Skill.Types.Pulse, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Meditate { get; set; } = new Skill(Skill.Types.Meditate, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Bartering { get; set; } = new Skill(Skill.Types.Bartering, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Perception { get; set; } = new Skill(Skill.Types.Perception, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Stealth { get; set; } = new Skill(Skill.Types.Stealth, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Immunity { get; set; } = new Skill(Skill.Types.Immunity, true)
        {
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Profession { get; set; } = new Skill(Skill.Types.Profession, true)
        {
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

            foreach (var attribute in Attributes)
            {
                int attributeExp = 0;
                for (int i = attribute.Start; i < attribute.Base; i++)
                {
                    attributeExp += RaiseCost(attribute, i);
                }
                totalSpentExp += attributeExp;
            }

            foreach (var skill in Skills)
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
            foreach (var attribute in Attributes)
            {
                attribute.WarriorBonus = TimeWarriorBonus / 2;
                attribute.LevelBonus = levelBonus;
                attribute.BlessBonus = 0;
            }

            Tactics.LevelBonus = levelBonus;
            
            //Calculate bless mod from unblessed WIAS
            Bless.LevelBonus = levelBonus;
            Bless.PtmBonus = 0;
            Bless.SetAttributeBonus(Attributes, tacBonus);
            
            if (Blessed)
            {
                //Calculate attribute bonus from unblessed bless mod
                foreach (var attribute in Attributes)
                {
                    attribute.BlessBonus = (int)((Bless.Mod + (Tactics.Mod * 0.125)) / 4);
                }

                //Calculate bless mod from bless
                Bless.SetAttributeBonus(Attributes, tacBonus);
            }

            foreach (var skill in Skills)
            {
                skill.LevelBonus = levelBonus;

                if (skill.Type == Skill.Types.Attack ||
                    skill.Type == Skill.Types.Parry ||
                    skill.Type == Skill.Types.Warcry ||
                    skill.Type == Skill.Types.Freeze ||
                    skill.Type == Skill.Types.Lightning ||
                    skill.Type == Skill.Types.Fire)
                {
                    skill.SetAttributeBonus(Attributes, tacBonus);
                }
                else if (skill.Type == Skill.Types.Immunity)
                {
                    skill.SetAttributeBonus(Attributes, tacImmBonus);
                }
                else
                {
                    if (skill.Type == Skill.Types.Bless)
                    {
                        skill.SetAttributeBonus(Attributes, (int)(Tactics.Mod * 0.125));
                    }
                    else
                    {
                        skill.SetAttributeBonus(Attributes);
                    }
                }

                if (skill.Type != Skill.Types.Hitpoints &&
                    skill.Type != Skill.Types.Endurance &&
                    skill.Type != Skill.Types.Mana &&
                    skill.Type != Skill.Types.Profession)
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
            ArmorValue = ExtraArmorValue + (BodyControl.Mod + ArmorSkill.Mod) * 0.25;

            var weaponSkills = new List<Skill>()
            {
                Dagger,
                HandToHand,
                Sword,
                TwoHanded
            };

            int weaponSkillMod = weaponSkills.Max(s => s.Mod);

            //Tactics bonus to off/def is always included
            Offence = (Attack.Mod * 2) + weaponSkillMod + (int)Math.Floor(Tactics.Mod * 0.375);
            Defence = (Parry.Mod * 2) + weaponSkillMod + (int)Math.Floor(Tactics.Mod * 0.375);

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

        private int GetTacticsSkillBonus(bool IsImmunity = false)
        {
            return IncludeTactics
                ? IsImmunity
                    ? (int)Math.Floor(Tactics.Mod / 8.08)
                    : (int)Math.Floor((double)Tactics.Mod / 8)
                : 0;
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