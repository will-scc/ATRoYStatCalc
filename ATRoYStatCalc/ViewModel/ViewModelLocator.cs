using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;

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
            SimpleIoc.Default.Register<RogueViewModel>();
        }

        public MainViewModel MainPage => SimpleIoc.Default.GetInstance<MainViewModel>();

        public WarriorViewModel WarriorView => SimpleIoc.Default.GetInstance<WarriorViewModel>();

        public MageViewModel MageView => SimpleIoc.Default.GetInstance<MageViewModel>();

        public SeyanViewModel SeyanView => SimpleIoc.Default.GetInstance<SeyanViewModel>();

        public RogueViewModel RogueView => SimpleIoc.Default.GetInstance<RogueViewModel>();
    }
}
