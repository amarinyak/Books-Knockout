using System;
using Autofac;
using Autofac.Integration.Mvc;
using Books.WebApp.Configuration.DiConfiguration;

namespace Books.WebApp.DiConfiguration
{
    public class DiConfig
    {
        public static IContainer Container => InnerContainer.Value;

        private static readonly Lazy<IContainer> InnerContainer = new Lazy<IContainer>(() =>
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterBusinessLogic();
            builder.RegisterWebAppBuilders();

            return builder.Build();
        });
    }
}
