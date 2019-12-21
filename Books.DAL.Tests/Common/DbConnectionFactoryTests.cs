using System.Data.SqlClient;
using AutoFixture;
using Books.DAL.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.DAL.Tests.Common
{
	[TestClass]
	public class DbConnectionFactoryTests
	{
		private Fixture _fixture;
		private DbConnectionFactory _target;

		[TestInitialize]
		public void TestInitialize()
		{
			_fixture = new Fixture();

			var csBuilder = new SqlConnectionStringBuilder
			{
				["Data Source"] = _fixture.Create<string>(),
				["Initial Catalog"] = _fixture.Create<string>(),
				["User ID"] = _fixture.Create<string>(),
				["Password"] = _fixture.Create<string>(),
				["Connect Timeout"] = _fixture.Create<int>()
			};

			_target = new DbConnectionFactory(csBuilder.ConnectionString);
		}

		[TestMethod]
		public void Create()
		{
			// Act
			var result = _target.Create();

			// Assert
			Assert.IsNotNull(result);
		}
	}
}
