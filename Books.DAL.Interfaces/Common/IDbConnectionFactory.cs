using System.Data;

namespace Books.DAL.Interfaces.Common
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}
