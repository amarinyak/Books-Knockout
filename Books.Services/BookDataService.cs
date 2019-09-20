using System;
using System.Collections.Generic;
using System.Linq;
using Books.Interfaces.Services;
using Books.Models;

namespace Books.Services
{
    public class BookDataService : IBookDataService
    {
        private readonly List<Book> _books = new List<Book>();

        public BookDataService(IEnumerable<Book> books)
        {
            if(books == null) return;

            _books.AddRange(books);
        }

        public IEnumerable<Book> Get()
        {
            return _books;
        }

        public Book Get(Guid id)
        {
            return _books.SingleOrDefault(p => p.Id == id);
        }

        public string GetImage(Guid id)
        {
            var book = _books.SingleOrDefault(p => p.Id == id);

            return book == null ? null : book.Image;
        }

        public void Delete(Guid id)
        {
            var book = _books.SingleOrDefault(p => p.Id == id);

            if (book != null) _books.Remove(book);
        }

        public Guid Create(Book book)
        {
            book.Id = Guid.NewGuid();
            book.CreateDate = DateTime.Now;
            book.EditDate = DateTime.Now;

            _books.Add(book);

            return book.Id;
        }

        public Guid Update(Book book, bool updateImage)
        {
            var myBook = _books.Single(p => p.Id == book.Id);

            myBook.Title = book.Title;
            myBook.Authors = book.Authors;
            myBook.PageCount = book.PageCount;
            myBook.Publisher = book.Publisher;
            myBook.Year = book.Year;
            myBook.Isbn = book.Isbn;
            myBook.EditDate = DateTime.Now;

            if(updateImage)
            {
                myBook.Image = book.Image;
            }

            return myBook.Id;
        }
    }
}
