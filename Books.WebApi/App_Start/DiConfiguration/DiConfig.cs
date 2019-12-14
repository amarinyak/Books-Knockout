using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Books.WebApi.Configuration.DiConfiguration;

namespace Books.WebApi.DiConfiguration
{
    public static class DiConfig
    {
		public static IContainer Container => InnerContainer.Value;

		private static readonly Lazy<IContainer> InnerContainer = new Lazy<IContainer>(() =>
		{
			var builder = new ContainerBuilder();

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

			builder.RegisterDataAccess();
			builder.RegisterBusinessLogic();
			builder.RegisterMappers();
			builder.RegisterViewModelMappers();
			
			return builder.Build();
		});
    }
}
