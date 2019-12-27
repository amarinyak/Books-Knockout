using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Books.DAL.Interfaces.Repository;
using Books.DAL.Models;
using Dapper;

namespace Books.DAL.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
        }

        public async Task<int> Add(BookDb entity)
        {
            var result = await Connection.ExecuteAsync(
                "[dbo].[Book_Add]",
                new
                {
                    entity.Id,
                    entity.Title,
                    entity.PageCount,
                    entity.Publisher,
                    entity.Year,
                    entity.Isbn,
                    entity.Image,
                    entity.Token
                },
                commandType: CommandType.StoredProcedure,
                transaction: Transaction);

            return result;
        }

        public async Task<int> Delete(Guid bookId, Guid token)
        {
            var result = await Connection.ExecuteAsync(
                "[dbo].[Book_Delete]",
                new
                {
                    bookId,
                    token
                },
                commandType: CommandType.StoredProcedure,
                transaction: Transaction);

            return result;
        }

        public async Task<IEnumerable<BookDb>> GetByToken(Guid token)
        {
            var result = await GetBooks(
                "[dbo].[Book_GetByToken]",
                new
                {
                    token
                });

            return result.ToList();
        }

        public async Task<BookDb> GetById(Guid bookId, Guid token)
        {
            var result = await GetBooks(
                "[dbo].[Book_GetById]",
                new
                {
                    bookId,
                    token
                });

            return result.SingleOrDefault();
        }

        public async Task<int> Update(BookDb entity)
        {
            var result = await Connection.ExecuteAsync(
                "[dbo].[Book_Update]",
                new
                {
                    entity.Id,
                    entity.Title,
                    entity.PageCount,
                    entity.Publisher,
                    entity.Year,
                    entity.Isbn,
                    entity.Image,
                    entity.Token
                },
                commandType: CommandType.StoredProcedure,
                transaction: Transaction);

            return result;
        }

        private async Task<IEnumerable<BookDb>> GetBooks(string storedProcedureName, object param = null)
        {
            var bookDictionary = new Dictionary<Guid, BookDb>();

            var result = await Connection.QueryAsync<BookDb, AuthorDb, BookDb>(
                storedProcedureName,
                (book, author) =>
                {
                    if (!bookDictionary.TryGetValue(book.Id, out var bookEntry))
                    {
                        bookEntry = book;
                        bookEntry.Authors = new List<AuthorDb>();
                        bookDictionary.Add(bookEntry.Id, bookEntry);
                    }

                    if (author != null)
                    {
                        bookEntry.Authors.Add(author);
                    }

                    return bookEntry;
                },
                param: param,
                splitOn: "BookId",
                commandType: CommandType.StoredProcedure,
                transaction: Transaction);

            return result.Distinct();
        }
    }
}
