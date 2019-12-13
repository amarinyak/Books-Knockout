using System.IO;
using System.Reflection;
using System.Web.Http;
using Books.WebApi.Swagger;
using Swashbuckle.Application;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Books.WebApi.Swagger
{
    public class SwaggerConfig
    {
        public static void Register()
        {
	        var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
	            .EnableSwagger(c =>
                    {
	                    c.SingleApiVersion("v1", "Books.WebApi");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        c.SchemaFilter<ApplyModelNameFilter>();
                    })
                .EnableSwaggerUi(c =>
                {
					c.InjectJavaScript(thisAssembly, "Books.WebApi.Scripts.SwaggerAuthorization.js");
                });
        }

        private static string GetXmlCommentsPath()
        {
	        var assembly = Assembly.GetExecutingAssembly();
	        var assemblyName = assembly.GetName();
			var directory = Path.GetDirectoryName(assemblyName.CodeBase) ?? string.Empty;

	        var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
	        var commentsFilePath = Path.Combine(directory, commentsFileName);

			return commentsFilePath;
        }
    }
}
