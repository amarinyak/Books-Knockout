using System;
using System.Collections.Generic;
using Books.Models;

namespace Books.Interfaces.Services
{
    public interface IBookDataService
    {
        IEnumerable<Book> Get();
        Book Get(Guid id);
        string GetImage(Guid id);
        void Delete(Guid id);
        Guid Create(Book book);
        Guid Update(Book book, bool updateImage);
    }
}
