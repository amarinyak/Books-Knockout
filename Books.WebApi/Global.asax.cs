using System.Web.Http;
using Autofac.Integration.WebApi;
using Books.WebApi.DiConfiguration;
using Newtonsoft.Json.Serialization;

namespace Books.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = DiConfig.Container;
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
