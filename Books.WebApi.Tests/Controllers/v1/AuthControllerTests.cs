using System;
using System.Threading.Tasks;
using AutoFixture;
using Books.BL.Interfaces.Services;
using Books.WebApi.Controllers.v1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Books.WebApi.Tests.Controllers.v1
{
    [TestClass]
    public class AuthControllerTests
    {
        private Fixture _fixture;
        private Mock<ITokenProvider> _tokenProvider;
        private Mock<IBookCreator> _bookCreator;
        private AuthController _target;

        [TestInitialize]
        public void TestInitialize()
        {
            _fixture = new Fixture();

            _tokenProvider = new Mock<ITokenProvider>(MockBehavior.Strict);
            _bookCreator = new Mock<IBookCreator>(MockBehavior.Strict);

            _target = new AuthController(_tokenProvider.Object, _bookCreator.Object);
        }

        [TestMethod]
        public async Task GetToken()
        {
            // Arrange
            var token = _fixture.Create<Guid>();
            _tokenProvider.Setup(p => p.Create())
                .Returns(token);
            _bookCreator.Setup(p => p.CreateDefaultBooks(token))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _target.GetToken();

            // Assert
            Assert.AreEqual(token, result);
            _tokenProvider.Verify(p => p.Create(), Times.Once);
            _bookCreator.Verify(p => p.CreateDefaultBooks(token), Times.Once);
        }
    }
}
