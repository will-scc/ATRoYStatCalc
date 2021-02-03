using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ATRoYStatCalc.ViewModel
{
    public class MageViewModel : ViewModelBase
    {
        public Mage Mage { get; set; } = new Mage(true);

        public MageViewModel()
        {
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

        private void Base_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Base")
            {
                Mage.UpdateCharacter();
            }
        }

        public async Task Export()
        {
            string jsonString = JsonConvert.SerializeObject(new MageBuild()
            {
                Stats = Mage
            });

            await File.WriteAllTextAsync($"{Mage.CharacterName}.bmag", jsonString);
        }
    }
}
