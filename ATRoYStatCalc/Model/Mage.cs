namespace ATRoYStatCalc.Model
{
    public class Mage : BaseClass
    {
        private bool BlessActive = true;
        
        public Skill Mana { get; set; } = new Skill(false)
        {
            DisplayName = "Mana",
            Start = 10,
            Base = 10,
            Mod = 10,
            Cost = 3,
            EquipmentBonus = 0
        };
        public Skill Staff { get; set; } = new Skill(false)
        {
            DisplayName = "Staff",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Bless { get; set; } = new Skill(false)
        {
            DisplayName = "Bless",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Heal { get; set; } = new Skill(false)
        {
            DisplayName = "Heal",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Freeze { get; set; } = new Skill(false)
        {
            DisplayName = "Freeze",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill MagicShield { get; set; } = new Skill(false)
        {
            DisplayName = "Magic Shield",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Lightning { get; set; } = new Skill(false)
        {
            DisplayName = "Lightning",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Fire { get; set; } = new Skill(false)
        {
            DisplayName = "Fire",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Pulse { get; set; } = new Skill(false)
        {
            DisplayName = "Pulse",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Duration { get; set; } = new Skill(false)
        {
            DisplayName = "Duration",
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Meditate { get; set; } = new Skill(false)
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

        public override void CalculateAttributes()
        {
            int blessValue = BlessActive ? Bless.Mod / 4 : 0;

            Wisdom.Mod = (Wisdom.Base == 40 || Wisdom.Base == 80 ? Wisdom.Base - 1 : Wisdom.Base) + MaxMagicalBonus(Wisdom) + blessValue;
            Intuition.Mod = (Intuition.Base == 40 || Intuition.Base == 80 ? Intuition.Base - 1 : Intuition.Base) + MaxMagicalBonus(Intuition) + blessValue;
            Agility.Mod = (Agility.Base == 40 || Agility.Base == 80 ? Agility.Base - 1 : Agility.Base) + MaxMagicalBonus(Agility) + blessValue;
            Strength.Mod = (Strength.Base == 40 || Strength.Base == 80 ? Strength.Base - 1 : Strength.Base) + MaxMagicalBonus(Strength) + blessValue;
        }

        public override void CalculateStats()
        {
            //Calculate all the shared stats first
            base.CalculateStats();

            Mana.Mod = Mana.Base + MaxMagicalBonus(Mana);

            Staff.Mod = Staff.Base + MaxMagicalBonus(Staff) + MaxAttributeBonus(Staff, ((Agility.Mod + Intuition.Mod + Strength.Mod) / 5));

            Heal.Mod = Heal.Base + MaxMagicalBonus(Heal) + MaxAttributeBonus(Heal, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Freeze.Mod = Freeze.Base + MaxMagicalBonus(Freeze) + MaxAttributeBonus(Freeze, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            MagicShield.Mod = MagicShield.Base + MaxMagicalBonus(MagicShield) + MaxAttributeBonus(MagicShield, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Lightning.Mod = Lightning.Base + MaxMagicalBonus(Lightning) + MaxAttributeBonus(Lightning, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Fire.Mod = Fire.Base + MaxMagicalBonus(Fire) + MaxAttributeBonus(Fire, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Pulse.Mod = Pulse.Base + MaxMagicalBonus(Pulse) + MaxAttributeBonus(Pulse, (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);

            Duration.Mod = Duration.Base + MaxMagicalBonus(Duration) + MaxAttributeBonus(Duration, (Wisdom.Mod + Intuition.Mod + Strength.Mod) / 5);
            Meditate.Mod = Meditate.Base + MaxMagicalBonus(Meditate) + MaxAttributeBonus(Meditate, (Wisdom.Mod + Wisdom.Mod + Wisdom.Mod) / 5);

            Speed = MasterAthlete 
                ? ((Agility.Mod + Agility.Mod + Strength.Mod) / 5) + (30 * 3)
                : (Agility.Mod + Agility.Mod + Strength.Mod) / 5;
        }
    }
}
