using System.Web.Http;
using System.Web.Http.Cors;
using Books.Configuration;
using Books.WebApi.Code.Attributes;
using Books.WebApi.Code.Auth;

namespace Books.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
	        var cors = new EnableCorsAttribute(ApiConfig.WebAppUrl, "*", "*");
	        config.EnableCors(cors);

            config.MapHttpAttributeRoutes();
            
            config.Filters.Add(new TokenFilterAttribute());
            config.Filters.Add(new HandleErrorsFilterAttribute());
        }
    }
}
