using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.DAL.Models;

namespace Books.DAL.Interfaces.Repository
{
    public interface IBookRepository
    {
        Task<int> Add(BookDb bookDb);

        Task<int> Delete(Guid bookId, Guid token);

        Task<IEnumerable<BookDb>> GetByToken(Guid token);

        Task<BookDb> GetById(Guid bookId, Guid token);

        Task<int> Update(BookDb bookDb);
    }
}
