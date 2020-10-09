using GalaSoft.MvvmLight;

namespace ATRoYStatCalc.Model
{
    public class Skill : ObservableObject
    {
        private int _start;
        public int Start
        {
            get => _start;
            set
            {
                _start = value;
                RaisePropertyChanged("Start");
            }
        }

        private int _base;
        public int Base
        {
            get => _base;
            set
            {
                _base = value;
                RaisePropertyChanged("Base");
            }
        }

        private int _mod;
        public int Mod
        {
            get => _mod;
            set
            {
                _mod = value;
                RaisePropertyChanged("Mod");
            }
        }

        private int _cost;
        public int Cost
        {
            get => _cost;
            set
            {
                _cost = value;
                RaisePropertyChanged("Cost");
            }
        }

        private int _equipmentBonus;
        public int EquipmentBonus
        {
            get => _equipmentBonus;
            set
            {
                _equipmentBonus = value;
                RaisePropertyChanged("EquipmentBonus");
            }
        }
    }
}
