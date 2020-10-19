using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using System.Linq;

namespace ATRoYStatCalc.ViewModel
{
    public class SeyanViewModel : ViewModelBase
    {
        private Seyan _seyan = new Seyan();
        public Seyan Seyan
        {
            get => _seyan;
            set
            {
                _seyan = value;
                RaisePropertyChanged("Seyan");
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

        public SeyanViewModel()
        {
            foreach (Skill skill in Seyan.Skills)
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

            Seyan.UpdateCharacter();
        }

        private void Base_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Base")
            {
                Seyan.UpdateCharacter();
            }
        }

        private void Equipment_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateEquipmentBonuses();
            Seyan.UpdateCharacter();
        }

        private void UpdateEquipmentBonuses()
        {
            foreach (Skill skill in Seyan.Skills)
            {
                skill.EquipmentBonus = 0;
            }

            foreach (EquipmentPiece equipmentPiece in EquipmentSet.EquipmentPieces)
            {
                Skill firstSkill = Seyan.Skills.FirstOrDefault(x => x.DisplayName == equipmentPiece.First.Stat);
                if (firstSkill != null)
                {
                    firstSkill.EquipmentBonus += equipmentPiece.First.Value;
                }

                Skill secondSkill = Seyan.Skills.FirstOrDefault(x => x.DisplayName == equipmentPiece.Second.Stat);
                if (secondSkill != null)
                {
                    secondSkill.EquipmentBonus += equipmentPiece.Second.Value;
                }

                Skill thirdSkill = Seyan.Skills.FirstOrDefault(x => x.DisplayName == equipmentPiece.Third.Stat);
                if (thirdSkill != null)
                {
                    thirdSkill.EquipmentBonus += equipmentPiece.Third.Value;
                }

                Skill fourthSkill = Seyan.Skills.FirstOrDefault(x => x.DisplayName == equipmentPiece.Fourth.Stat);
                if (fourthSkill != null)
                {
                    fourthSkill.EquipmentBonus += equipmentPiece.Fourth.Value;
                }
            }
        }
    }
}
