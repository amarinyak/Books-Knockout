using System.Configuration;

namespace Books.Configuration
{
	public static class ApiConfig
	{
		public static readonly string BooksDbConnectionString = ConfigurationManager.ConnectionStrings["BooksDb"].ConnectionString;
		public static readonly string AuthTokenKey = ConfigurationManager.AppSettings["AuthTokenKey"];
		public static readonly string WebAppUrl = ConfigurationManager.AppSettings["WebAppUrl"];
	}
}
