using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Books.Web.Code.Attributes;

namespace Books.Web.ViewModels
{
    public class BookViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [Range(1, 10000)]
        public int PageCount { get; set; }

        [MaxLength(30)]
        public string Publisher { get; set; }

        [Required]
        [Range(1800, 9999)]
        public int Year { get; set; }

        [IsbnValidation(ErrorMessage = "Incorrect ISBN number, example: 978-0804139021")]
        public string Isbn { get; set; }

        [RegularExpression(@"^data:image\/jpeg;base64.*", ErrorMessage = "Unsupported image format, only jpeg images are supported")]
        public string Image { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EditDate { get; set; }

        public IEnumerable<AuthorViewModel> Authors { get; set; }
    }
}
