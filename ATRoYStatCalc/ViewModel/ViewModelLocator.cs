using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATRoYStatCalc.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => (IServiceLocator)SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<WarriorViewModel>();
            SimpleIoc.Default.Register<MageViewModel>();
            SimpleIoc.Default.Register<SeyanViewModel>();
        }

        public MainViewModel MainPage => SimpleIoc.Default.GetInstance<MainViewModel>();

        public WarriorViewModel WarriorView => SimpleIoc.Default.GetInstance<WarriorViewModel>();

        public MageViewModel MageView => SimpleIoc.Default.GetInstance<MageViewModel>();

        public SeyanViewModel SeyanView => SimpleIoc.Default.GetInstance<SeyanViewModel>();
    }
}
