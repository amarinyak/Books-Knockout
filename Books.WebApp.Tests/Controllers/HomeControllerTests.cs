using System.Web.Mvc;
using AutoFixture;
using Books.WebApp.Controllers;
using Books.WebApp.Interfaces.Builders;
using Books.WebApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Books.WebApp.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTests
	{
		private Fixture _fixture;
		private Mock<IHomeViewModelBuilder> _homeViewModelBuilder;
		private HomeController _target;

		[TestInitialize]
		public void TestInitialize()
		{
			_fixture = new Fixture();

			_homeViewModelBuilder = new Mock<IHomeViewModelBuilder>(MockBehavior.Strict);

			_target = new HomeController(_homeViewModelBuilder.Object);
		}

		[TestMethod]
		public void Index()
		{
			// Arrange
			var homeViewModel = _fixture.Create<HomeViewModel>();

			_homeViewModelBuilder.Setup(p => p.Build())
				.Returns(homeViewModel);

			// Act
			var result = _target.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(homeViewModel, result.Model);

			_homeViewModelBuilder.Verify(p => p.Build(), Times.Once);
		}
	}
}
