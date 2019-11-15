using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.BL.Models;

namespace Books.BL.Interfaces.Providers
{
	public interface IBookProvider
	{
		Task<IEnumerable<Book>> GetList();

		Task<Book> GetById(Guid bookId);

		Task<Guid> Create(Book book);

		Task Update(Book book);

		Task Delete(Guid bookId);
	}
}
