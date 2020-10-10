using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace ATRoYStatCalc.Model
{
    public class EquipmentSet : ObservableObject
    {
        public List<EquipmentPiece> EquipmentPieces { get; set; } = new List<EquipmentPiece>();

        private EquipmentPiece _firstRing = new EquipmentPiece();
        public EquipmentPiece FirstRing { get; set; } = new EquipmentPiece();
        //{
        //    get => _firstRing;
        //    set
        //    {
        //        _firstRing = value;
        //        RaisePropertyChanged("FirstRing");
        //    }
        //}

        private EquipmentPiece _secondRing = new EquipmentPiece();
        public EquipmentPiece SecondRing
        {
            get => _secondRing;
            set
            {
                _secondRing = value;
                RaisePropertyChanged("SecondRing");
            }
        }

        private EquipmentPiece _amulet = new EquipmentPiece();
        public EquipmentPiece Amulet
        {
            get => _amulet;
            set
            {
                _amulet = value;
                RaisePropertyChanged("Amulet");
            }
        }

        //this maybe ought to have WV etc
        private EquipmentPiece _weapon = new EquipmentPiece();
        public EquipmentPiece Weapon
        {
            get => _weapon;
            set
            {
                _weapon = value;
                RaisePropertyChanged("Weapon");
            }
        }

        private EquipmentPiece _head = new EquipmentPiece();
        public EquipmentPiece Head
        {
            get => _head;
            set
            {
                _head = value;
                RaisePropertyChanged("Head");
            }
        }

        private EquipmentPiece _cape = new EquipmentPiece();
        public EquipmentPiece Cape
        {
            get => _cape;
            set
            {
                _cape = value;
                RaisePropertyChanged("Cape");
            }
        }

        private EquipmentPiece _chest = new EquipmentPiece();
        public EquipmentPiece Chest
        {
            get => _chest;
            set
            {
                _chest = value;
                RaisePropertyChanged("Chest");
            }
        }

        private EquipmentPiece _belt = new EquipmentPiece();
        public EquipmentPiece Belt
        {
            get => _belt;
            set
            {
                _belt = value;
                RaisePropertyChanged("Belt");
            }
        }

        private EquipmentPiece _arms = new EquipmentPiece();
        public EquipmentPiece Arms
        {
            get => _arms;
            set
            {
                _arms = value;
                RaisePropertyChanged("Arms");
            }
        }

        private EquipmentPiece _legs = new EquipmentPiece();
        public EquipmentPiece Legs
        {
            get => _legs;
            set
            {
                _legs = value;
                RaisePropertyChanged("Legs");
            }
        }

        private EquipmentPiece _boots = new EquipmentPiece();
        public EquipmentPiece Boots
        {
            get => _boots;
            set
            {
                _boots = value;
                RaisePropertyChanged("Boots");
            }
        }

        public EquipmentSet()
        {
            EquipmentPieces.Add(FirstRing);
            EquipmentPieces.Add(SecondRing);
            EquipmentPieces.Add(Amulet);
            EquipmentPieces.Add(Weapon);
            EquipmentPieces.Add(Head);
            EquipmentPieces.Add(Cape);
            EquipmentPieces.Add(Chest);
            EquipmentPieces.Add(Belt);
            EquipmentPieces.Add(Arms);
            EquipmentPieces.Add(Legs);
            EquipmentPieces.Add(Boots);
        }
    }
}
