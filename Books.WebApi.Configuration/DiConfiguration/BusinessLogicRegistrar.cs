using Autofac;
using Books.BL.Interfaces.Services;
using Books.BL.Interfaces.Validation;
using Books.BL.Services;
using Books.BL.Validation;

namespace Books.WebApi.Configuration.DiConfiguration
{
    public static class BusinessLogicRegistrar
    {
        public static void RegisterBusinessLogic(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<BookProvider>().As<IBookProvider>();
            containerBuilder.RegisterType<BookCreator>().As<IBookCreator>();
            containerBuilder.RegisterType<IsbnValidator>().Named<IValidator>("ISBN");
            containerBuilder.Register(p => new TokenProvider(ApiConfig.AuthTokenKey)).As<ITokenProvider>();
        }
    }
}
