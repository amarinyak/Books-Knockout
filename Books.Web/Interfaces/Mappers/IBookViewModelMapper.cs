using System.Collections.Generic;
using Books.BL.Models;
using Books.Web.ViewModels.API;

namespace Books.Web.Interfaces.Mappers
{
	public interface IBookViewModelMapper
	{
		Book ToDomainModel(BookViewModel book);

		IEnumerable<Book> ToDomainModel(IEnumerable<BookViewModel> books);

		BookViewModel ToViewModel(Book book);

		IEnumerable<BookViewModel> ToViewModel(IEnumerable<Book> books);
	}
}
