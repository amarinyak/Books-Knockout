using AutoFixture;
using Books.BL.Interfaces.Serializers;
using Books.WebApp.Code.Builders;
using Books.WebApp.Interfaces.Builders;
using Books.WebApp.ViewModels;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Books.WebApp.Tests.Code.Builders
{
	[TestClass]
	public class HomeViewModelBuilderTests
	{
		private Fixture _fixture;
		private Mock<IAppConfigViewModelBuilder> _appConfigViewModelBuilder;
		private Mock<ISerializer> _serializer;
		private HomeViewModelBuilder _target;

		[TestInitialize]
		public void TestInitialize()
		{
			_fixture = new Fixture();

			_appConfigViewModelBuilder = new Mock<IAppConfigViewModelBuilder>(MockBehavior.Strict);
			_serializer = new Mock<ISerializer>(MockBehavior.Strict);

			_target = new HomeViewModelBuilder(_appConfigViewModelBuilder.Object, _serializer.Object);
		}

		[TestMethod]
		public void Build()
		{
			// Arrange
			var appConfigViewModel = _fixture.Create<AppConfigViewModel>();
			var appConfigData = _fixture.Create<string>();

			_appConfigViewModelBuilder.Setup(p => p.Build())
				.Returns(appConfigViewModel);
			_serializer.Setup(p => p.Serialize(appConfigViewModel))
				.Returns(appConfigData);

			var expected = new HomeViewModel
			{
				AppConfigData = appConfigData
			};

			// Act
			var result = _target.Build();

			// Assert
			result.Should().BeEquivalentTo(expected);

			_appConfigViewModelBuilder.Verify(p => p.Build(), Times.Once);
			_serializer.Verify(p => p.Serialize(appConfigViewModel), Times.Once);
		}
	}
}
