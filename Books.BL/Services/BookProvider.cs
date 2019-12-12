using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.BL.Interfaces.Mappers;
using Books.BL.Interfaces.Services;
using Books.BL.Models;
using Books.DAL.Interfaces.UnitOfWork;

namespace Books.BL.Services
{
	public class BookProvider : IBookProvider
	{
		private readonly IUnitOfWorkFactory _uowFactory;
		private readonly IBookMapper _bookMapper;

		public BookProvider(IUnitOfWorkFactory uowFactory, IBookMapper bookMapper)
		{
			_uowFactory = uowFactory;
			_bookMapper = bookMapper;
		}

		public async Task<IEnumerable<Book>> GetByToken(Guid token)
		{
			using (var uow = _uowFactory.Create())
			{
				var booksDb = await uow.BookRepository.GetByToken(token);

				return _bookMapper.ToDomainModel(booksDb);
			}
		}

		public async Task<Book> GetById(Guid bookId, Guid token)
		{
			using (var uow = _uowFactory.Create())
			{
				var bookDb = await uow.BookRepository.GetById(bookId, token);

				return _bookMapper.ToDomainModel(bookDb);
			}
		}

		public async Task<Guid> Create(Book book)
		{
			var bookDb = _bookMapper.ToDataModel(book);
			
			using (var uow = _uowFactory.Create(true))
			{
				await uow.BookRepository.Add(bookDb);
				await uow.AuthorRepository.Merge(bookDb.Authors);
				uow.Commit();
			}

			return bookDb.Id;
		}

		public async Task Create(IEnumerable<Book> books)
		{
			using (var uow = _uowFactory.Create(true))
			{
				foreach (var book in books)
				{
					var bookDb = _bookMapper.ToDataModel(book);

					await uow.BookRepository.Add(bookDb);
					await uow.AuthorRepository.Merge(bookDb.Authors);
				}

				uow.Commit();
			}
		}

		public async Task Update(Book book)
		{
			var bookDb = _bookMapper.ToDataModel(book);

			using (var uow = _uowFactory.Create(true))
			{
				await uow.BookRepository.Update(bookDb);
				await uow.AuthorRepository.Merge(bookDb.Authors);
				uow.Commit();
			}
		}

		public async Task Delete(Guid bookId, Guid token)
		{
			using (var uow = _uowFactory.Create(true))
			{
				await uow.AuthorRepository.DeleteByBookId(bookId);
				await uow.BookRepository.Delete(bookId, token);
				uow.Commit();
			}
		}
	}
}
