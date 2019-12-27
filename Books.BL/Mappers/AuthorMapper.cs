using System;
using System.Collections.Generic;
using System.Linq;
using Books.BL.Interfaces.Mappers;
using Books.BL.Models;
using Books.DAL.Models;

namespace Books.BL.Mappers
{

    public class AuthorMapper : IAuthorMapper
    {
        public AuthorDb ToDataModel(Author author, Guid bookId)
        {
            return new AuthorDb
            {
                Id = author.Id == Guid.Empty
                    ? Guid.NewGuid()
                    : author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BookId = author.BookId == Guid.Empty
                    ? bookId
                    : author.BookId
            };
        }

        public IEnumerable<AuthorDb> ToDataModel(IEnumerable<Author> authors, Guid bookId)
        {
            return authors?.Select(p => ToDataModel(p, bookId)).ToList();
        }

        public Author ToDomainModel(AuthorDb author)
        {
            return new Author
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BookId = author.BookId
            };
        }

        public IEnumerable<Author> ToDomainModel(IEnumerable<AuthorDb> authors)
        {
            return authors?.Select(ToDomainModel).ToList();
        }
    }
}
