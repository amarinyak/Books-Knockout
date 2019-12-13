using Books.Configuration;

namespace Books.Web.ViewModels
{
    public class AppConfigViewModel
    {
        public string WebApiUrl { get; set; }

        public static AppConfigViewModel Create()
        {
			return new AppConfigViewModel
			{
				WebApiUrl = WebConfig.WebApiUrl
			};
        }
    }
}