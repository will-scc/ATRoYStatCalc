using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ATRoYStatCalc.ViewModel
{
    public class SeyanViewModel : ViewModelBase
    {
        public Seyan Seyan { get; set; } = new Seyan(true);

        public SeyanViewModel()
        {
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

        private void Base_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Base")
            {
                Seyan.UpdateCharacter();
            }
        }

        public async Task Export()
        {
            string jsonString = JsonConvert.SerializeObject(new SeyanBuild()
            {
                Stats = Seyan
            });

            await File.WriteAllTextAsync($"{Seyan.CharacterName}.bsey", jsonString);
        }
    }
}
