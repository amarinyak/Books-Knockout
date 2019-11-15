using System;
using System.Collections.Generic;
using Books.BL.Models;
using Books.DAL.Models;

namespace Books.BL.Interfaces.Mappers
{
	public interface IAuthorMapper
	{
		AuthorDb ToDataModel(Author author, Guid bookId);

		IEnumerable<AuthorDb> ToDataModel(IEnumerable<Author> authors, Guid bookId);

		Author ToDomainModel(AuthorDb author);

		IEnumerable<Author> ToDomainModel(IEnumerable<AuthorDb> authors);
	}
}
