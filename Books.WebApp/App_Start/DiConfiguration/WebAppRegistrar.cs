using Autofac;
using Books.WebApp.Code.Builders;
using Books.WebApp.Configuration;
using Books.WebApp.Interfaces.Builders;

namespace Books.WebApp.DiConfiguration
{
    public static class WebAppRegistrar
    {
        public static void RegisterWebAppBuilders(this ContainerBuilder containerBuilder)
        {
            containerBuilder.Register(p => new AppConfigViewModelBuilder(new AppConfigSettings
            {
                WebApiUrl = AppConfig.WebApiUrl,
                DefaultSortOrder = AppConfig.DefaultSortOrder,
                DefaultDescSort = AppConfig.DefaultDescSort
            })).As<IAppConfigViewModelBuilder>();
            containerBuilder.RegisterType<HomeViewModelBuilder>().As<IHomeViewModelBuilder>().SingleInstance();
        }
    }
}
