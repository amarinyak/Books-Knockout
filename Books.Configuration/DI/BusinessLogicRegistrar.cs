using Autofac;
using Books.BL.Interfaces.Providers;
using Books.BL.Interfaces.Validation;
using Books.BL.Providers;
using Books.BL.Validation;

namespace Books.Configuration.DI
{
	public static class BusinessLogicRegistrar
	{
		public static void RegisterBusinessLogic(this ContainerBuilder containerBuilder)
		{
			containerBuilder.RegisterType<BookProvider>().As<IBookProvider>();
			containerBuilder.RegisterType<IsbnValidator>().Named<IValidator>("ISBN");
		}
	}
}
