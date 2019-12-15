using System;
using System.Net.Http;
using AutoFixture;
using Books.BL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.BL.Tests.Services
{
    [TestClass]
    public class TokenProviderTests
    {
        private Fixture _fixture;
        private string _authTokenKey;
        private TokenProvider _target;

        [TestInitialize]
        public void TestInitialize()
        {
            _fixture = new Fixture();
            _authTokenKey = _fixture.Create<string>();
            _target = new TokenProvider(_authTokenKey);
        }

        [TestMethod]
        public void Create()
        {
            // Act
            var result = _target.Create();

            // Assert
            Assert.IsTrue(result != Guid.Empty);
        }

        [TestMethod]
        public void SetToken()
        {
            // Arrange
            var token = _fixture.Create<Guid>();
            var httpRequestMessage = new HttpRequestMessage();

            // Act
            _target.SetToken(httpRequestMessage, token);

            // Arrange
            Assert.AreEqual(1, httpRequestMessage.Properties.Count);
            Assert.AreEqual(token, httpRequestMessage.Properties[_authTokenKey]);
        }

        [TestMethod]
        public void GetToken()
        {
            // Arrange
            var token = _fixture.Create<Guid>();
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Properties.Add(_authTokenKey, token);

            // Act
            var result = _target.GetToken(httpRequestMessage);

            // Arrange
            Assert.AreEqual(token, result);
        }
    }
}
