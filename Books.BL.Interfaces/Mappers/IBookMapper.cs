using System.Collections.Generic;
using Books.BL.Models;
using Books.DAL.Models;

namespace Books.BL.Interfaces.Mappers
{
	public interface IBookMapper
	{
		BookDb ToDataModel(Book book);

		IEnumerable<BookDb> ToDataModel(IEnumerable<Book> books);

		Book ToDomainModel(BookDb book);

		IEnumerable<Book> ToDomainModel(IEnumerable<BookDb> books);
	}
}
