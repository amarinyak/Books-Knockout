using System;

namespace Books.BL.Models
{
    public class Author
    {
	    public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid BookId { get; set; }
    }
}
