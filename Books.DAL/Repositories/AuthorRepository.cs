using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Books.DAL.DataTables;
using Books.DAL.Interfaces.Repository;
using Books.DAL.Models;
using Dapper;

namespace Books.DAL.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public AuthorRepository(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
        }

        public async Task<int> Merge(IEnumerable<AuthorDb> authorDbs)
        {
            using (var authorCollection = AuthorCollectionDataTable.Init(authorDbs))
            {
                var result = await Connection.ExecuteAsync(
                    "[dbo].[Author_Merge]",
                    new { authorCollection },
                    commandType: CommandType.StoredProcedure,
                    transaction: Transaction);

                return result;
            }
        }

        public async Task<int> DeleteByBookId(Guid bookId)
        {
            var result = await Connection.ExecuteAsync(
                "[dbo].[Author_DeleteByBookId]",
                new { bookId },
                commandType: CommandType.StoredProcedure,
                transaction: Transaction);

            return result;
        }
    }
}
