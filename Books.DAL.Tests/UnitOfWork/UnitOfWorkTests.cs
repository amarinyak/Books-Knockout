using System;
using System.Data;
using AutoFixture;
using Books.DAL.Interfaces.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Books.DAL.Tests.UnitOfWork
{
    [TestClass]
    public class UnitOfWorkTests
    {
        private Fixture _fixture;
        private Mock<IDbConnection> _connection;
        private Mock<IDbTransaction> _transaction;

        [TestInitialize]
        public void TestInitialize()
        {
            _fixture = new Fixture();
            _transaction = new Mock<IDbTransaction>(MockBehavior.Strict);
            _connection = new Mock<IDbConnection>(MockBehavior.Strict);
        }

        [TestMethod]
        public void Commit_WithoutTransaction()
        {
            // Arrange
            _connection.Setup(p => p.Open());
            _connection.Setup(p => p.Dispose());

            NullReferenceException expectedException = null;

            // Act
            using (var target = new DAL.UnitOfWork.UnitOfWork(_connection.Object, false))
            {
                try
                {
                    target.Commit();
                }
                catch (NullReferenceException e)
                {
                    expectedException = e;
                }
            }

            // Assert
            Assert.IsNotNull(expectedException);

            _connection.Verify(p => p.Open(), Times.Once);
            _connection.Verify(p => p.Dispose(), Times.Once);
        }

        [TestMethod]
        public void Commit_WithTransaction()
        {
            // Arrange
            _connection.Setup(p => p.BeginTransaction()).Returns(_transaction.Object);
            _connection.Setup(p => p.Open());
            _connection.Setup(p => p.Dispose());
            _transaction.Setup(p => p.Commit());
            _transaction.Setup(p => p.Dispose());

            // Act
            using (var target = new DAL.UnitOfWork.UnitOfWork(_connection.Object, true))
            {
                target.Commit();
            }

            // Assert
            _connection.Verify(p => p.BeginTransaction(), Times.Exactly(2));
            _connection.Verify(p => p.Open(), Times.Once);
            _connection.Verify(p => p.Dispose(), Times.Once);
            _transaction.Verify(p => p.Commit(), Times.Once);
            _transaction.Verify(p => p.Dispose(), Times.Exactly(2));
        }

        [TestMethod]
        public void Commit_WithTransactionAndException()
        {
            // Arrange
            var transactionException = _fixture.Create<Exception>();

            _connection.Setup(p => p.BeginTransaction()).Returns(_transaction.Object);
            _connection.Setup(p => p.Open());
            _connection.Setup(p => p.Dispose());
            _transaction.Setup(p => p.Commit()).Throws(transactionException);
            _transaction.Setup(p => p.Rollback());
            _transaction.Setup(p => p.Dispose());

            Exception expectedException = null;

            // Act
            using (var target = new DAL.UnitOfWork.UnitOfWork(_connection.Object, true))
            {
                try
                {
                    target.Commit();
                }
                catch (Exception e)
                {
                    expectedException = e;
                }
            }

            // Assert
            Assert.AreEqual(transactionException, expectedException);

            _connection.Verify(p => p.BeginTransaction(), Times.Exactly(2));
            _connection.Verify(p => p.Open(), Times.Once);
            _connection.Verify(p => p.Dispose(), Times.Once);
            _transaction.Verify(p => p.Commit(), Times.Once);
            _transaction.Verify(p => p.Rollback(), Times.Once);
            _transaction.Verify(p => p.Dispose(), Times.Exactly(2));
        }

        [TestMethod]
        public void AuthorRepository()
        {
            // Arrange
            _connection.Setup(p => p.Open());
            _connection.Setup(p => p.Dispose());

            IAuthorRepository authorRepository;

            // Act
            using (var target = new DAL.UnitOfWork.UnitOfWork(_connection.Object, false))
            {
                authorRepository = target.AuthorRepository;
            }

            // Assert
            Assert.IsNotNull(authorRepository);

            _connection.Verify(p => p.Open(), Times.Once);
            _connection.Verify(p => p.Dispose(), Times.Once);
        }

        [TestMethod]
        public void BookRepository()
        {
            // Arrange
            _connection.Setup(p => p.Open());
            _connection.Setup(p => p.Dispose());

            IBookRepository bookRepository;

            // Act
            using (var target = new DAL.UnitOfWork.UnitOfWork(_connection.Object, false))
            {
                bookRepository = target.BookRepository;
            }

            // Assert
            Assert.IsNotNull(bookRepository);

            _connection.Verify(p => p.Open(), Times.Once);
            _connection.Verify(p => p.Dispose(), Times.Once);
        }
    }
}
