using System.Data;
using Books.DAL.Interfaces.Common;
using Books.DAL.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Books.DAL.Tests.UnitOfWork
{
	[TestClass]
	public class UnitOfWorkFactoryTests
	{
		private Mock<IDbConnection> _connection;
		private Mock<IDbTransaction> _transaction;
		private Mock<IDbConnectionFactory> _connectionFactory;
		private UnitOfWorkFactory _target;

		[TestInitialize]
		public void TestInitialize()
		{
			_connection = new Mock<IDbConnection>(MockBehavior.Strict);
			_transaction = new Mock<IDbTransaction>(MockBehavior.Strict);
			_connectionFactory = new Mock<IDbConnectionFactory>(MockBehavior.Strict);
			_target = new UnitOfWorkFactory(_connectionFactory.Object);
		}

		[TestMethod]
		public void Create_WithoutTransaction()
		{
			// Arrange
			_connection.Setup(p => p.Open());
			_connectionFactory.Setup(p => p.Create()).Returns(_connection.Object);

			// Act
			var result = _target.Create();

			// Assert
			Assert.IsNotNull(result);

			_connection.Verify(p => p.Open(), Times.Once);
			_connectionFactory.Verify(p => p.Create(), Times.Once);
		}

		[TestMethod]
		public void Create_WithTransaction()
		{
			// Arrange
			_connection.Setup(p => p.Open());
			_connection.Setup(p => p.BeginTransaction()).Returns(_transaction.Object);
			_connectionFactory.Setup(p => p.Create()).Returns(_connection.Object);

			// Act
			var result = _target.Create(true);

			// Assert
			Assert.IsNotNull(result);

			_connection.Verify(p => p.Open(), Times.Once);
			_connection.Verify(p => p.BeginTransaction(), Times.Once);
			_connectionFactory.Verify(p => p.Create(), Times.Once);
		}
	}
}
