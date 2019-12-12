using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.BL.Interfaces.Services;
using Books.BL.Models;

namespace Books.BL.Services
{
	public class BookCreator : IBookCreator
	{
		private readonly IBookProvider _bookProvider;

		public BookCreator(IBookProvider bookProvider)
		{
			_bookProvider = bookProvider;
		}

		public async Task CreateDefaultBooks(Guid token)
		{
			var books = GetDefaultBooks(token);

			await _bookProvider.Create(books);
		}

		private static IEnumerable<Book> GetDefaultBooks(Guid token)
		{
			var utcNow = DateTime.UtcNow;

			return new[]
			{
				new Book
				{
					Title = "111",
					PageCount = 222,
					Publisher = "333",
					Year = 2222,
					Isbn = "978-0804139021",
					Image = "",
					Token = token,
					CreateDate = utcNow,
					EditDate = utcNow,
					Authors = new[]
					{
						new Author
						{
							FirstName = "111",
							LastName = "222"
						}
					}
				}
			};
		}
	}
}
