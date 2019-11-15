using System;
using Books.DAL.Interfaces.Repository;

namespace Books.DAL.Interfaces.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		IAuthorRepository AuthorRepository { get; }

		IBookRepository BookRepository { get; }

		void Commit();
	}
}
