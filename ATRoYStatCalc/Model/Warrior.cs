namespace ATRoYStatCalc.Model
{
    public class Warrior : BaseClass
    {
        public Skill Sword { get; set; } = new Skill(false)
        {
            DisplayName = "Sword",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill TwoHanded { get; set; } = new Skill(false)
        {
            DisplayName = "TwoHanded",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Rage { get; set; } = new Skill(false)
        {
            DisplayName = "Rage",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill ArmorSkill { get; set; } = new Skill(false)
        {
            DisplayName = "Armor Skill",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Attack { get; set; } = new Skill(false)
        {
            DisplayName = "Attack",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Parry { get; set; } = new Skill(false)
        {
            DisplayName = "Parry",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Warcry { get; set; } = new Skill(false)
        {
            DisplayName = "Warcry",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Tactics { get; set; } = new Skill(false)
        {
            DisplayName = "Tactics",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill SurroundHit { get; set; } = new Skill(false)
        {
            DisplayName = "Surround Hit",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill BodyControl { get; set; } = new Skill(false)
        {
            DisplayName = "Body Control",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill SpeedSkill { get; set; } = new Skill(false)
        {
            DisplayName = "Speed Skill",
            Start = 1,
            Base = 1,
            Cost = 1
        };
        public Skill Regenerate { get; set; } = new Skill(false)
        {
            DisplayName = "Regenerate",
            Start = 1,
            Base = 1,
            Cost = 1
        };

        public Warrior(bool initialize = false)
        {
            if (initialize)
            {
                Skills.AddDistinctSkill(Sword);
                Skills.AddDistinctSkill(TwoHanded);
                Skills.AddDistinctSkill(Rage);
                Skills.AddDistinctSkill(ArmorSkill);
                Skills.AddDistinctSkill(Attack);
                Skills.AddDistinctSkill(Parry);
                Skills.AddDistinctSkill(Warcry);
                Skills.AddDistinctSkill(Tactics);
                Skills.AddDistinctSkill(SurroundHit);
                Skills.AddDistinctSkill(BodyControl);
                Skills.AddDistinctSkill(SpeedSkill);
                Skills.AddDistinctSkill(Regenerate);
            }
        }

        public override void CalculateAttributeBonuses()
        {
            base.CalculateAttributeBonuses();

            Sword.AttributeBonus = (Intuition.Mod + Intuition.Mod + Agility.Mod) / 5;
            TwoHanded.AttributeBonus = (Agility.Mod + Agility.Mod + Strength.Mod) / 5;
            ArmorSkill.AttributeBonus = (Agility.Mod + Agility.Mod + Strength.Mod) / 5;
            Attack.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            Parry.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            Warcry.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            Tactics.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            SurroundHit.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            BodyControl.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            SpeedSkill.AttributeBonus = (Agility.Mod + Intuition.Mod + Strength.Mod) / 5;
            Rage.AttributeBonus = (Strength.Mod + Strength.Mod + Intuition.Mod) / 5;
        }
    }
}
