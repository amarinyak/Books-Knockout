using System;
using System.ComponentModel.DataAnnotations;

namespace Books.WebApi.ViewModels
{
	public class AuthorViewModel
	{
		/// <summary>
		/// Author ID
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// First name
		/// </summary>
		[Required]
		[MaxLength(20)]
		public string FirstName { get; set; }

		/// <summary>
		/// Last name
		/// </summary>
		[Required]
		[MaxLength(20)]
		public string LastName { get; set; }

		/// <summary>
		/// Book ID
		/// </summary>
		public Guid BookId { get; set; }
	}
}
