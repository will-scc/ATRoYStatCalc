using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows.Input;

namespace ATRoYStatCalc.ViewModel
{
    public class MageViewModel : ViewModelBase
    {
        private Mage _mage;
        public Mage Mage
        {
            get => _mage;
            set
            {
                _mage = value;
                RaisePropertyChanged("Mage");
            }
        }

        public MageViewModel()
        {
            Mage = new Mage();
            
            Mage.Bless.PropertyChanged += Base_PropertyChanged;

            foreach(Skill skill in Mage.Skills)
            {
                skill.PropertyChanged += Base_PropertyChanged;
            }
        }

        private void Base_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Base")
            {
                Mage.UpdateCharacter();
            }
        }

        private ICommand updateCharacterCommand;
        public ICommand UpdateCharacterCommand => updateCharacterCommand ??= new RelayCommand(() =>
        {
            Mage.UpdateCharacter();
        });
    }
}
