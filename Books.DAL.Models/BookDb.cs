using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.DAL.Models
{
	[Table("Books")]
	public class BookDb
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		public string Title { get; set; }

		public int PageCount { get; set; }

		public string Publisher { get; set; }

		public int Year { get; set; }

		public string Isbn { get; set; }

		public string Image { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime EditDate { get; set; }
		
		public virtual ICollection<AuthorDb> Authors { get; set; }
	}
}
