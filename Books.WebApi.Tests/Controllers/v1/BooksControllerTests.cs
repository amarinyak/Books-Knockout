using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Books.BL.Interfaces.Services;
using Books.BL.Models;
using Books.WebApi.Controllers.v1;
using Books.WebApi.Interfaces.Mappers;
using Books.WebApi.ViewModels;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Books.WebApi.Tests.Controllers.v1
{
	[TestClass]
	public class BooksControllerTests
	{
		private Fixture _fixture;
		private BooksController _target;
		private Mock<IBookProvider> _bookProvider;
		private Mock<IBookViewModelMapper> _bookMapper;
		private Mock<ITokenProvider> _tokenProvider;

		[TestInitialize]
		public void TestInitialize()
		{
			_fixture = new Fixture();

			_bookProvider = new Mock<IBookProvider>(MockBehavior.Strict);
			_bookMapper = new Mock<IBookViewModelMapper>(MockBehavior.Strict);
			_tokenProvider = new Mock<ITokenProvider>(MockBehavior.Strict);

			_target = new BooksController(_bookProvider.Object, _bookMapper.Object, _tokenProvider.Object);
		}

		[TestMethod]
		public async Task GetByToken()
		{
			// Arrange
			var token = _fixture.Create<Guid>();
			var books = _fixture.CreateMany<Book>().ToList();
			var booksVm = _fixture.CreateMany<BookViewModel>().ToList();

			_bookProvider.Setup(p => p.GetByToken(token)).Returns(Task.FromResult<IEnumerable<Book>>(books));
			_bookMapper.Setup(p => p.ToViewModel(books)).Returns(booksVm);
            _tokenProvider.Setup(p => p.GetToken(_target.Request)).Returns(token);

			// Act
			var result = await _target.GetByToken();

			// Assert
			result.Should().BeEquivalentTo(booksVm);

			_bookProvider.Verify(p => p.GetByToken(token), Times.Once);
			_bookMapper.Verify(p => p.ToViewModel(books), Times.Once);
            _tokenProvider.Verify(p => p.GetToken(_target.Request), Times.Once);
		}

		[TestMethod]
		public async Task GetById()
		{
			// Arrange
			var token = _fixture.Create<Guid>();
			var id = _fixture.Create<Guid>();
			var book = _fixture.Create<Book>();
			var bookVm = _fixture.Create<BookViewModel>();

			_bookProvider.Setup(p => p.GetById(id, token)).Returns(Task.FromResult(book));
			_bookMapper.Setup(p => p.ToViewModel(book)).Returns(bookVm);
            _tokenProvider.Setup(p => p.GetToken(_target.Request)).Returns(token);

			// Act
			var result = await _target.GetById(id);

			// Assert
			result.Should().BeEquivalentTo(bookVm);

			_bookProvider.Verify(p => p.GetById(id, token), Times.Once);
			_bookMapper.Verify(p => p.ToViewModel(book), Times.Once);
            _tokenProvider.Verify(p => p.GetToken(_target.Request), Times.Once);
		}

		[TestMethod]
		public async Task Create()
		{
			// Arrange
			var token = _fixture.Create<Guid>();
			var id = _fixture.Create<Guid>();
			var book = _fixture.Create<Book>();
			var bookVm = _fixture.Build<BookViewModel>()
				.With(p => p.Id, Guid.Empty)
				.Create();

			_bookMapper.Setup(p => p.ToDomainModel(bookVm, token)).Returns(book);
			_bookProvider.Setup(p => p.Create(book)).Returns(Task.FromResult(id));
            _tokenProvider.Setup(p => p.GetToken(_target.Request)).Returns(token);

			// Act
			var result = await _target.Create(bookVm);

			// Assert
			result.Should().Be(id);

			_bookMapper.Verify(p => p.ToDomainModel(bookVm, token), Times.Once);
			_bookProvider.Verify(p => p.Create(book), Times.Once);
            _tokenProvider.Verify(p => p.GetToken(_target.Request), Times.Once);
		}

		[TestMethod]
		public async Task Update()
		{
			// Arrange
			var token = _fixture.Create<Guid>();
			var book = _fixture.Create<Book>();
			var bookVm = _fixture.Create<BookViewModel>();

			_bookMapper.Setup(p => p.ToDomainModel(bookVm, token)).Returns(book);
			_bookProvider.Setup(p => p.Update(book)).Returns(Task.CompletedTask);
            _tokenProvider.Setup(p => p.GetToken(_target.Request)).Returns(token);

			// Act
			await _target.Update(bookVm);

			// Assert
			_bookMapper.Verify(p => p.ToDomainModel(bookVm, token), Times.Once);
			_bookProvider.Verify(p => p.Update(book), Times.Once);
            _tokenProvider.Verify(p => p.GetToken(_target.Request), Times.Once);
		}

		[TestMethod]
		public async Task Delete()
		{
			// Arrange
			var token = _fixture.Create<Guid>();
			var id = _fixture.Create<Guid>();

			_bookProvider.Setup(p => p.Delete(id, token)).Returns(Task.CompletedTask);
            _tokenProvider.Setup(p => p.GetToken(_target.Request)).Returns(token);

			// Act
			await _target.Delete(id);

			// Assert
			_bookProvider.Verify(p => p.Delete(id, token), Times.Once);
            _tokenProvider.Verify(p => p.GetToken(_target.Request), Times.Once);
		}
	}
}
