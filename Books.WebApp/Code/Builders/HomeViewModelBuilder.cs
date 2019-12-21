using Books.BL.Interfaces.Serializers;
using Books.WebApp.Interfaces.Builders;
using Books.WebApp.ViewModels;

namespace Books.WebApp.Code.Builders
{
	public class HomeViewModelBuilder : IHomeViewModelBuilder
	{
		private readonly IAppConfigViewModelBuilder _appConfigViewModelBuilder;
		private readonly ISerializer _serializer;

		public HomeViewModelBuilder(IAppConfigViewModelBuilder appConfigViewModelBuilder, ISerializer serializer)
		{
			_appConfigViewModelBuilder = appConfigViewModelBuilder;
			_serializer = serializer;
		}

		public HomeViewModel Build()
		{
			var appConfigViewModel = _appConfigViewModelBuilder.Build();
			var appConfigData = _serializer.Serialize(appConfigViewModel);

			return new HomeViewModel
			{
				AppConfigData = appConfigData
			};
		}
	}
}