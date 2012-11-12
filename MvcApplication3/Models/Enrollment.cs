using System;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication3.Models {
	public class Enrollment : IEntity {
		public int EnrollmentID { get; set; }

		public int CourseID { get; set; }

		public int PersonID { get; set; }

		[DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true, NullDisplayText = "No grade")]
		public decimal? Grade { get; set; }

		[Timestamp]
		public Byte[] Timestamp { get; set; }

		public bool Deleted { get; set; }

		public virtual Course Course { get; set; }
		public virtual Student Student { get; set; }
	}
}