using GalaSoft.MvvmLight;

namespace ATRoYStatCalc.Model
{
    public class EquipmentPiece : ObservableObject
    {
        private EquipmentStat _first = new EquipmentStat();
        public EquipmentStat First
        {
            get => _first;
            set
            {
                _first = value;
                RaisePropertyChanged("First");
            }
        }

        private EquipmentStat _second = new EquipmentStat();
        public EquipmentStat Second
        {
            get => _second;
            set
            {
                _second = value;
                RaisePropertyChanged("Second");
            }
        }

        private EquipmentStat _third = new EquipmentStat();
        public EquipmentStat Third
        {
            get => _third;
            set
            {
                _third = value;
                RaisePropertyChanged("Third");
            }
        }

        private EquipmentStat _fourth = new EquipmentStat();
        public EquipmentStat Fourth
        {
            get => _fourth;
            set
            {
                _fourth = value;
                RaisePropertyChanged("Fourth");
            }
        }
    }
}
