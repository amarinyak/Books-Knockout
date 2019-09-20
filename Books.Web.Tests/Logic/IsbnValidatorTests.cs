using Books.Web.Logic.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.Web.Tests.Logic
{
    [TestClass]
    public class IsbnValidatorTests
    {
        [TestMethod]
        public void IsValidTest()
        {
            string errorMessage1;
            var result1 = IsbnValidator.IsValid("978-5-17-083741-0", out errorMessage1);

            string errorMessage2;
            var result2 = IsbnValidator.IsValid("978-5-389-09475-8", out errorMessage2);

            string errorMessage3;
            var result3 = IsbnValidator.IsValid("978-5-389-09475-9", out errorMessage3);

            string errorMessage4;
            var result4 = IsbnValidator.IsValid("978-5-389-09475-89", out errorMessage4);

            Assert.IsTrue(result1);
            Assert.AreEqual(string.Empty, errorMessage1);

            Assert.IsTrue(result2);
            Assert.AreEqual(string.Empty, errorMessage2);

            Assert.IsFalse(result3);
            Assert.AreEqual("Неправильный номер ISBN", errorMessage3);

            Assert.IsFalse(result4);
            Assert.AreEqual("Неправильный номер ISBN", errorMessage4);
        }
    }
}
