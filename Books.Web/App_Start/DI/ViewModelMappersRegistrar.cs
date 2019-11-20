using Autofac;
using Books.Web.Code.Mappers;
using Books.Web.Interfaces.Mappers;

namespace Books.Web.DI
{
	public static class ViewModelMappersRegistrar
	{
		public static void RegisterViewModelMappers(this ContainerBuilder containerBuilder) 
		{
			containerBuilder.RegisterType<AuthorViewModelMapper>().As<IAuthorViewModelMapper>().SingleInstance();
			containerBuilder.RegisterType<BookViewModelMapper>().As<IBookViewModelMapper>().SingleInstance();
		}
	}
}
