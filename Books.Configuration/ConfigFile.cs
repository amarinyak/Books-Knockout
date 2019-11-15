using System.Configuration;

namespace Books.Configuration
{
	public static class ConfigFile
	{
		public static readonly string BooksDbConnectionString = ConfigurationManager.ConnectionStrings["BooksDb"].ConnectionString;
	}
}