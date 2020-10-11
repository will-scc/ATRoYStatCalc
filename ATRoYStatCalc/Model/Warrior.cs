namespace ATRoYStatCalc.Model
{
    public class Warrior : BaseClass
    {
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
        public Skill Rage { get; set; } = new Skill
        {
            DisplayName = "Rage",
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

        public Warrior()
        {
            Skills.Add(Sword);
            Skills.Add(TwoHanded);
            Skills.Add(Rage);
            Skills.Add(ArmorSkill);
            Skills.Add(Attack);
            Skills.Add(Parry);
            Skills.Add(Warcry);
            Skills.Add(Tactics);
            Skills.Add(SurroundHit);
            Skills.Add(BodyControl);
            Skills.Add(SpeedSkill);
            Skills.Add(Regenerate);
        }

        public override void CalculateStats()
        {
            //Calculate all the shared stats first
            base.CalculateStats();

            //Calculate Warrior-specific stats
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

            Speed = MasterAthlete ? (SpeedSkill.Mod / 2) + (30 * 3) : SpeedSkill.Mod / 2;
        }
    }
}
