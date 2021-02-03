namespace ATRoYStatCalc.Model
{
    public class Mage : BaseClass
    {
        public Skill Mana { get; set; } = new Skill(false)
        {
            DisplayName = "Mana",
            Start = 10,
            Base = 10,
            Cost = 3
        };
        public Skill Staff { get; set; } = new Skill(false)
        {
            DisplayName = "Staff",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Bless { get; set; } = new Skill(false)
        {
            DisplayName = "Bless",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Heal { get; set; } = new Skill(false)
        {
            DisplayName = "Heal",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Freeze { get; set; } = new Skill(false)
        {
            DisplayName = "Freeze",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill MagicShield { get; set; } = new Skill(false)
        {
            DisplayName = "Magic Shield",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Lightning { get; set; } = new Skill(false)
        {
            DisplayName = "Lightning",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Fire { get; set; } = new Skill(false)
        {
            DisplayName = "Fire",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Pulse { get; set; } = new Skill(false)
        {
            DisplayName = "Pulse",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Duration { get; set; } = new Skill(false)
        {
            DisplayName = "Duration",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Meditate { get; set; } = new Skill(false)
        {
            DisplayName = "Meditate",
            Start = 1,
            Base = 1,
            Cost = 1
        };

        public Mage(bool initialize = false)
        {
            if (initialize)
            {
                Skills.AddDistinctSkill(Mana);
                Skills.AddDistinctSkill(Staff);
                Skills.AddDistinctSkill(Bless);
                Skills.AddDistinctSkill(Heal);
                Skills.AddDistinctSkill(Freeze);
                Skills.AddDistinctSkill(MagicShield);
                Skills.AddDistinctSkill(Lightning);
                Skills.AddDistinctSkill(Fire);
                Skills.AddDistinctSkill(Pulse);
                Skills.AddDistinctSkill(Duration);
                Skills.AddDistinctSkill(Meditate);
            }
        }

        public override void UpdateCharacter()
        {
            CalculateLevel();
            CalculateAttributeBonuses();
        }

        public override void CalculateAttributeBonuses()
        {
            foreach (Attribute attribute in Attributes)
            {
                attribute.BlessBonus = 0;
            }

            Bless.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;

            foreach (Attribute attribute in Attributes)
            {
                attribute.BlessBonus = Bless.Mod / 4;
            }

            base.CalculateAttributeBonuses();

            Staff.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;

            Bless.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Heal.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Freeze.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            MagicShield.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Lightning.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Fire.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;
            Pulse.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5;

            Duration.AttributeBonus = (Wisdom.Mod + Intuition.Mod + Strength.Mod) / 5;
            Meditate.AttributeBonus = (Wisdom.Mod + Wisdom.Mod + Wisdom.Mod) / 5;
        }
    }
}
