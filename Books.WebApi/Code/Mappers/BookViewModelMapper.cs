using System;
using System.Collections.Generic;
using System.Linq;
using Books.BL.Models;
using Books.WebApi.Interfaces.Mappers;
using Books.WebApi.ViewModels;

namespace Books.WebApi.Code.Mappers
{
    public class BookViewModelMapper : IBookViewModelMapper
    {
        private readonly IAuthorViewModelMapper _authorMapper;

        public BookViewModelMapper(IAuthorViewModelMapper authorMapper)
        {
            _authorMapper = authorMapper;
        }

        public Book ToDomainModel(BookViewModel book, Guid token)
        {
            return new Book
            {
                Id = book.Id,
                Title = book.Title,
                PageCount = book.PageCount,
                Publisher = book.Publisher,
                Year = book.Year,
                Isbn = book.Isbn,
                Image = book.Image,
                Token = token,
                CreateDate = book.CreateDate,
                EditDate = book.EditDate,
                Authors = _authorMapper
                    .ToDomainModel(book.Authors)
                    ?.ToList()
            };
        }

        public IEnumerable<Book> ToDomainModel(IEnumerable<BookViewModel> books, Guid token)
        {
            return books?.Select(p => ToDomainModel(p, token)).ToList();
        }

        public BookViewModel ToViewModel(Book book)
        {
            return new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                PageCount = book.PageCount,
                Publisher = book.Publisher,
                Year = book.Year,
                Isbn = book.Isbn,
                Image = book.Image,
                CreateDate = book.CreateDate,
                EditDate = book.EditDate,
                Authors = _authorMapper
                    .ToViewModel(book.Authors)
                    ?.ToList()
            };
        }

        public IEnumerable<BookViewModel> ToViewModel(IEnumerable<Book> books)
        {
            return books?.Select(ToViewModel).ToList();
        }
    }
}
