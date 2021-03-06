﻿using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ATRoYStatCalc.ViewModel
{
    public class RogueViewModel : ViewModelBase
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
        });

        private void Base_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Base" || e.PropertyName == "EquipmentBonus")
            {
                Rogue.UpdateCharacter();
            }
        }

        public async Task Export()
        {
            SaveFileDialog fileDialog = new SaveFileDialog
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
