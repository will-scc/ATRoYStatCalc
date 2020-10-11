using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;

namespace ATRoYStatCalc.ViewModel
{
    public class MageViewModel : ViewModelBase
    {
        private Mage _mage = new Mage();
        public Mage Mage
        {
            get => _mage;
            set
            {
                _mage = value;
                RaisePropertyChanged("Mage");
            }
        }

        private EquipmentSet _equipmentSet = new EquipmentSet();
        public EquipmentSet EquipmentSet
        {
            get => _equipmentSet;
            set
            {
                _equipmentSet = value;
                RaisePropertyChanged("EquipmentSet");
            }
        }

        public MageViewModel()
        {
            foreach(Skill skill in Mage.Skills)
            {
                skill.PropertyChanged += Base_PropertyChanged;
            }

            foreach(EquipmentPiece equipmentPiece in EquipmentSet.EquipmentPieces)
            {
                equipmentPiece.First.PropertyChanged += Equipment_PropertyChanged;
                equipmentPiece.Second.PropertyChanged += Equipment_PropertyChanged;
                equipmentPiece.Third.PropertyChanged += Equipment_PropertyChanged;
                equipmentPiece.Fourth.PropertyChanged += Equipment_PropertyChanged;
            }

            Mage.UpdateCharacter();
        }

        private void Base_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Base")
            {
                Mage.UpdateCharacter();
            }
        }

        private void Equipment_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateEquipmentBonuses();
            Mage.UpdateCharacter();
        }

        private void UpdateEquipmentBonuses()
        {
            foreach (Skill skill in Mage.Skills)
            {
                skill.EquipmentBonus = 0;
            }

            foreach (EquipmentPiece equipmentPiece in EquipmentSet.EquipmentPieces)
            {
                Skill firstSkill = Mage.Skills.FirstOrDefault(x => x.DisplayName == equipmentPiece.First.Stat);
                if (firstSkill != null)
                {
                    firstSkill.EquipmentBonus += equipmentPiece.First.Value;
                }

                Skill secondSkill = Mage.Skills.FirstOrDefault(x => x.DisplayName == equipmentPiece.Second.Stat);
                if (secondSkill != null)
                {
                    secondSkill.EquipmentBonus += equipmentPiece.Second.Value;
                }

                Skill thirdSkill = Mage.Skills.FirstOrDefault(x => x.DisplayName == equipmentPiece.Third.Stat);
                if (thirdSkill != null)
                {
                    thirdSkill.EquipmentBonus += equipmentPiece.Third.Value;
                }

                Skill fourthSkill = Mage.Skills.FirstOrDefault(x => x.DisplayName == equipmentPiece.Fourth.Stat);
                if (fourthSkill != null)
                {
                    fourthSkill.EquipmentBonus += equipmentPiece.Fourth.Value;
                }
            }

        }
    }
}
