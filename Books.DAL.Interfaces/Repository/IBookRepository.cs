using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.DAL.Models;

namespace Books.DAL.Interfaces.Repository
{
	public interface IBookRepository
	{
		Task<int> Add(BookDb entity);

		Task<int> Delete(Guid bookId);

		Task<IEnumerable<BookDb>> Get();

		Task<BookDb> GetById(Guid bookId);

		Task<int> Update(BookDb entity);
	}
}
