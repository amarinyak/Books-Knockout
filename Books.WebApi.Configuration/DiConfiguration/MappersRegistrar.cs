using Autofac;
using Books.BL.Interfaces.Mappers;
using Books.BL.Mappers;

namespace Books.WebApi.Configuration.DiConfiguration
{
    public static class MappersRegistrar
    {
        public static void RegisterMappers(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<AuthorMapper>().As<IAuthorMapper>().SingleInstance();
            containerBuilder.RegisterType<BookMapper>().As<IBookMapper>().SingleInstance();
        }
    }
}
