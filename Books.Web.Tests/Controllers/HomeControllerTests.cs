using System.Web.Mvc;
using AutoFixture;
using Books.Web.Controllers;
using Books.Web.ViewModels;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.Web.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTests
	{
		private Fixture _fixture;
		private HomeController _target;

		[TestInitialize]
		public void TestInitialize()
		{
			_fixture = new Fixture();
			_target = new HomeController();
		}

		[TestMethod]
		public void Index()
		{
			// Arrange
			var sortField = _fixture.Create<string>();
			var descSort = _fixture.Create<bool>();
			
			var expected = new HomeViewModel
			{
				Sort = new SortViewModel
				{
					SortField = sortField,
					DescSort = descSort
				}
			};

			// Act
			var result = _target.Index(sortField, descSort) as ViewResult;
			
			// Assert
			Assert.IsNotNull(result);
			result.Model.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void Index_Default()
		{
			// Act
			var result = _target.Index() as ViewResult;
			
			var expected = new HomeViewModel
			{
				Sort = new SortViewModel
				{
					SortField = "title",
					DescSort = false
				}
			};

			// Assert
			Assert.IsNotNull(result);

			result.Model.Should().BeEquivalentTo(expected);
		}
	}
}
