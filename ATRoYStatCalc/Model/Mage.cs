namespace ATRoYStatCalc.Model
{
    public class Mage : BaseClass
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
        public Skill Staff { get; set; } = new Skill()
        {
            DisplayName = "Staff",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
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
        public Skill Duration { get; set; } = new Skill()
        {
            DisplayName = "Duration",
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

        public Mage()
        {
            Skills.Add(Mana);
            Skills.Add(Staff);
            Skills.Add(Bless);
            Skills.Add(Heal);
            Skills.Add(Freeze);
            Skills.Add(MagicShield);
            Skills.Add(Lightning);
            Skills.Add(Fire);
            Skills.Add(Pulse);
            Skills.Add(Duration);
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

            //Calculate Mage-specific stats
            Mana.Mod = Mana.Base.MaxMagicalBonus(Mana.EquipmentBonus);
            Staff.Mod = Staff.Base.MaxMagicalBonus(Staff.EquipmentBonus) + ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5);
            Heal.Mod = Heal.Base.MaxMagicalBonus(Heal.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Freeze.Mod = Freeze.Base.MaxMagicalBonus(Freeze.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            MagicShield.Mod = MagicShield.Base.MaxMagicalBonus(MagicShield.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Lightning.Mod = Lightning.Base.MaxMagicalBonus(Lightning.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Fire.Mod = Fire.Base.MaxMagicalBonus(Fire.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Pulse.Mod = Pulse.Base.MaxMagicalBonus(Pulse.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Duration.Mod = Duration.Base.MaxMagicalBonus(Duration.EquipmentBonus) + ((Wisdom.Mod + Intuition.Mod + Strength.Mod) / 5);
            Meditate.Mod = Meditate.Base.MaxMagicalBonus(Meditate.EquipmentBonus) + ((Wisdom.Mod + Wisdom.Mod + Wisdom.Mod) / 5);

            if (MasterAthlete)
            {
                Speed = ((Agility.Mod + Agility.Mod + Strength.Mod) / 5) + (30 * 3);
            }
            else
            {
                Speed = ((Agility.Mod + Agility.Mod + Strength.Mod) / 5);
            }
        }
    }
}
