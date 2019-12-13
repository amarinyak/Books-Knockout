using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Books.BL.Interfaces.Services;
using Books.WebApi.Code.Attributes;
using Books.WebApi.Interfaces.Mappers;
using Books.WebApi.ViewModels;

namespace Books.WebApi.Controllers.v1
{
	[RoutePrefix("v1/books")]
	public class BooksController : BaseController
    {
	    private readonly IBookProvider _bookProvider;
	    private readonly IBookViewModelMapper _bookViewModelMapper;

	    public BooksController(IBookProvider bookProvider, IBookViewModelMapper bookMapper, ITokenProvider tokenProvider)
		    : base(tokenProvider)
	    {
		    _bookProvider = bookProvider;
		    _bookViewModelMapper = bookMapper;
	    }

	    /// <summary>
		/// Get list of books
		/// </summary>
		/// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<BookViewModel>> GetByToken()
		{
	        var books = await _bookProvider.GetByToken(Token);

			var model = _bookViewModelMapper.ToViewModel(books).ToList();

			return model;
        }

		/// <summary>
		/// Get a book by ID
		/// </summary>
		/// <param name="id">Book ID</param>
		/// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<BookViewModel> GetById(Guid id)
        {
	        var book = await _bookProvider.GetById(id, Token);

	        var model = _bookViewModelMapper.ToViewModel(book);

            return model;
        }

		/// <summary>
		/// Create a book
		/// </summary>
		/// <param name="book"></param>
		/// <returns></returns>
        [HttpPost]
        [Route("")]
        [CheckModelState]
        public async Task<Guid> Create(BookViewModel book)
        {
            var bookDm = _bookViewModelMapper.ToDomainModel(book, Token);

            var bookId = await _bookProvider.Create(bookDm);

            return bookId;
        }

		/// <summary>
		/// Update a book
		/// </summary>
		/// <param name="book"></param>
		/// <returns></returns>
        [HttpPut]
        [Route("")]
        [CheckModelState]
        public async Task Update(BookViewModel book)
        {
	        var bookDm = _bookViewModelMapper.ToDomainModel(book, Token);

	        await _bookProvider.Update(bookDm);
        }

		/// <summary>
		/// Delete a book by ID
		/// </summary>
		/// <param name="id">Book ID</param>
		/// <returns></returns>
        [HttpDelete]
		[Route("{id}")]
        public async Task Delete(Guid id)
        {
	        await _bookProvider.Delete(id, Token);
        }
    }
}
