using System;
using Books.Interfaces.Services;
using Books.Services;
using Microsoft.Practices.Unity;

namespace Books.Configuration
{
    public static class UnityConfig
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            // Services
            container.RegisterType<IBookDataService, BookDataService>(new ContainerControlledLifetimeManager(),
                new InjectionConstructor(BookDataConfig.GetBaseBookList()));
        }
    }
}
