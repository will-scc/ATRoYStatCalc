namespace ATRoYStatCalc.Model
{
    public class Warrior : BaseClass
    {
        public Skill Sword { get; set; }
        public Skill TwoHanded { get; set; }
        public Skill Rage { get; set; }
        public Skill ArmorSkill { get; set; }
        public Skill Attack { get; set; }
        public Skill Parry { get; set; }
        public Skill Warcry { get; set; }
        public Skill Tactics { get; set; }
        public Skill SurroundHit { get; set; }
        public Skill BodyControl { get; set; }
        public Skill SpeedSkill { get; set; }

        public Warrior()
        {
            Sword = new Skill
            {
                Start = 1,
                Base = 1,
                Cost = 1
            };

            TwoHanded = new Skill
            {
                Start = 1,
                Base = 1,
                Cost = 1
            };

            Rage = new Skill
            {
                Start = 1,
                Base = 1,
                Cost = 1
            };

            ArmorSkill = new Skill
            {
                Start = 1,
                Base = 1,
                Cost = 1
            };

            Attack = new Skill
            {
                Start = 1,
                Base = 1,
                Cost = 1
            };

            Parry = new Skill
            {
                Start = 1,
                Base = 1,
                Cost = 1
            };

            Warcry = new Skill
            {
                Start = 1,
                Base = 1,
                Cost = 1
            };

            Tactics = new Skill
            {
                Start = 1,
                Base = 1,
                Cost = 1
            };

            SurroundHit = new Skill
            {
                Start = 1,
                Base = 1,
                Cost = 1
            };

            BodyControl = new Skill
            {
                Start = 1,
                Base = 1,
                Cost = 1
            };

            SpeedSkill = new Skill
            {
                Start = 1,
                Base = 1,
                Cost = 1
            };
        }
    }
}
