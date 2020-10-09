using System;

namespace ATRoYStatCalc.Model
{
    public class Seyan : BaseClass
    {
        public Skill Sword { get; set; }
        public Skill TwoHanded { get; set; }

        public Skill ArmorSkill { get; set; }
        public Skill Attack { get; set; }
        public Skill Parry { get; set; }
        public Skill Warcry { get; set; }
        public Skill Tactics { get; set; }
        public Skill SurroundHit { get; set; }
        public Skill BodyControl { get; set; }
        public Skill SpeedSkill { get; set; }

        public Seyan()
        {
            Sword.Start = 1;
            Sword.Base = 1;
            Sword.Cost = 1;

            TwoHanded.Start = 1;
            TwoHanded.Base = 1;
            TwoHanded.Cost = 1;

            ArmorSkill.Start = 1;
            ArmorSkill.Base = 1;
            ArmorSkill.Cost = 1;

            Attack.Start = 1;
            Attack.Base = 1;
            Attack.Cost = 1;

            Parry.Start = 1;
            Parry.Base = 1;
            Parry.Cost = 1;

            Warcry.Start = 1;
            Warcry.Base = 1;
            Warcry.Cost = 1;

            Tactics.Start = 1;
            Tactics.Base = 1;
            Tactics.Cost = 1;

            SurroundHit.Start = 1;
            SurroundHit.Base = 1;
            SurroundHit.Cost = 1;

            BodyControl.Start = 1;
            BodyControl.Base = 1;
            BodyControl.Cost = 1;

            SpeedSkill.Start = 1;
            SpeedSkill.Base = 1;
            SpeedSkill.Cost = 1;
        }

        public override int RaiseCost(Skill skill, int nextLevel)
        {
            int nr = nextLevel - skill.Start + 1 + 5;
            return Math.Max(1, nr * 3 * skill.Cost * 4 / 30);
        }
    }
}
