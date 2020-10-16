using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace ATRoYStatCalc.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                RaisePropertyChanged("CurrentView");
            }
        }

        public MainViewModel()
        {
            
        }

        private ICommand _setMageView;
        public ICommand SetMageView => _setMageView ??= new RelayCommand(() =>
        {
            CurrentView = new MageViewModel();
        });

        private ICommand _setWarriorView;
        public ICommand SetWarriorView => _setWarriorView ??= new RelayCommand(() =>
        {
            CurrentView = new WarriorViewModel();
        });

        private ICommand _setSeyanView;
        public ICommand SetSeyanView => _setSeyanView ??= new RelayCommand(() =>
        {
            CurrentView = new SeyanViewModel();
        });

        private void Export()
        {
            if (CurrentView.GetType() == typeof(MageViewModel))
            {
                MageViewModel temp = (MageViewModel)CurrentView;
                temp.Save();
            }

            if (CurrentView.GetType() == typeof(WarriorViewModel))
            {
                WarriorViewModel temp = (WarriorViewModel)CurrentView;
            }

            if (CurrentView.GetType() == typeof(SeyanViewModel))
            {
                SeyanViewModel temp = (SeyanViewModel)CurrentView;
            }
        }
    }
}
