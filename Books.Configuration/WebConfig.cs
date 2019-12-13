using System.Configuration;

namespace Books.Configuration
{
	public static class WebConfig
	{
		public static readonly string WebApiUrl = ConfigurationManager.AppSettings["WebApiUrl"];
	}
}
