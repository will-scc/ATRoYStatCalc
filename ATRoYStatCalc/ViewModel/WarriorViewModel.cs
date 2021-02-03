using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

namespace ATRoYStatCalc.ViewModel
{
    public class WarriorViewModel : ViewModelBase
    {
        public Warrior Warrior { get; set; } = new Warrior(true);

        public WarriorViewModel()
        {
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

        private void Base_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Base")
            {
                Warrior.UpdateCharacter();
            }
        }

        public async Task Export()
        {
            string jsonString = JsonConvert.SerializeObject(new WarriorBuild()
            {
                Stats = Warrior
            });

            await File.WriteAllTextAsync($"{Warrior.CharacterName}.bwar", jsonString);
        }
    }
}
