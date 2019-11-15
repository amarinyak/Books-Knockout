using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Books.BL.Interfaces.Mappers;
using Books.BL.Mappers;
using Books.BL.Models;
using Books.DAL.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Books.BL.Tests.Mappers
{
	[TestClass]
	public class BookMapperTests
	{
		private Fixture _fixture;
		private Mock<IAuthorMapper> _authorMapper;
		private BookMapper _target;

		[TestInitialize]
		public void TestInitialize()
		{
			_fixture = new Fixture();

			_authorMapper = new Mock<IAuthorMapper>(MockBehavior.Strict);

			_target = new BookMapper(_authorMapper.Object);
		}

		[TestMethod]
		public void ToDataModel()
		{
			// Arrange
			var authorsDb = _fixture.CreateMany<AuthorDb>().ToList();
			var book = _fixture.Create<Book>();

			_authorMapper.Setup(p => p.ToDataModel(book.Authors, book.Id))
				.Returns(authorsDb);

			var expected = new BookDb
			{
				Id = book.Id,
				Title = book.Title,
				PageCount = book.PageCount,
				Publisher = book.Publisher,
				Year = book.Year,
				Isbn = book.Isbn,
				Image = book.Image,
				CreateDate = book.CreateDate,
				EditDate = book.EditDate,
				Authors = authorsDb
			};

			// Act
			var result = _target.ToDataModel(book);

			// Assert
			result.Should().BeEquivalentTo(expected);

			_authorMapper.Verify(p => p.ToDataModel(book.Authors, book.Id), Times.Once);
		}

		[TestMethod]
		public void ToDataModel_WithoutIdAndWithoutAuthors()
		{
			// Arrange
			var bookId = _fixture.Create<Guid>();
			var book = _fixture.Build<Book>()
				.With(p => p.Id, bookId)
				.Without(p => p.Authors)
				.Create();

			_authorMapper.Setup(p => p.ToDataModel(book.Authors, bookId))
				.Returns((IEnumerable<AuthorDb>)null);

			var expected = new BookDb
			{
				Title = book.Title,
				PageCount = book.PageCount,
				Publisher = book.Publisher,
				Year = book.Year,
				Isbn = book.Isbn,
				Image = book.Image,
				CreateDate = book.CreateDate,
				EditDate = book.EditDate,
				Authors = null
			};

			// Act
			var result = _target.ToDataModel(book);

			// Assert
			Assert.AreNotEqual(Guid.Empty, result.Id);

			expected.Id = result.Id;
			result.Should().BeEquivalentTo(expected);

			_authorMapper.Verify(p => p.ToDataModel(book.Authors, book.Id), Times.Once);
		}

		[TestMethod]
		public void ToDataModel_Collection()
		{
			// Arrange
			var expected = new List<BookDb>();

			var books = _fixture.CreateMany<Book>().ToList();

			foreach (var book in books)
			{
				var authorsDb = _fixture.CreateMany<AuthorDb>().ToList();

				_authorMapper.Setup(p => p.ToDataModel(book.Authors, book.Id))
					.Returns(authorsDb);

				expected.Add(new BookDb
				{
					Id = book.Id,
					Title = book.Title,
					PageCount = book.PageCount,
					Publisher = book.Publisher,
					Year = book.Year,
					Isbn = book.Isbn,
					Image = book.Image,
					CreateDate = book.CreateDate,
					EditDate = book.EditDate,
					Authors = authorsDb
				});
			}
			
			// Act
			var result = _target.ToDataModel(books);

			// Assert
			result.Should().BeEquivalentTo(expected);

			foreach (var book in books)
			{
				_authorMapper.Verify(p => p.ToDataModel(book.Authors, book.Id), Times.Once);
			}
		}

		[TestMethod]
		public void ToDataModel_NullCollection()
		{
			// Act
			var result = _target.ToDataModel((IEnumerable<Book>)null);

			// Assert
			result.Should().BeEquivalentTo(null);
		}

		[TestMethod]
		public void ToDomainModel()
		{
			// Arrange
			var authors = _fixture.CreateMany<Author>().ToList();
			var bookDb = _fixture.Create<BookDb>();

			_authorMapper.Setup(p => p.ToDomainModel(bookDb.Authors))
				.Returns(authors);

			var expected = new Book
			{
				Id = bookDb.Id,
				Title = bookDb.Title,
				PageCount = bookDb.PageCount,
				Publisher = bookDb.Publisher,
				Year = bookDb.Year,
				Isbn = bookDb.Isbn,
				Image = bookDb.Image,
				CreateDate = bookDb.CreateDate,
				EditDate = bookDb.EditDate,
				Authors = authors
			};

			// Act
			var result = _target.ToDomainModel(bookDb);

			// Assert
			result.Should().BeEquivalentTo(expected);

			_authorMapper.Verify(p => p.ToDomainModel(bookDb.Authors), Times.Once);
		}

		[TestMethod]
		public void ToDomainModel_WithoutAuthors()
		{
			// Arrange
			var bookDb = _fixture.Build<BookDb>()
				.Without(p => p.Authors)
				.Create();

			_authorMapper.Setup(p => p.ToDomainModel(bookDb.Authors))
				.Returns((IEnumerable<Author>)null);

			var expected = new Book
			{
				Id = bookDb.Id,
				Title = bookDb.Title,
				PageCount = bookDb.PageCount,
				Publisher = bookDb.Publisher,
				Year = bookDb.Year,
				Isbn = bookDb.Isbn,
				Image = bookDb.Image,
				CreateDate = bookDb.CreateDate,
				EditDate = bookDb.EditDate,
				Authors = null
			};

			// Act
			var result = _target.ToDomainModel(bookDb);

			// Assert
			result.Should().BeEquivalentTo(expected);

			_authorMapper.Verify(p => p.ToDomainModel(bookDb.Authors), Times.Once);
		}

		[TestMethod]
		public void ToDomainModel_Collection()
		{
			// Arrange
			var expected = new List<Book>();

			var booksDb = _fixture.CreateMany<BookDb>().ToList();

			foreach (var bookDb in booksDb)
			{
				var authors = _fixture.CreateMany<Author>().ToList();

				_authorMapper.Setup(p => p.ToDomainModel(bookDb.Authors))
					.Returns(authors);

				expected.Add(new Book
				{
					Id = bookDb.Id,
					Title = bookDb.Title,
					PageCount = bookDb.PageCount,
					Publisher = bookDb.Publisher,
					Year = bookDb.Year,
					Isbn = bookDb.Isbn,
					Image = bookDb.Image,
					CreateDate = bookDb.CreateDate,
					EditDate = bookDb.EditDate,
					Authors = authors
				});
			}
			
			// Act
			var result = _target.ToDomainModel(booksDb);

			// Assert
			result.Should().BeEquivalentTo(expected);

			foreach (var bookDb in booksDb)
			{
				_authorMapper.Verify(p => p.ToDomainModel(bookDb.Authors), Times.Once);
			}
		}

		[TestMethod]
		public void ToDomainModel_NullCollection()
		{
			// Act
			var result = _target.ToDomainModel((IEnumerable<BookDb>)null);

			// Assert
			result.Should().BeEquivalentTo(null);
		}
	}
}
