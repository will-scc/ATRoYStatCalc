using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATRoYStatCalc.ViewModel
{
    public class WarriorViewModel : ViewModelBase
    {
        private Warrior _warrior;
        public Warrior Warrior
        {
            get => _warrior;
            set
            {
                _warrior = value;
                RaisePropertyChanged("Warrior");
            }
        }

        public WarriorViewModel()
        {
            Warrior = new Warrior();
        }
    }
}
