using Autofac;
using Books.WebApi.Code.Mappers;
using Books.WebApi.Interfaces.Mappers;

namespace Books.WebApi.DiConfiguration
{
    public static class WebApiRegistrar
    {
        public static void RegisterViewModelMappers(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<AuthorViewModelMapper>().As<IAuthorViewModelMapper>().SingleInstance();
            containerBuilder.RegisterType<BookViewModelMapper>().As<IBookViewModelMapper>().SingleInstance();
        }
    }
}
