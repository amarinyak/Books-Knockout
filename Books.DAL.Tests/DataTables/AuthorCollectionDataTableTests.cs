using System.Linq;
using AutoFixture;
using Books.DAL.DataTables;
using Books.DAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.DAL.Tests.DataTables
{
    [TestClass]
    public class AuthorCollectionDataTableTests
    {
        private Fixture _fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            _fixture = new Fixture();
        }

        [TestMethod]
        public void Init()
        {
            // Arrange
            var authors = _fixture.CreateMany<AuthorDb>().ToList();

            // Act
            var result = AuthorCollectionDataTable.Init(authors);

            // Assert
            Assert.AreEqual(authors.Count, result.Rows.Count);

            foreach (var (author, i) in authors.Select((value, i) => (value, i)))
            {
                var items = result.Rows[i].ItemArray;

                Assert.AreEqual(4, items.Length);

                Assert.AreEqual(author.Id, items[0]);
                Assert.AreEqual(author.BookId, items[1]);
                Assert.AreEqual(author.FirstName, items[2]);
                Assert.AreEqual(author.LastName, items[3]);
            }
        }
    }
}
