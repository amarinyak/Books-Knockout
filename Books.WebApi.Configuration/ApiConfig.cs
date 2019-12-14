using System.Configuration;

namespace Books.WebApi.Configuration
{
    public static class ApiConfig
    {
        public static readonly string BooksDbConnectionString = ConfigurationManager.ConnectionStrings["BooksDb"].ConnectionString;
        public static readonly string AuthTokenKey = ConfigurationManager.AppSettings["AuthTokenKey"];
        public static readonly string WebAppUrl = ConfigurationManager.AppSettings["WebAppUrl"];
    }
}
