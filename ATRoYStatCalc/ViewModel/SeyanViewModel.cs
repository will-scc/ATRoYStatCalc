using ATRoYStatCalc.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ATRoYStatCalc.ViewModel
{
    public class SeyanViewModel : ObservableRecipient
    {
        public Seyan Seyan { get; set; } = new Seyan();
        public int EnemyDefence { get; set; } = 1000;
        private Tuple<int, int> AccuracyAndArmor => HelperFuncs.GetAccuracyAndEffectiveArmor(Seyan.Offence - EnemyDefence);
        public int Accuracy => AccuracyAndArmor.Item1;
        public int EffectiveArmor => AccuracyAndArmor.Item2;

        public SeyanViewModel() { }

        public void Setup()
        {
            Seyan.SetupSkills();

            Parallel.ForEach(Seyan.Attributes, attributes =>
            {
                attributes.PropertyChanged += Base_PropertyChanged;
            });

            Parallel.ForEach(Seyan.Skills, skill =>
            {
                skill.PropertyChanged += Base_PropertyChanged;
            });

            Seyan.UpdateCharacter();
        }

        private ICommand _updateCharacter;
        public ICommand UpdateCharacter => _updateCharacter ??= new RelayCommand(() =>
        {
            Seyan.UpdateCharacter();

            OnPropertyChanged(nameof(Accuracy));
            OnPropertyChanged(nameof(AccuracyAndArmor));
            OnPropertyChanged(nameof(EffectiveArmor));
        });

        private void Base_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Need to be careful to prevent StackOverFlow exceptions
            //UpdateCharacter triggers PropertyChanged
            if (e.PropertyName == "Base" || e.PropertyName == "EquipmentBonus")
            {
                Seyan.UpdateCharacter();
                
                OnPropertyChanged(nameof(Accuracy));
                OnPropertyChanged(nameof(AccuracyAndArmor));
                OnPropertyChanged(nameof(EffectiveArmor));
            }
        }

        public async Task Export()
        {
            SaveFileDialog fileDialog = new()
            {
                Filter = "Bel Build Files|*.bsey",
                Title = "Save a Seyan Build File"
            };

            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                string jsonString = JsonConvert.SerializeObject(Seyan);
                await File.WriteAllTextAsync($"{fileDialog.FileName}", jsonString);
            }
        }
    }
}
