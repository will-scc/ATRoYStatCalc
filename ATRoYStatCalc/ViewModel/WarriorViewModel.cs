using ATRoYStatCalc.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ATRoYStatCalc.ViewModel
{
    public class WarriorViewModel : ObservableRecipient
    {
        public Warrior Warrior { get; set; } = new Warrior();
        public int EnemyDefence { get; set; } = 1000;
        private Tuple<int, int> AccuracyAndArmor => HelperFuncs.GetAccuracyAndEffectiveArmor(Warrior.Offence - EnemyDefence);
        public int Accuracy => AccuracyAndArmor.Item1;
        public int EffectiveArmor => AccuracyAndArmor.Item2;
        public WarriorViewModel() { }

        public void Setup()
        {
            Warrior.SetupSkills();

            Parallel.ForEach(Warrior.Attributes, attribute =>
            {
                attribute.PropertyChanged += Base_PropertyChanged;
            });

            Parallel.ForEach(Warrior.Skills, skill =>
            {
                skill.PropertyChanged += Base_PropertyChanged;
            });

            Warrior.UpdateCharacter();
            InferredProperiesChanged();
        }

        private ICommand _updateCharacter;
        public ICommand UpdateCharacter => _updateCharacter ??= new RelayCommand(() =>
        {
            Warrior.UpdateCharacter();
            InferredProperiesChanged();
        });
        private void Base_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Base" || e.PropertyName == "EquipmentBonus")
            {
                Warrior.UpdateCharacter();
                InferredProperiesChanged();
            }
        }

        private void InferredProperiesChanged()
        {
            OnPropertyChanged(nameof(Accuracy));
            OnPropertyChanged(nameof(AccuracyAndArmor));
            OnPropertyChanged(nameof(EffectiveArmor));
        }

        public async Task Export()
        {
            SaveFileDialog fileDialog = new()
            {
                Filter = "Bel Build Files|*.bwar",
                Title = "Save a Warrior Build File"
            };

            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                string jsonString = JsonConvert.SerializeObject(Warrior);
                await File.WriteAllTextAsync($"{fileDialog.FileName}", jsonString);
            }
        }
    }
}
