using System.IO;
using System.Reflection;
using System.Web.Http;
using WebActivatorEx;
using Books.Web;
using Books.Web.Swagger;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Books.Web
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Books.Web");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        c.SchemaFilter<ApplyModelNameFilter>();
                    })
                .EnableSwaggerUi();
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
