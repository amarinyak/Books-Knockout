using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.BL.Models;

namespace Books.BL.Interfaces.Services
{
	public interface IBookProvider
	{
		Task<IEnumerable<Book>> GetByToken(Guid token);

		Task<Book> GetById(Guid bookId, Guid token);

		Task<Guid> Create(Book book);

		Task Create(IEnumerable<Book> books);

		Task Update(Book book);

		Task Delete(Guid bookId, Guid token);
	}
}
