using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows.Documents;

namespace ATRoYStatCalc.Model
{
    public class Mage : BaseClass
    {
        private bool BlessActive = true;

        public Skill Staff { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Bless { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Heal { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Freeze { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill MagicShield { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Lightning { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Fire { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Pulse { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        public Skill Duration { get; set; } = new Skill()
        {
            Start = 1,
            Base = 1,
            Mod = 1,
            Cost = 1,
            EquipmentBonus = 0
        };
        
        public Mage()
        {
            Skills.Add(Staff);
            Skills.Add(Bless);
            Skills.Add(Heal);
            Skills.Add(Freeze);
            Skills.Add(MagicShield);
            Skills.Add(Lightning);
            Skills.Add(Fire);
            Skills.Add(Pulse);
            Skills.Add(Duration);
        }

        public override void UpdateCharacter()
        {
            BlessActive = false;

            CalculateAttributes();

            CalculateBlessMod();

            BlessActive = true;

            CalculateAttributes();

            CalculateStats();
        }

        private void CalculateBlessMod()
        {
            Bless.Mod = Bless.Base + Bless.EquipmentBonus + ((Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
        }

        public override void CalculateAttributes()
        {
            int blessValue = BlessActive ? Bless.Mod / 4 : 0;

            Wisdom.Mod = Wisdom.Base.MaxBonus(Wisdom.EquipmentBonus + blessValue);
            Intuition.Mod = Intuition.Base.MaxBonus(Intuition.EquipmentBonus + blessValue);
            Agility.Mod = Agility.Base.MaxBonus(Agility.EquipmentBonus + blessValue);
            Strength.Mod = Strength.Base.MaxBonus(Strength.EquipmentBonus + blessValue);
        }

        public override void CalculateStats()
        {
            base.CalculateStats();

            Staff.Mod = Staff.Base.MaxBonus(Staff.EquipmentBonus + (Agility.Mod + Intuition.Mod + Strength.Mod / 5));

            Heal.Mod = Heal.Base.MaxBonus(Heal.EquipmentBonus + (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Freeze.Mod = Freeze.Base.MaxBonus(Freeze.EquipmentBonus + (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            MagicShield.Mod = MagicShield.Base.MaxBonus(MagicShield.EquipmentBonus + (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Lightning.Mod = Lightning.Base.MaxBonus(Lightning.EquipmentBonus + (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Fire.Mod = Fire.Base.MaxBonus(Fire.EquipmentBonus + (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Pulse.Mod = Pulse.Base.MaxBonus(Pulse.EquipmentBonus + (Wisdom.Mod + Intuition.Mod + Intuition.Mod) / 5);
            Duration.Mod = Duration.Base.MaxBonus(Duration.EquipmentBonus + (Wisdom.Mod + Intuition.Mod + Strength.Mod) / 5);
        }
    }
}
