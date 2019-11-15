using Autofac;
using Books.DAL.UnitOfWork;
using Books.DAL.Interfaces.UnitOfWork;

namespace Books.Configuration.DI
{
	public static class DataAccessRegistrar
	{
		public static void RegisterDataAccess(this ContainerBuilder containerBuilder)
		{
			containerBuilder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>()
				.WithParameter("connectionString", ConfigFile.BooksDbConnectionString);
		}
	}
}
