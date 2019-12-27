using System;
using System.Collections.Generic;

namespace Books.BL.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int PageCount { get; set; }

        public string Publisher { get; set; }

        public int Year { get; set; }

        public string Isbn { get; set; }

        public string Image { get; set; }

        public Guid Token { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EditDate { get; set; }

        public IEnumerable<Author> Authors { get; set; }
    }
}
