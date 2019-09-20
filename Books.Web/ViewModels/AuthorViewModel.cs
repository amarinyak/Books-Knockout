using System.ComponentModel.DataAnnotations;

namespace Books.Web.ViewModels
{
    public class AuthorViewModel
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
    }
}
