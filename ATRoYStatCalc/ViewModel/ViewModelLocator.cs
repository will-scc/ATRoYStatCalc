using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace ATRoYStatCalc.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            Ioc.Default.ConfigureServices(new ServiceCollection()
                .AddSingleton<SplashScreenViewModel>()
                .AddSingleton<MainViewModel>()
                .AddSingleton<WarriorViewModel>()
                .AddSingleton<MageViewModel>()
                .AddSingleton<SeyanViewModel>()
                .AddSingleton<RogueViewModel>()
                .BuildServiceProvider());
        }

        public static MainViewModel MainPage => Ioc.Default.GetService<MainViewModel>();

        public static WarriorViewModel WarriorView => Ioc.Default.GetService<WarriorViewModel>();

        public static MageViewModel MageView => Ioc.Default.GetService<MageViewModel>();

        public static SeyanViewModel SeyanView => Ioc.Default.GetService<SeyanViewModel>();

        public static RogueViewModel RogueView => Ioc.Default.GetService<RogueViewModel>();
        
        public static SplashScreenViewModel SplashScreenView => Ioc.Default.GetService<SplashScreenViewModel>();
    }
}
