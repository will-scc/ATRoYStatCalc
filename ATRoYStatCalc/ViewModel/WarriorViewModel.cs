using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        public WarriorViewModel()
        {
            Warrior = new Warrior();

            foreach (Skill skill in Warrior.Skills)
            {
                skill.PropertyChanged += Base_PropertyChanged;
            }

            foreach (EquipmentPiece equipmentPiece in EquipmentSet.EquipmentPieces)
            {
                equipmentPiece.First.PropertyChanged += Equipment_PropertyChanged;
                equipmentPiece.Second.PropertyChanged += Equipment_PropertyChanged;
                equipmentPiece.Third.PropertyChanged += Equipment_PropertyChanged;
                equipmentPiece.Fourth.PropertyChanged += Equipment_PropertyChanged;
            }

            Warrior.UpdateCharacter();
        }

        private void Base_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Base")
            {
                Warrior.UpdateCharacter();
            }
        }

        private void Equipment_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateEquipmentBonuses();
            Warrior.UpdateCharacter();
        }

        private void UpdateEquipmentBonuses()
        {
            foreach (Skill skill in Warrior.Skills)
            {
                skill.EquipmentBonus = 0;
            }

            foreach (EquipmentPiece equipmentPiece in EquipmentSet.EquipmentPieces)
            {
                Skill firstSkill = Warrior.Skills.FirstOrDefault(x => x.DisplayName == equipmentPiece.First.Stat);
                if (firstSkill != null)
                {
                    firstSkill.EquipmentBonus += equipmentPiece.First.Value;
                }

                Skill secondSkill = Warrior.Skills.FirstOrDefault(x => x.DisplayName == equipmentPiece.Second.Stat);
                if (secondSkill != null)
                {
                    secondSkill.EquipmentBonus += equipmentPiece.Second.Value;
                }

                Skill thirdSkill = Warrior.Skills.FirstOrDefault(x => x.DisplayName == equipmentPiece.Third.Stat);
                if (thirdSkill != null)
                {
                    thirdSkill.EquipmentBonus += equipmentPiece.Third.Value;
                }

                Skill fourthSkill = Warrior.Skills.FirstOrDefault(x => x.DisplayName == equipmentPiece.Fourth.Stat);
                if (fourthSkill != null)
                {
                    fourthSkill.EquipmentBonus += equipmentPiece.Fourth.Value;
                }
            }

        }
    }
}
