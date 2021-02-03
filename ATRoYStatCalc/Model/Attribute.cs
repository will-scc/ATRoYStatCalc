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
        public int BlessBonus { get; set; } = 0;
        public int EquipmentBonus { get; set; } = 0;
        public bool MasterWarriorBonus { get; set; } = false;
        public int Mod => Base + Math.Min(EquipmentBonus + BlessBonus, MaxMod) + (MasterWarriorBonus ? 15 : 0);
        public int MaxMod => IsSeyan
                    ? (int)Math.Floor((double)Base / 100 * 72.5)
                    : (int)Math.Floor((double)Base / 100 * 50);
        public bool MaxEquipmentModExceeded => EquipmentBonus > MaxMod;
        public bool MaxBlessModExceeded => BlessBonus > MaxMod;
        public bool MaxModExceeded => BlessBonus + EquipmentBonus > MaxMod;
       
    }
}
