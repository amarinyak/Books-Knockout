using Autofac;
using Books.BL.Interfaces.Serializers;
using Books.BL.Serializers;

namespace Books.WebApp.Configuration.DiConfiguration
{
	public static class BusinessLogicRegistrar
	{
		public static void RegisterBusinessLogic(this ContainerBuilder containerBuilder)
		{
			containerBuilder.RegisterType<JsonSerializer>().As<ISerializer>();
		}
	}
}
