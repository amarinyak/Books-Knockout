using Books.Web.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.Web.Tests.Validation
{
    [TestClass]
    public class IsbnValidatorTests
    {
        [TestMethod]
        public void IsValidTest()
        {
	        var result1 = IsbnValidator.IsValid("978-5-17-083741-0", out var errorMessage1);

	        var result2 = IsbnValidator.IsValid("978-5-389-09475-8", out var errorMessage2);

	        var result3 = IsbnValidator.IsValid("978-5-389-09475-9", out var errorMessage3);

	        var result4 = IsbnValidator.IsValid("978-5-389-09475-89", out var errorMessage4);

            Assert.IsTrue(result1);
            Assert.AreEqual(string.Empty, errorMessage1);

            Assert.IsTrue(result2);
            Assert.AreEqual(string.Empty, errorMessage2);

            Assert.IsFalse(result3);
            Assert.AreEqual("Incorrect ISBN number", errorMessage3);

            Assert.IsFalse(result4);
            Assert.AreEqual("Incorrect ISBN number", errorMessage4);
        }
    }
}
