using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using AutoMapper;
using Books.Interfaces.Services;
using Books.Models;
using Books.Web.Attributes;
using Books.Web.ViewModels;

namespace Books.Web.Controllers.Api
{
    [HandleApiError]
    public class BooksController : ApiController
    {
        private readonly IBookDataService _bookDataService;

        public BooksController(IBookDataService bookDataService)
        {
            _bookDataService = bookDataService;
        }

        [HttpGet]
        public object GetList()
        {
            var books = _bookDataService.Get().Select(Mapper.Map<Book, BookViewModel>).ToList();

            return new
            {
                Books = books
            };
        }

        [HttpGet]
        public object GetById(Guid id)
        {
            var book = Mapper.Map<Book, BookViewModel>(_bookDataService.Get(id));

            return new
            {
                Book = book
            };
        }

        [HttpPost]
        [CheckApiModelState]
        public object CreateOrUpdate(BookViewModel book)
        {
            var bookModel = Mapper.Map<BookViewModel, Book>(book);

            var bookId = book.Id == Guid.Empty
                ? _bookDataService.Create(bookModel)
                : _bookDataService.Update(bookModel, book.UpdateImage);

            return new
            {
                BookId = bookId
            };
        }

        [HttpPost]
        public void Delete(BookViewModel book)
        {
            _bookDataService.Delete(book.Id);
        }

        [HttpGet]
        public HttpResponseMessage GetImage(Guid id)
        {
            var image = _bookDataService.GetImage(id);

            if (image == null) return new HttpResponseMessage(HttpStatusCode.BadRequest);

            var imageBytes = Convert.FromBase64String(image.Substring(23));

            using (var ms = new MemoryStream(imageBytes))
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(ms.ToArray())
                };

                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

                return result;
            }
        }
    }
}
