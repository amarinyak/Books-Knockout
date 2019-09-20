using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Books.Web.Attributes;

namespace Books.Web.ViewModels
{
    public class BookViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        public IEnumerable<AuthorViewModel> Authors { get; set; }

        [Range(1, 10000)]
        public int PageCount { get; set; }

        [MaxLength(30)]
        public string Publisher { get; set; }

        [Range(1800, 9999)]
        public int Year { get; set; }

        [IsbnValidation]
        public string Isbn { get; set; }

        [RegularExpression(@"^data:image\/jpeg;base64.*", ErrorMessage = "Выберите изображение в формате jpeg.")]
        public string Image { get; set; }
        public bool HasImage { get; set; }
        public bool UpdateImage { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
    }
}
