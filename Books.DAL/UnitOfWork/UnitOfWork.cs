using System;
using System.Data;
using Books.DAL.Interfaces.Repository;
using Books.DAL.Interfaces.UnitOfWork;
using Books.DAL.Repositories;

namespace Books.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private IAuthorRepository _authorRepository;
        private IBookRepository _bookRepository;

        public UnitOfWork(IDbConnection connection, bool useTransaction)
        {
            _connection = connection;
            _connection.Open();

            if (useTransaction)
            {
                _transaction = _connection.BeginTransaction();
            }
        }

        public IAuthorRepository AuthorRepository => _authorRepository ?? (_authorRepository = new AuthorRepository(_connection, _transaction));

        public IBookRepository BookRepository => _bookRepository ?? (_bookRepository = new BookRepository(_connection, _transaction));

        public void Commit()
        {
            if (_transaction == null)
            {
                throw new NullReferenceException("The transaction is not set");
            }

            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection.Dispose();
        }

        private void ResetRepositories()
        {
            _authorRepository = null;
            _bookRepository = null;
        }
    }
}
