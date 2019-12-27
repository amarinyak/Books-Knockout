using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.DAL.Models;

namespace Books.DAL.Interfaces.Repository
{
    public interface IAuthorRepository
    {
        Task<int> Merge(IEnumerable<AuthorDb> authorDbs);

        Task<int> DeleteByBookId(Guid bookId);
    }
}
