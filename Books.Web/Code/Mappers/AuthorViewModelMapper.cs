using System.Collections.Generic;
using System.Linq;
using Books.BL.Models;
using Books.Web.Interfaces.Mappers;
using Books.Web.ViewModels;

namespace Books.Web.Code.Mappers
{
	public class AuthorViewModelMapper : IAuthorViewModelMapper
	{
		public Author ToDomainModel(AuthorViewModel author)
		{
			return new Author
			{
				Id = author.Id,
				FirstName = author.FirstName,
				LastName = author.LastName,
				BookId = author.BookId
			};
		}

		public IEnumerable<Author> ToDomainModel(IEnumerable<AuthorViewModel> authors)
		{
			return authors?.Select(ToDomainModel).ToList();
		}

		public AuthorViewModel ToViewModel(Author author)
		{
			return new AuthorViewModel
			{
				Id = author.Id,
				FirstName = author.FirstName,
				LastName = author.LastName,
				BookId = author.BookId
			};
		}

		public IEnumerable<AuthorViewModel> ToViewModel(IEnumerable<Author> authors)
		{
			return authors?.Select(ToViewModel).ToList();
		}
	}
}