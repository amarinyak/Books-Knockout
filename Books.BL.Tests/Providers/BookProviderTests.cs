using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Books.BL.Interfaces.Mappers;
using Books.BL.Models;
using Books.BL.Services;
using Books.DAL.Interfaces.UnitOfWork;
using Books.DAL.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Books.BL.Tests.Providers
{
	[TestClass]
	public class BookProviderTests
	{
		private Fixture _fixture;
		private Mock<IUnitOfWork> _uow;
		private Mock<IUnitOfWorkFactory> _uowFactory;
		private Mock<IBookMapper> _bookMapper;
		private BookProvider _target;
		
		[TestInitialize]
		public void TestInitialize()
		{
			_fixture = new Fixture();

			_uow = new Mock<IUnitOfWork>(MockBehavior.Strict);
			_uowFactory = new Mock<IUnitOfWorkFactory>(MockBehavior.Strict);
			_bookMapper = new Mock<IBookMapper>(MockBehavior.Strict);

			_target = new BookProvider(_uowFactory.Object, _bookMapper.Object);
		}

		[TestMethod]
		public async Task GetByToken()
		{
			// Arrange
			var token = _fixture.Create<Guid>();
			var books = _fixture.CreateMany<Book>().ToList();
			var booksDb = _fixture.CreateMany<BookDb>().ToList();

			_uowFactory.Setup(p => p.Create(false))
				.Returns(_uow.Object);
			_uow.Setup(p => p.Dispose());
			_uow.Setup(p => p.BookRepository.GetByToken(token))
				.Returns(Task.FromResult<IEnumerable<BookDb>>(booksDb));
			_bookMapper.Setup(p => p.ToDomainModel(booksDb))
				.Returns(books);

			// Act
			var result = await _target.GetByToken(token);

			// Assert
			result.Should().BeEquivalentTo(books);

			_uowFactory.Verify(p => p.Create(false), Times.Once);
			_uow.Verify(p => p.BookRepository.GetByToken(token), Times.Once);
			_uow.Verify(p => p.Dispose(), Times.Once);
			_bookMapper.Verify(p => p.ToDomainModel(booksDb), Times.Once);
		}

		[TestMethod]
		public async Task GetById()
		{
			// Arrange
			var token = _fixture.Create<Guid>();
			var book = _fixture.Create<Book>();
			var bookDb = _fixture.Create<BookDb>();

			_uowFactory.Setup(p => p.Create(false))
				.Returns(_uow.Object);
			_uow.Setup(p => p.Dispose());
			_uow.Setup(p => p.BookRepository.GetById(book.Id, token))
				.Returns(Task.FromResult(bookDb));
			_bookMapper.Setup(p => p.ToDomainModel(bookDb))
				.Returns(book);

			// Act
			var result = await _target.GetById(book.Id, token);

			// Assert
			result.Should().BeEquivalentTo(book);

			_uowFactory.Verify(p => p.Create(false), Times.Once);
			_uow.Verify(p => p.BookRepository.GetById(book.Id, token), Times.Once);
			_uow.Verify(p => p.Dispose(), Times.Once);
			_bookMapper.Verify(p => p.ToDomainModel(bookDb), Times.Once);
		}

		[TestMethod]
		public async Task Delete()
		{
			// Arrange
			var token = _fixture.Create<Guid>();
			var bookId = _fixture.Create<Guid>();

			_uowFactory.Setup(p => p.Create(true))
				.Returns(_uow.Object);
			_uow.Setup(p => p.Dispose());
			_uow.Setup(p => p.AuthorRepository.DeleteByBookId(bookId))
				.Returns(Task.FromResult(1));
			_uow.Setup(p => p.BookRepository.Delete(bookId, token))
				.Returns(Task.FromResult(1));
			_uow.Setup(p => p.Commit());

			// Act
			await _target.Delete(bookId, token);

			// Assert
			_uowFactory.Verify(p => p.Create(true), Times.Once);
			_uow.Verify(p => p.AuthorRepository.DeleteByBookId(bookId), Times.Once);
			_uow.Verify(p => p.BookRepository.Delete(bookId, token), Times.Once);
			_uow.Verify(p => p.Commit(), Times.Once);
			_uow.Verify(p => p.Dispose(), Times.Once);
		}

		[TestMethod]
		public async Task Create()
		{
			// Arrange
			var book = _fixture.Create<Book>();
			var bookDb = _fixture.Create<BookDb>();

			_uowFactory.Setup(p => p.Create(true))
				.Returns(_uow.Object);
			_uow.Setup(p => p.Dispose());
			_uow.Setup(p => p.BookRepository.Add(bookDb))
				.Returns(Task.FromResult(1));
			_uow.Setup(p => p.AuthorRepository.Merge(bookDb.Authors))
				.Returns(Task.FromResult(bookDb.Authors.Count));
			_uow.Setup(p => p.Commit());
			_bookMapper.Setup(p => p.ToDataModel(book))
				.Returns(bookDb);

			// Act
			var result = await _target.Create(book);

			// Assert
			Assert.AreEqual(bookDb.Id , result);

			_uowFactory.Verify(p => p.Create(true), Times.Once);
			_uow.Verify(p => p.BookRepository.Add(bookDb), Times.Once);
			_uow.Verify(p => p.AuthorRepository.Merge(bookDb.Authors), Times.Once);
			_uow.Verify(p => p.Commit(), Times.Once);
			_uow.Verify(p => p.Dispose(), Times.Once);
			_bookMapper.Verify(p => p.ToDataModel(book), Times.Once);
		}

		[TestMethod]
		public async Task Update()
		{
			// Arrange
			var book = _fixture.Create<Book>();
			var bookDb = _fixture.Create<BookDb>();

			_uowFactory.Setup(p => p.Create(true))
				.Returns(_uow.Object);
			_uow.Setup(p => p.Dispose());
			_uow.Setup(p => p.BookRepository.Update(bookDb))
				.Returns(Task.FromResult(1));
			_uow.Setup(p => p.AuthorRepository.Merge(bookDb.Authors))
				.Returns(Task.FromResult(bookDb.Authors.Count));
			_uow.Setup(p => p.Commit());
			_bookMapper.Setup(p => p.ToDataModel(book))
				.Returns(bookDb);

			// Act
			await _target.Update(book);

			// Assert
			Assert.AreNotEqual(DateTime.MinValue, bookDb.EditDate);

			_uowFactory.Verify(p => p.Create(true), Times.Once);
			_uow.Verify(p => p.BookRepository.Update(bookDb), Times.Once);
			_uow.Verify(p => p.AuthorRepository.Merge(bookDb.Authors), Times.Once);
			_uow.Verify(p => p.Commit(), Times.Once);
			_uow.Verify(p => p.Dispose(), Times.Once);
			_bookMapper.Verify(p => p.ToDataModel(book), Times.Once);
		}
	}
}
