using System.Web.Mvc;
using Books.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.Web.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTests
	{
		private HomeController _target;

		[TestInitialize]
		public void TestInitialize()
		{
			_target = new HomeController();
		}

		[TestMethod]
		public void Index()
		{
			// Act
			var result = _target.Index() as ViewResult;
			
			// Assert
			Assert.IsNotNull(result);
		}
	}
}
