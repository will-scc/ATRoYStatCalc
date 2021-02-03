using GalaSoft.MvvmLight;
using System;

namespace ATRoYStatCalc.Model
{
    public class Skill : ObservableObject
    {
        private readonly bool IsSeyan;
        public Skill(bool IsSeyan)
        {
            this.IsSeyan = IsSeyan;
        }

        public string DisplayName { get; set; }
        public int Start { get; set; }
        //private int _base;
        public int Base { get; set; }
        //{
        //    get => _base;
        //    set
        //    {
        //        _base = value;
        //        RaisePropertyChanged("Base");
        //        RaisePropertyChanged("MaxEquipmentModExceeded");
        //    }
        //}

        
        public int Cost { get; set; }
        public int AttributeBonus { get; set; }
        //private int _equipmentBonus;
        public int EquipmentBonus { get; set; }
        //{
        //    get => _equipmentBonus;
        //    set
        //    {
        //        _equipmentBonus = value;
        //        RaisePropertyChanged("EquipmentBonus");
        //        RaisePropertyChanged("MaxEquipmentModExceeded");
        //    }
        //}
        public int Mod => Base + Math.Min(AttributeBonus, MaxAttributeMod) + Math.Min(EquipmentBonus, MaxEquipmentMod);

        public int MaxAttributeMod => Base * 2;
        public int MaxEquipmentMod => IsSeyan
                    ? (int)Math.Floor(((double)Base / 100) * 72.5)
                    : (int)Math.Floor(((double)Base / 100) * 50);
        
        public bool MaxAttributeModExceeded => AttributeBonus > MaxAttributeMod;
        public bool MaxEquipmentModExceeded => EquipmentBonus > MaxEquipmentMod;

        //public void Calculate(int ModFromAttribute)
        //{
        //    //equipment mod
        //    //attributemod
        //    //bless?
        //    AttributeBonus = ModFromAttribute;

        //    int actualAttributeBonus = Math.Min(MaxAttributeMod, Math.Max(15, AttributeBonus));
        //    int actualEquipmentBonus = Math.Min(EquipmentBonus, MaxMagicalMod);

        //    Mod = Base + actualAttributeBonus + actualEquipmentBonus;
        //}
    }
}
