using Books.WebApp.Configuration;
using Books.WebApp.Interfaces.Builders;
using Books.WebApp.ViewModels;

namespace Books.WebApp.Code.Builders
{
	public class AppConfigViewModelBuilder : IAppConfigViewModelBuilder
	{
		private readonly AppConfigSettings _settings;

		public AppConfigViewModelBuilder(AppConfigSettings settings)
		{
			_settings = settings;
		}

		public AppConfigViewModel Build()
		{
			return new AppConfigViewModel
			{
				WebApiUrl = _settings.WebApiUrl,
				DefaultSortOrder = _settings.DefaultSortOrder,
				DefaultDescSort = _settings.DefaultDescSort
			};
		}
	}
}