using System;
using System.Collections.Generic;
using Books.BL.Models;
using Books.WebApi.ViewModels;

namespace Books.WebApi.Interfaces.Mappers
{
    public interface IBookViewModelMapper
    {
        Book ToDomainModel(BookViewModel book, Guid token);

        IEnumerable<Book> ToDomainModel(IEnumerable<BookViewModel> books, Guid token);

        BookViewModel ToViewModel(Book book);

        IEnumerable<BookViewModel> ToViewModel(IEnumerable<Book> books);
    }
}
