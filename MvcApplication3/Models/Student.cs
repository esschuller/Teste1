using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcApplication3.Models {
	public class Student : Person {

		[DataType(DataType.Date)]
		[Required(ErrorMessage = "Enrollment date is required.")]
		[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
		[Display(Name = "Enrollment Date")]
		public DateTime? EnrollmentDate { get; set; }

		/*[Required]
		public int Age { get; set; }

		[MaxLength(200)]
		public string Obs { get; set; }

		[MaxLength(200)]
		public string Obs2 { get; set; }

		[MaxLength(200)]
		public string Obs3 { get; set; }*/

		public virtual ICollection<Enrollment> Enrollments { get; set; }
	}
}