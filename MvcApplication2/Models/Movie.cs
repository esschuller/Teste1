using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication2.Models {
	public class Movie {
		public int ID { get; set; }
		
		[Required]
		public string Title { get; set; }

		[DataType(DataType.Date)]
		public DateTime ReleaseDate { get; set; }

		[Required]
		public string Genre { get; set; }

		[Range(1, 100)]
		[DataType(DataType.Currency)] 
		public decimal Price { get; set; }
	}

	public class MovieDBContext : DbContext {
		public DbSet<Movie> Movies { get; set; }
	}
}