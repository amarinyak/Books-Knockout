using Books.BL.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.BL.Tests.Validation
{
    [TestClass]
    public class IsbnValidatorTests
    {
        private IsbnValidator _target;

        [TestInitialize]
        public void TestInitialize()
        {
            _target = new IsbnValidator();
        }

        [TestMethod]
        public void IsValid()
        {
            // Arrange
            const string value = "978-5389094758";

            // Act
            var result = _target.IsValid(value, out var errorMessage);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
        }

        [TestMethod]
        public void IsValid_Null()
        {
            // Act
            var result = _target.IsValid(null, out var errorMessage);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
        }

        [TestMethod]
        public void IsValid_Empty()
        {
            // Act
            var result = _target.IsValid(string.Empty, out var errorMessage);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
        }

        [TestMethod]
        public void IsValid_IncorrectLength()
        {
            // Arrange
            const string value = "978-53890947591";

            // Act
            var result = _target.IsValid(value, out var errorMessage);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual("Incorrect ISBN number", errorMessage);
        }

        [TestMethod]
        public void IsValid_IncorrectRegex()
        {
            // Arrange
            const string value = "978_5389094759";

            // Act
            var result = _target.IsValid(value, out var errorMessage);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual("Incorrect ISBN number", errorMessage);
        }

        [TestMethod]
        public void IsValid_IncorrectDigit()
        {
            // Arrange
            const string value = "978-5389094759";

            // Act
            var result = _target.IsValid(value, out var errorMessage);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual("Incorrect ISBN number", errorMessage);
        }
    }
}
