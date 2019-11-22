using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Books.Web.Code.Attributes;

namespace Books.Web.ViewModels.API
{
    public class BookViewModel
    {
		/// <summary>
		/// Book ID
		/// </summary>
        public Guid Id { get; set; }

		/// <summary>
		/// Title
		/// </summary>
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

		/// <summary>
		/// Page count
		/// </summary>
        [Required]
        [Range(1, 10000)]
        public int PageCount { get; set; }

		/// <summary>
		/// Book publisher
		/// </summary>
        [MaxLength(30)]
        public string Publisher { get; set; }

		/// <summary>
		/// Year of publication
		/// </summary>
        [Required]
        [Range(1800, 9999)]
        public int Year { get; set; }

		/// <summary>
		/// International Standard Book Number
		/// </summary>
        [IsbnValidation(ErrorMessage = "Incorrect ISBN number, example: 978-0804139021")]
        public string Isbn { get; set; }

		/// <summary>
		/// Book cover image
		/// </summary>
        [RegularExpression(@"^data:image\/jpeg;base64.*", ErrorMessage = "Unsupported image format, only jpeg images are supported")]
        public string Image { get; set; }

		/// <summary>
		/// The date the book was added
		/// </summary>
        public DateTime CreateDate { get; set; }

		/// <summary>
		/// The date the book was edit
		/// </summary>
        public DateTime EditDate { get; set; }

		/// <summary>
		/// List of authors
		/// </summary>
        public IEnumerable<AuthorViewModel> Authors { get; set; }
    }
}
