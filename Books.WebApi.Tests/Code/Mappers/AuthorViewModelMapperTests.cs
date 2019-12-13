using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Books.BL.Models;
using Books.WebApi.Code.Mappers;
using Books.WebApi.ViewModels;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.WebApi.Tests.Code.Mappers
{
	[TestClass]
	public class AuthorViewModelMapperTests
	{
		private Fixture _fixture;
		private AuthorViewModelMapper _target;

		[TestInitialize]
		public void TestInitialize()
		{
			_fixture = new Fixture();

			_target = new AuthorViewModelMapper();
		}

		[TestMethod]
		public void ToDomainModel()
		{
			// Arrange
			var authorVm = _fixture.Create<AuthorViewModel>();

			var expected = new Author
			{
				Id = authorVm.Id,
				FirstName = authorVm.FirstName,
				LastName = authorVm.LastName,
				BookId = authorVm.BookId
			};

			// Act
			var result = _target.ToDomainModel(authorVm);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void ToDomainModel_Collection()
		{
			// Arrange
			var authorsVm = _fixture.CreateMany<AuthorViewModel>().ToList();

			var expected = authorsVm.Select(authorVm => new Author
			{
				Id = authorVm.Id,
				FirstName = authorVm.FirstName,
				LastName = authorVm.LastName,
				BookId = authorVm.BookId
			});

			// Act
			var result = _target.ToDomainModel(authorsVm);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void ToDomainModel_NullCollection()
		{
			// Act
			var result = _target.ToDomainModel((IEnumerable<AuthorViewModel>)null);

			// Assert
			result.Should().BeEquivalentTo(null);
		}

		[TestMethod]
		public void ToViewModel()
		{
			// Arrange
			var author = _fixture.Create<Author>();

			var expected = new AuthorViewModel
			{
				Id = author.Id,
				FirstName = author.FirstName,
				LastName = author.LastName,
				BookId = author.BookId
			};

			// Act
			var result = _target.ToViewModel(author);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void ToViewModel_Collection()
		{
			// Arrange
			var authors = _fixture.CreateMany<Author>().ToList();

			var expected = authors.Select(author => new AuthorViewModel
			{
				Id = author.Id,
				FirstName = author.FirstName,
				LastName = author.LastName,
				BookId = author.BookId
			});

			// Act
			var result = _target.ToViewModel(authors);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void ToViewModel_NullCollection()
		{
			// Act
			var result = _target.ToViewModel((IEnumerable<Author>)null);

			// Assert
			result.Should().BeEquivalentTo(null);
		}
	}
}
