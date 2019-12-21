using Autofac;
using Books.DAL.Common;
using Books.DAL.Interfaces.Common;
using Books.DAL.Interfaces.UnitOfWork;
using Books.DAL.UnitOfWork;

namespace Books.WebApi.Configuration.DiConfiguration
{
	public static class DataAccessRegistrar
	{
		public static void RegisterDataAccess(this ContainerBuilder containerBuilder)
        {
            containerBuilder.Register(p => new DbConnectionFactory(ApiConfig.BooksDbConnectionString)).As<IDbConnectionFactory>().SingleInstance();
            containerBuilder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>().SingleInstance();
        }
	}
}
