using Books.DAL.Interfaces.UnitOfWork;

namespace Books.DAL.UnitOfWork
{
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		private readonly string _connectionString;

		public UnitOfWorkFactory(string connectionString)
		{
			_connectionString = connectionString;
		}

		public IUnitOfWork Create(bool useTransaction = false)
		{
			return new UnitOfWork(_connectionString, useTransaction);
		}
	}
}
