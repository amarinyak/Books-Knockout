using Autofac;
using Books.DAL.Interfaces.UnitOfWork;
using Books.DAL.UnitOfWork;

namespace Books.Configuration.DiConfiguration
{
	public static class DataAccessRegistrar
	{
		public static void RegisterDataAccess(this ContainerBuilder containerBuilder)
		{
			containerBuilder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>()
				.WithParameter("connectionString", ApiConfig.BooksDbConnectionString);
		}
	}
}
