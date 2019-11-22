using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Books.BL.Models;
using Books.Web.Code.Mappers;
using Books.Web.Interfaces.Mappers;
using Books.Web.ViewModels.API;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Books.Web.Tests.Code.Mappers
{
	[TestClass]
	public class BookViewModelMapperTests
	{
		private Fixture _fixture;
		private Mock<IAuthorViewModelMapper> _authorViewModelMapper;
		private BookViewModelMapper _target;

		[TestInitialize]
		public void TestInitialize()
		{
			_fixture = new Fixture();

			_authorViewModelMapper = new Mock<IAuthorViewModelMapper>();

			_target = new BookViewModelMapper(_authorViewModelMapper.Object);
		}

		[TestMethod]
		public void ToDomainModel()
		{
			// Arrange
			var bookVm = _fixture.Create<BookViewModel>();
			var authors = _fixture.CreateMany<Author>().ToList();

			_authorViewModelMapper.Setup(p => p.ToDomainModel(bookVm.Authors))
				.Returns(authors);

			var expected = new Book
			{
				Id = bookVm.Id,
				Title = bookVm.Title,
				PageCount = bookVm.PageCount,
				Publisher = bookVm.Publisher,
				Year = bookVm.Year,
				Isbn = bookVm.Isbn,
				Image = bookVm.Image,
				CreateDate = bookVm.CreateDate,
				EditDate = bookVm.EditDate,
				Authors = authors
			};

			// Act
			var result = _target.ToDomainModel(bookVm);

			// Assert
			result.Should().BeEquivalentTo(expected);

			_authorViewModelMapper.Verify(p => p.ToDomainModel(bookVm.Authors), Times.Once);
		}

		[TestMethod]
		public void ToDomainModel_WithoutAuthors()
		{
			// Arrange
			var bookVm = _fixture.Build<BookViewModel>()
				.Without(p => p.Authors)
				.Create();

			_authorViewModelMapper.Setup(p => p.ToDomainModel(bookVm.Authors))
				.Returns((IEnumerable<Author>)null);

			var expected = new Book
			{
				Id = bookVm.Id,
				Title = bookVm.Title,
				PageCount = bookVm.PageCount,
				Publisher = bookVm.Publisher,
				Year = bookVm.Year,
				Isbn = bookVm.Isbn,
				Image = bookVm.Image,
				CreateDate = bookVm.CreateDate,
				EditDate = bookVm.EditDate,
				Authors = null
			};

			// Act
			var result = _target.ToDomainModel(bookVm);

			// Assert
			result.Should().BeEquivalentTo(expected);

			_authorViewModelMapper.Verify(p => p.ToDomainModel(bookVm.Authors), Times.Once);
		}

		[TestMethod]
		public void ToDomainModel_Collection()
		{
			// Arrange
			var expected = new List<Book>();

			var booksVm = _fixture.CreateMany<BookViewModel>().ToList();

			foreach (var bookVm in booksVm)
			{
				var authors = _fixture.CreateMany<Author>().ToList();

				_authorViewModelMapper.Setup(p => p.ToDomainModel(bookVm.Authors))
					.Returns(authors);

				expected.Add(new Book
				{
					Id = bookVm.Id,
					Title = bookVm.Title,
					PageCount = bookVm.PageCount,
					Publisher = bookVm.Publisher,
					Year = bookVm.Year,
					Isbn = bookVm.Isbn,
					Image = bookVm.Image,
					CreateDate = bookVm.CreateDate,
					EditDate = bookVm.EditDate,
					Authors = authors
				});
			}
			
			// Act
			var result = _target.ToDomainModel(booksVm);

			// Assert
			result.Should().BeEquivalentTo(expected);

			foreach (var bookVm in booksVm)
			{
				_authorViewModelMapper.Verify(p => p.ToDomainModel(bookVm.Authors), Times.Once);
			}
		}

		[TestMethod]
		public void ToDomainModel_NullCollection()
		{
			// Act
			var result = _target.ToDomainModel((IEnumerable<BookViewModel>)null);

			// Assert
			result.Should().BeEquivalentTo(null);
		}

		[TestMethod]
		public void ToViewModel()
		{
			// Arrange
			var book = _fixture.Create<Book>();
			var authorsVm = _fixture.CreateMany<AuthorViewModel>().ToList();

			_authorViewModelMapper.Setup(p => p.ToViewModel(book.Authors))
				.Returns(authorsVm);

			var expected = new BookViewModel
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
				Authors = authorsVm
			};

			// Act
			var result = _target.ToViewModel(book);

			// Assert
			result.Should().BeEquivalentTo(expected);

			_authorViewModelMapper.Verify(p => p.ToViewModel(book.Authors), Times.Once);
		}

		[TestMethod]
		public void ToViewModel_WithoutAuthors()
		{
			// Arrange
			var book = _fixture.Build<Book>()
				.Without(p => p.Authors)
				.Create();

			_authorViewModelMapper.Setup(p => p.ToViewModel(book.Authors))
				.Returns((IEnumerable<AuthorViewModel>)null);

			var expected = new Book
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
				Authors = null
			};

			// Act
			var result = _target.ToViewModel(book);

			// Assert
			result.Should().BeEquivalentTo(expected);

			_authorViewModelMapper.Verify(p => p.ToViewModel(book.Authors), Times.Once);
		}

		[TestMethod]
		public void ToViewModel_Collection()
		{
			// Arrange
			var expected = new List<BookViewModel>();

			var books = _fixture.CreateMany<Book>().ToList();

			foreach (var book in books)
			{
				var authorsVm = _fixture.CreateMany<AuthorViewModel>().ToList();

				_authorViewModelMapper.Setup(p => p.ToViewModel(book.Authors))
					.Returns(authorsVm);

				expected.Add(new BookViewModel()
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
					Authors = authorsVm
				});
			}
			
			// Act
			var result = _target.ToViewModel(books);

			// Assert
			result.Should().BeEquivalentTo(expected);

			foreach (var book in books)
			{
				_authorViewModelMapper.Verify(p => p.ToViewModel(book.Authors), Times.Once);
			}
		}

		[TestMethod]
		public void ToViewModel_NullCollection()
		{
			// Act
			var result = _target.ToViewModel((IEnumerable<Book>)null);

			// Assert
			result.Should().BeEquivalentTo(null);
		}
	}
}
