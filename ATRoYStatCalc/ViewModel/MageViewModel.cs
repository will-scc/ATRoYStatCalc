using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System;

namespace ATRoYStatCalc.ViewModel
{
    public class MageViewModel : ViewModelBase
    {
        public Mage Mage { get; set; } = new Mage();
        public int EnemyDefence { get; set; } = 1000;
        private Tuple<int, int> AccuracyAndArmour => HelperFuncs.GetAccuracyAndEffectiveArmour(Mage.Offence - EnemyDefence);
        public int Accuracy => AccuracyAndArmour.Item1;
        public int EffectiveArmour => AccuracyAndArmour.Item2;

        public MageViewModel() { }

        public void Setup()
        {
            Mage.SetupSkills();

            Parallel.ForEach(Mage.Attributes, attribute =>
            {
                attribute.PropertyChanged += Base_PropertyChanged;
            });

            Parallel.ForEach(Mage.Skills, skill =>
            {
                skill.PropertyChanged += Base_PropertyChanged;
            });

            Mage.UpdateCharacter();
        }

        private ICommand _updateCharacter;
        public ICommand UpdateCharacter => _updateCharacter ??= new RelayCommand(() =>
        {
            Mage.UpdateCharacter();
        });

        private void Base_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Base" || e.PropertyName == "EquipmentBonus")
            {
                Mage.UpdateCharacter();
            }
        }

        public async Task Export()
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Filter = "Bel Build Files|*.bmag",
                Title = "Save a Mage Build File"
            };

            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                string jsonString = JsonConvert.SerializeObject(Mage);
                await File.WriteAllTextAsync($"{fileDialog.FileName}", jsonString);
            }
        }
    }
}
