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
        public int Mod => Base + Math.Min(Math.Max(IsResource ? 0 : 15, AttributeBonus), MaxAttributeMod) + Math.Min(EquipmentBonus, MaxEquipmentMod);
        public int MaxAttributeMod => Base * 2;
        public int MaxEquipmentMod => IsSeyan
                    ? (int)Math.Floor(Base * 0.725)
                    : (int)Math.Floor(Base * 0.50);
        public bool MaxAttributeModExceeded => AttributeBonus > MaxAttributeMod;
        public bool MaxEquipmentModExceeded => EquipmentBonus > MaxEquipmentMod;

    }
}
