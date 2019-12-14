using Autofac;
using Books.WebApp.Code.Builders;
using Books.WebApp.Interfaces.Builders;

namespace Books.WebApp.DiConfiguration
{
    public static class WebAppRegistrar
    {
        public static void RegisterWebAppBuilders(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<AppConfigViewModelBuilder>().As<IAppConfigViewModelBuilder>().SingleInstance();
            containerBuilder.RegisterType<HomeViewModelBuilder>().As<IHomeViewModelBuilder>().SingleInstance();
        }
    }
}