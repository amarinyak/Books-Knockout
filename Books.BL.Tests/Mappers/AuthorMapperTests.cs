using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Books.BL.Mappers;
using Books.BL.Models;
using Books.DAL.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.BL.Tests.Mappers
{
	[TestClass]
	public class AuthorMapperTests
	{
		private Fixture _fixture;
		private AuthorMapper _target;

		[TestInitialize]
		public void TestInitialize()
		{
			_fixture = new Fixture();

			_target = new AuthorMapper();
		}

		[TestMethod]
		public void ToDataModel()
		{
			// Arrange
			var bookId = _fixture.Create<Guid>();
			var author = _fixture.Create<Author>();

			var expected = new AuthorDb
			{
				Id = author.Id,
				FirstName = author.FirstName,
				LastName = author.LastName,
				BookId = author.BookId
			};

			// Act
			var result = _target.ToDataModel(author, bookId);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void ToDataModel_WithoutIdAndWithoutBookId()
		{
			// Arrange
			var bookId = _fixture.Create<Guid>();
			var author = _fixture.Build<Author>()
				.Without(p => p.Id)
				.Without(p => p.BookId)
				.Create();

			var expected = new AuthorDb
			{
				FirstName = author.FirstName,
				LastName = author.LastName,
				BookId = bookId
			};

			// Act
			var result = _target.ToDataModel(author, bookId);

			// Assert
			Assert.AreNotEqual(Guid.Empty, result.Id);

			expected.Id = result.Id;
			result.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void ToDataModel_Collection()
		{
			// Arrange
			var bookId = _fixture.Create<Guid>();
			var authors = _fixture.CreateMany<Author>().ToList();

			var expected = authors.Select(p => new AuthorDb
			{
				Id = p.Id,
				FirstName = p.FirstName,
				LastName = p.LastName,
				BookId = p.BookId
			});

			// Act
			var result = _target.ToDataModel(authors, bookId);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void ToDataModel_NullCollection()
		{
			// Arrange
			var bookId = _fixture.Create<Guid>();

			// Act
			var result = _target.ToDataModel((IEnumerable<Author>)null, bookId);

			// Assert
			result.Should().BeEquivalentTo(null);
		}

		[TestMethod]
		public void ToDomainModel()
		{
			// Arrange
			var authorDb = _fixture.Create<AuthorDb>();

			var expected = new Author
			{
				Id = authorDb.Id,
				FirstName = authorDb.FirstName,
				LastName = authorDb.LastName,
				BookId = authorDb.BookId
			};

			// Act
			var result = _target.ToDomainModel(authorDb);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void ToDomainModel_Collection()
		{
			// Arrange
			var authorsDb = _fixture.CreateMany<AuthorDb>().ToList();

			var expected = authorsDb.Select(p => new Author
			{
				Id = p.Id,
				FirstName = p.FirstName,
				LastName = p.LastName,
				BookId = p.BookId
			});

			// Act
			var result = _target.ToDomainModel(authorsDb);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void ToDomainModel_NullCollection()
		{
			// Act
			var result = _target.ToDomainModel((IEnumerable<AuthorDb>)null);

			// Assert
			result.Should().BeEquivalentTo(null);
		}
	}
}
