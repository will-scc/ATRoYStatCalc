using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ATRoYStatCalc.ViewModel
{
    public class SeyanViewModel : ViewModelBase
    {
        public Seyan Seyan { get; set; } = new Seyan();
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
        });

        private void Base_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Need to be careful to prevent StackOverFlow exceptions
            //UpdateCharacter triggers PropertyChanged
            if (e.PropertyName == "Base" || e.PropertyName == "EquipmentBonus")
            {
                Seyan.UpdateCharacter();
            }
        }

        public async Task Export()
        {
            SaveFileDialog fileDialog = new SaveFileDialog
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
