using Books.DAL.Interfaces.Common;
using Books.DAL.Interfaces.UnitOfWork;

namespace Books.DAL.UnitOfWork
{
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
        private readonly IDbConnectionFactory _connectionFactory;

		public UnitOfWorkFactory(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

		public IUnitOfWork Create(bool useTransaction = false)
		{
			var connection = _connectionFactory.Create();
			return new UnitOfWork(connection, useTransaction);
		}
	}
}
