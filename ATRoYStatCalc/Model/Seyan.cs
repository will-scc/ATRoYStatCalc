using System;

namespace ATRoYStatCalc.Model
{
    public class Seyan : BaseClass
    {
        private bool BlessActive = true;

        public Skill Mana { get; set; } = new Skill()
        {
            DisplayName = "Mana",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 3,
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

        public Seyan()
        {
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
            Skills.Add(Mana);
            Skills.Add(Bless);
            Skills.Add(Heal);
            Skills.Add(Freeze);
            Skills.Add(MagicShield);
            Skills.Add(Lightning);
            Skills.Add(Fire);
            Skills.Add(Pulse);
            Skills.Add(Meditate);
        }

        public override void UpdateCharacter()
        {
            BlessActive = false;

            CalculateAttributes();
            CalculateBlessMod();

            BlessActive = true;

            CalculateAttributes();
            CalculateStats();
            CalculateLevel();
        }

        private void CalculateBlessMod()
        {
            Bless.Mod = Bless.Base.MaxMagicalBonus(Bless.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
        }

        public override void CalculateAttributes()
        {
            //blessValue is ignored when Bless isn't active (non-blessed WIAS is used to calculate Bless Mod)
            int blessValue = BlessActive ? Bless.Mod / 4 : 0;

            Wisdom.Mod = Wisdom.Base.MaxMagicalBonus(Wisdom.EquipmentBonus + blessValue);
            Intuition.Mod = Intuition.Base.MaxMagicalBonus(Intuition.EquipmentBonus + blessValue);
            Agility.Mod = Agility.Base.MaxMagicalBonus(Agility.EquipmentBonus + blessValue);
            Strength.Mod = Strength.Base.MaxMagicalBonus(Strength.EquipmentBonus + blessValue);
        }

        public override void CalculateStats()
        {
            //Calculate all the shared stats first
            base.CalculateStats();

            Sword.Mod = Sword.Base.MaxMagicalBonus(Sword.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            TwoHanded.Mod = TwoHanded.Base.MaxMagicalBonus(TwoHanded.EquipmentBonus) + ((Agility.Mod + Agility.Mod + Strength.Mod) / 5);
            BodyControl.Mod = BodyControl.Base.MaxMagicalBonus(BodyControl.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            ArmorSkill.Mod = ArmorSkill.Base.MaxMagicalBonus(ArmorSkill.EquipmentBonus) + ((Agility.Mod + Agility.Mod + Strength.Mod) / 5);
            Attack.Mod = Attack.Base.MaxMagicalBonus(Attack.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            Parry.Mod = Parry.Base.MaxMagicalBonus(Parry.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            Warcry.Mod = Warcry.Base.MaxMagicalBonus(Warcry.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            Tactics.Mod = Tactics.Base.MaxMagicalBonus(Tactics.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            SurroundHit.Mod = SurroundHit.Base.MaxMagicalBonus(SurroundHit.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            SpeedSkill.Mod = SpeedSkill.Base.MaxMagicalBonus(SpeedSkill.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            Mana.Mod = Mana.Base.MaxMagicalBonus(Mana.EquipmentBonus);
            Heal.Mod = Heal.Base.MaxMagicalBonus(Heal.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Freeze.Mod = Freeze.Base.MaxMagicalBonus(Freeze.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            MagicShield.Mod = MagicShield.Base.MaxMagicalBonus(MagicShield.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Lightning.Mod = Lightning.Base.MaxMagicalBonus(Lightning.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Fire.Mod = Fire.Base.MaxMagicalBonus(Fire.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Pulse.Mod = Pulse.Base.MaxMagicalBonus(Pulse.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Meditate.Mod = Meditate.Base.MaxMagicalBonus(Meditate.EquipmentBonus) + ((Wisdom.Mod + Wisdom.Mod + Wisdom.Mod) / 5);

            Speed = MasterAthlete
                ? (SpeedSkill.Mod / 2) + ((Agility.Mod + Agility.Mod + Strength.Mod) / 5) + (30 * 3)
                : (SpeedSkill.Mod / 2) + ((Agility.Mod + Agility.Mod + Strength.Mod) / 5);
        }

        public override int RaiseCost(Skill Skill, int NextLevel)
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
    }
}
