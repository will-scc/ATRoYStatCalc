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
    public class RogueViewModel : ObservableRecipient
    {
        public Rogue Rogue { get; set; } = new Rogue();
        public int EnemyDefence { get; set; } = 1000;
        private Tuple<int, int> AccuracyAndArmor => HelperFuncs.GetAccuracyAndEffectiveArmor(Rogue.Offence - EnemyDefence);
        public int Accuracy => AccuracyAndArmor.Item1;
        public int EffectiveArmor => AccuracyAndArmor.Item2;
        public RogueViewModel() { }

        public void Setup()
        {
            Rogue.SetupSkills();

            Parallel.ForEach(Rogue.Attributes, attribute =>
            {
                attribute.PropertyChanged += Base_PropertyChanged;
            });

            Parallel.ForEach(Rogue.Skills, skill =>
            {
                skill.PropertyChanged += Base_PropertyChanged;
            });

            Rogue.UpdateCharacter();
        }

        private ICommand _updateCharacter;
        public ICommand UpdateCharacter => _updateCharacter ??= new RelayCommand(() =>
        {
            Rogue.UpdateCharacter();

            OnPropertyChanged(nameof(Accuracy));
            OnPropertyChanged(nameof(AccuracyAndArmor));
            OnPropertyChanged(nameof(EffectiveArmor));
        });

        private void Base_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Base" || e.PropertyName == "EquipmentBonus")
            {
                Rogue.UpdateCharacter();

                OnPropertyChanged(nameof(Accuracy));
                OnPropertyChanged(nameof(AccuracyAndArmor));
                OnPropertyChanged(nameof(EffectiveArmor));
            }
        }

        public async Task Export()
        {
            SaveFileDialog fileDialog = new()
            {
                Filter = "Bel Build Files|*.brog",
                Title = "Save a Rogue Build File"
            };

            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                string jsonString = JsonConvert.SerializeObject(Rogue);
                await File.WriteAllTextAsync($"{fileDialog.FileName}", jsonString);
            }
        }
    }
}
