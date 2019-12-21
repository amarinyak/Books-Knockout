using System.Data;
using System.Data.SqlClient;
using Books.DAL.Interfaces.Common;

namespace Books.DAL.Common
{
	public class DbConnectionFactory : IDbConnectionFactory
	{
		private readonly string _connectionString;

		public DbConnectionFactory(string connectionString)
		{
			_connectionString = connectionString;
		}

		public IDbConnection Create()
		{
			return new SqlConnection(_connectionString);
		}
	}
}
