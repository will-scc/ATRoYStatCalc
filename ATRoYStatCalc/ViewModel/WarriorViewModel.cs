using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ATRoYStatCalc.ViewModel
{
    public class WarriorViewModel : ViewModelBase
    {
        public Warrior Warrior { get; set; } = new Warrior();

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
        }

        private ICommand _updateCharacter;
        public ICommand UpdateCharacter => _updateCharacter ??= new RelayCommand(() =>
        {
            Warrior.UpdateCharacter();
        });
        private void Base_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Base" || e.PropertyName == "EquipmentBonus")
            {
                Warrior.UpdateCharacter();
            }
        }

        public async Task Export()
        {
            SaveFileDialog fileDialog = new SaveFileDialog
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
