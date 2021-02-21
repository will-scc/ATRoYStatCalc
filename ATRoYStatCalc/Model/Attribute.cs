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
        public int LevelBonus { get; set; }
        public int WarriorBonus { get; set; }
        public int Mod => CalculateMod();
        private int CalculateMod()
        {
            double newMod = 0;

            newMod += Base;

            if (IsSeyan)
            {
                //changed ptm scaling to balance classes
                if (Base > 107)
                {
                    //Seyans mods includes bless + eq
                    newMod += Math.Min(Math.Floor(107 * 0.725), EquipmentBonus + BlessBonus);
                    newMod += Math.Min(Math.Floor((Base - 107) * 0.29), EquipmentBonus + BlessBonus);
                }
                else
                {
                    newMod += Math.Min(EquipmentBonus + BlessBonus, MaxMod);
                }
            }
            else
            {
                //other class ptms scale differently
                if (Base > 122)
                {
                    newMod += Math.Min(Math.Floor(122 * 0.5), EquipmentBonus);
                    newMod += Math.Min(Math.Floor(122 * 0.5), BlessBonus);
                    newMod += Math.Min(Math.Floor((Base - 122) * 0.2), EquipmentBonus); 
                    newMod += Math.Min(Math.Floor((Base - 122) * 0.2), BlessBonus);
                }
                else
                {
                    newMod += Math.Min(EquipmentBonus, MaxMod);
                    newMod += Math.Min(BlessBonus, MaxMod);
                }
            }

            newMod += WarriorBonus;
            newMod += LevelBonus;

            return (int)newMod;
        }

        public int MaxMod => IsSeyan
                    ? (int)Math.Floor((double)(Base * 0.725))
                    : (int)Math.Floor((double)(Base * 0.5));
        public bool MaxEquipmentModExceeded => EquipmentBonus > MaxMod;
        public bool MaxBlessModExceeded => BlessBonus > MaxMod;
        public bool MaxModExceeded => MaxEquipmentModExceeded && MaxBlessModExceeded;
    }
}
