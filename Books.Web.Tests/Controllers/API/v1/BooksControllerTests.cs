using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Books.BL.Interfaces.Providers;
using Books.BL.Models;
using Books.Web.Controllers.API.v1;
using Books.Web.Interfaces.Mappers;
using Books.Web.ViewModels.API;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Books.Web.Tests.Controllers.API.v1
{
	[TestClass]
	public class BooksControllerTests
	{
		private Fixture _fixture;
		private BooksController _target;
		private Mock<IBookProvider> _bookProvider;
		private Mock<IBookViewModelMapper> _bookMapper;

		[TestInitialize]
		public void TestInitialize()
		{
			_fixture = new Fixture();

			_bookProvider = new Mock<IBookProvider>(MockBehavior.Strict);
			_bookMapper = new Mock<IBookViewModelMapper>(MockBehavior.Strict);

			_target = new BooksController(_bookProvider.Object, _bookMapper.Object);
		}

		[TestMethod]
		public async Task GetList()
		{
			// Arrange
			var books = _fixture.CreateMany<Book>().ToList();
			var booksVm = _fixture.CreateMany<BookViewModel>().ToList();

			_bookProvider.Setup(p => p.GetList()).Returns(Task.FromResult<IEnumerable<Book>>(books));
			_bookMapper.Setup(p => p.ToViewModel(books)).Returns(booksVm);

			// Act
			var result = await _target.GetList();

			// Assert
			result.Should().BeEquivalentTo(booksVm);

			_bookProvider.Verify(p => p.GetList(), Times.Once);
			_bookMapper.Verify(p => p.ToViewModel(books), Times.Once);
		}

		[TestMethod]
		public async Task GetById()
		{
			// Arrange
			var id = _fixture.Create<Guid>();
			var book = _fixture.Create<Book>();
			var bookVm = _fixture.Create<BookViewModel>();

			_bookProvider.Setup(p => p.GetById(id)).Returns(Task.FromResult(book));
			_bookMapper.Setup(p => p.ToViewModel(book)).Returns(bookVm);

			// Act
			var result = await _target.GetById(id);

			// Assert
			result.Should().BeEquivalentTo(bookVm);

			_bookProvider.Verify(p => p.GetById(id), Times.Once);
			_bookMapper.Verify(p => p.ToViewModel(book), Times.Once);
		}

		[TestMethod]
		public async Task Create()
		{
			// Arrange
			var id = _fixture.Create<Guid>();
			var book = _fixture.Create<Book>();
			var bookVm = _fixture.Build<BookViewModel>()
				.With(p => p.Id, Guid.Empty)
				.Create();

			_bookMapper.Setup(p => p.ToDomainModel(bookVm)).Returns(book);
			_bookProvider.Setup(p => p.Create(book)).Returns(Task.FromResult(id));

			// Act
			var result = await _target.Create(bookVm);

			// Assert
			result.Should().Be(id);

			_bookMapper.Verify(p => p.ToDomainModel(bookVm), Times.Once);
			_bookProvider.Verify(p => p.Create(book), Times.Once);
		}

		[TestMethod]
		public async Task Update()
		{
			// Arrange
			var book = _fixture.Create<Book>();
			var bookVm = _fixture.Create<BookViewModel>();

			_bookMapper.Setup(p => p.ToDomainModel(bookVm)).Returns(book);
			_bookProvider.Setup(p => p.Update(book)).Returns(Task.CompletedTask);

			// Act
			await _target.Update(bookVm);

			// Assert
			_bookMapper.Verify(p => p.ToDomainModel(bookVm), Times.Once);
			_bookProvider.Verify(p => p.Update(book), Times.Once);
		}

		[TestMethod]
		public async Task Delete()
		{
			// Arrange
			var id = _fixture.Create<Guid>();

			_bookProvider.Setup(p => p.Delete(id)).Returns(Task.CompletedTask);

			// Act
			 await _target.Delete(id);

			// Assert
			_bookProvider.Verify(p => p.Delete(id), Times.Once);
		}
	}
}
