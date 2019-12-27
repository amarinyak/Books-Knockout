using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Books.BL.Interfaces.Services;
using Books.BL.Models;
using Books.BL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Books.BL.Tests.Services
{
    [TestClass]
    public class BookCreatorTests
    {
        private Fixture _fixture;
        private Mock<IBookProvider> _bookProvider;
        private BookCreator _target;

        [TestInitialize]
        public void TestInitialize()
        {
            _fixture = new Fixture();

            _bookProvider = new Mock<IBookProvider>(MockBehavior.Strict);

            _target = new BookCreator(_bookProvider.Object);
        }

        [TestMethod]
        public async Task CreateDefaultBooks()
        {
            // Arrange
            var token = _fixture.Create<Guid>();
            _bookProvider.Setup(p => p.Create(It.Is<IEnumerable<Book>>(books => books.Count() == 3)))
                .Returns(Task.CompletedTask);

            // Act
            await _target.CreateDefaultBooks(token);

            // Assert
            _bookProvider.Verify(p => p.Create(It.Is<IEnumerable<Book>>(books => books.Count() == 3)), Times.Once);
        }
    }
}
