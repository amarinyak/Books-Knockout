using System.Data;

namespace Books.DAL.Repositories
{
    public class BaseRepository
    {
        protected IDbConnection Connection { get; }
        protected IDbTransaction Transaction { get; }

        protected BaseRepository(IDbConnection connection, IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }
    }
}
