using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcApplication3.Models {
	public class Instructor : Person {


		[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
		[Required(ErrorMessage = "Hire date is required.")]
		[Display(Name = "Hire Date")]
		public DateTime? HireDate { get; set; }

		public virtual ICollection<Course> Courses { get; set; }
		public virtual OfficeAssignment OfficeAssignment { get; set; }
	}
}