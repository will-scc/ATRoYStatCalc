using GalaSoft.MvvmLight;
using System;

namespace ATRoYStatCalc.Model
{
    public class Skill : ObservableObject
    {
        private readonly bool IsSeyan;
        private readonly bool IsResource;
        public Skill(bool IsSeyan, bool IsResource = false)
        {
            this.IsSeyan = IsSeyan;
            this.IsResource = IsResource;
        }

        public string DisplayName { get; set; }
        public int Start { get; set; }
        public int Base { get; set; }
        public int Cost { get; set; }
        public int AttributeBonus { get; set; }
        public int EquipmentBonus { get; set; }
        public int LevelBonus { get; set; }
        public int PtmBonus { get; set; }
        public int Mod => CalculateMod();
        public int CalculateMod()
        {
            double newMod = 0;

            newMod += Base;
            newMod += Math.Max(IsResource ? 0 : 15, Math.Min(AttributeBonus, MaxAttributeMod));
            newMod += Math.Min(EquipmentBonus, MaxEquipmentMod);
            newMod += LevelBonus;
            newMod += PtmBonus;

            return (int)newMod;
        }

        public int MaxAttributeMod => Base * 2;
        public int MaxEquipmentMod => IsSeyan
                    ? (int)Math.Floor(Base * 0.725)
                    : (int)Math.Floor(Base * 0.50);
        public bool MaxAttributeModExceeded => AttributeBonus > MaxAttributeMod;
        public bool MaxEquipmentModExceeded => EquipmentBonus > MaxEquipmentMod;
    }
}
