using GalaSoft.MvvmLight;
using System;

namespace ATRoYStatCalc.Model
{
    public class Attribute : ObservableObject
    {
        private readonly bool IsSeyan;
        public Attribute(bool IsSeyan)
        {
            this.IsSeyan = IsSeyan;
        }

        public string DisplayName { get; set; }
        public int Start { get; set; }
        public int Cost { get; set; }
        public int Base { get; set; }
        public int BlessBonus { get; set; }
        public int EquipmentBonus { get; set; }
        public int WarriorBonus { get; set; }
        public int Mod => Base + Math.Min(EquipmentBonus, MaxMod) + Math.Min(BlessBonus, MaxMod) + WarriorBonus;
        public int MaxMod => IsSeyan
                    ? (int)Math.Floor((double)(Base * 0.725))
                    : (int)Math.Floor((double)(Base * 0.50));
        public bool MaxEquipmentModExceeded => EquipmentBonus > MaxMod;
        public bool MaxBlessModExceeded => BlessBonus > MaxMod;
        public bool MaxModExceeded => MaxEquipmentModExceeded && MaxBlessModExceeded;
    }
}
