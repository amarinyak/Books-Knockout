using AutoFixture;
using Books.WebApp.Code.Builders;
using Books.WebApp.Configuration;
using Books.WebApp.ViewModels;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.WebApp.Tests.Code.Builders
{
	[TestClass]
	public class AppConfigViewModelBuilderTests
	{
		private Fixture _fixture;
		private AppConfigSettings _settings;
		private AppConfigViewModelBuilder _target;

		[TestInitialize]
		public void TestInitialize()
		{
			_fixture = new Fixture();
			_settings = _fixture.Create<AppConfigSettings>();
			_target = new AppConfigViewModelBuilder(_settings);
		}

		[TestMethod]
		public void Build()
		{
			// Arrange
			var expected = new AppConfigViewModel
			{
				WebApiUrl = _settings.WebApiUrl,
				DefaultSortOrder = _settings.DefaultSortOrder,
				DefaultDescSort = _settings.DefaultDescSort
			};

			// Act
			var result = _target.Build();

			// Assert
			result.Should().BeEquivalentTo(expected);
		}
	}
}
