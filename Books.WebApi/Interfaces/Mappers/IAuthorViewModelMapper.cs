using System.Collections.Generic;
using Books.BL.Models;
using Books.WebApi.ViewModels;

namespace Books.WebApi.Interfaces.Mappers
{
	public interface IAuthorViewModelMapper
	{
		Author ToDomainModel(AuthorViewModel author);

		IEnumerable<Author> ToDomainModel(IEnumerable<AuthorViewModel> authors);

		AuthorViewModel ToViewModel(Author author);

		IEnumerable<AuthorViewModel> ToViewModel(IEnumerable<Author> authors);
	}
}