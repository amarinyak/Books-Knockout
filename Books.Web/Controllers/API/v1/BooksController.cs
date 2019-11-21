using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Books.BL.Interfaces.Providers;
using Books.Web.Code.Attributes;
using Books.Web.Interfaces.Mappers;
using Books.Web.ViewModels;

namespace Books.Web.Controllers.API.v1
{
	[RoutePrefix("api/v1/books")]
    [HandleErrors]
    public class BooksController : ApiController
    {
	    private readonly IBookProvider _bookProvider;
	    private readonly IBookViewModelMapper _bookViewModelMapper;

	    public BooksController(IBookProvider bookProvider, IBookViewModelMapper bookMapper)
	    {
		    _bookProvider = bookProvider;
		    _bookViewModelMapper = bookMapper;
	    }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<BookViewModel>> GetList()
        {
	        var books = await _bookProvider.GetList();

			var model = _bookViewModelMapper.ToViewModel(books).ToList();

			return model;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BookViewModel> GetById(Guid id)
        {
	        var book = await _bookProvider.GetById(id);

	        var model = _bookViewModelMapper.ToViewModel(book);

            return model;
        }

        [HttpPost]
        [Route("")]
        [CheckModelState]
        public async Task<Guid> Create(BookViewModel book)
        {
            var bookDm = _bookViewModelMapper.ToDomainModel(book);

            var bookId = await _bookProvider.Create(bookDm);

            return bookId;
        }

        [HttpPut]
        [Route("")]
        [CheckModelState]
        public async Task Update(BookViewModel book)
        {
	        var bookDm = _bookViewModelMapper.ToDomainModel(book);

	        await _bookProvider.Update(bookDm);
        }

        [HttpDelete]
		[Route("{id}")]
        public async Task Delete(Guid id)
        {
	        await _bookProvider.Delete(id);
        }
    }
}
