using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATRoYStatCalc.Model
{
    public class EquipmentStat : ObservableObject
    {
        private string _stat;
        public string Stat
        {
            get => _stat;
            set
            {
                _stat = value;
                RaisePropertyChanged("Stat");
            }
        }

        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                RaisePropertyChanged("Value");
            }
        }
    }
}
