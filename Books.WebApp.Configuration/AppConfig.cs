using System.Configuration;

namespace Books.WebApp.Configuration
{
	public static class AppConfig
	{
		public static readonly string WebApiUrl = ConfigurationManager.AppSettings["WebApiUrl"];
		public static readonly string DefaultSortOrder = ConfigurationManager.AppSettings["DefaultSortOrder"];
		public static readonly bool DefaultDescSort = bool.Parse(ConfigurationManager.AppSettings["DefaultDescSort"]);
	}
}
