using Books.WebApp.Configuration;
using Books.WebApp.Interfaces.Builders;
using Books.WebApp.ViewModels;

namespace Books.WebApp.Code.Builders
{
    public class AppConfigViewModelBuilder : IAppConfigViewModelBuilder
    {
        public AppConfigViewModel Build()
        {
            return new AppConfigViewModel
            {
                WebApiUrl = AppConfig.WebApiUrl,
                DefaultSortOrder = AppConfig.DefaultSortOrder,
                DefaultDescSort = AppConfig.DefaultDescSort
            };
        }
    }
}