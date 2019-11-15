using System;
using System.Collections.Generic;
using System.Linq;
using Books.BL.Interfaces.Mappers;
using Books.BL.Models;
using Books.DAL.Models;

namespace Books.BL.Mappers
{
	public class BookMapper : IBookMapper
	{
		private readonly IAuthorMapper _authorMapper;

		public BookMapper(IAuthorMapper authorMapper)
		{
			_authorMapper = authorMapper;
		}

		public BookDb ToDataModel(Book book)
		{
			var bookId = book.Id == Guid.Empty
				? Guid.NewGuid()
				: book.Id;

			return new BookDb
			{
				Id = bookId,
				Title = book.Title,
				PageCount = book.PageCount,
				Publisher = book.Publisher,
				Year = book.Year,
				Isbn = book.Isbn,
				Image = book.Image,
				CreateDate = book.CreateDate,
				EditDate = book.EditDate,
				Authors = _authorMapper
					.ToDataModel(book.Authors, bookId)
					?.ToList()
			};
		}

		public IEnumerable<BookDb> ToDataModel(IEnumerable<Book> books)
		{
			return books?.Select(ToDataModel).ToList();
		}

		public Book ToDomainModel(BookDb book)
		{
			return new Book
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
				Authors = _authorMapper
					.ToDomainModel(book.Authors)
					?.ToList()
			};
		}

		public IEnumerable<Book> ToDomainModel(IEnumerable<BookDb> books)
		{
			return books?.Select(ToDomainModel).ToList();
		}
	}
}
