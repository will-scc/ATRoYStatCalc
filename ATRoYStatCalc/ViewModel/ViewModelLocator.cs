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
        }

        public MainViewModel MainPage => SimpleIoc.Default.GetInstance<MainViewModel>();

        public WarriorViewModel WarriorControl => SimpleIoc.Default.GetInstance<WarriorViewModel>();

        public MageViewModel MageControl => SimpleIoc.Default.GetInstance<MageViewModel>();
    }
}
