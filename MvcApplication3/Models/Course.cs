﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MvcApplication3.Models {
	public class Course : IEntity {

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Display(Name = "Number")]
		public int CourseID { get; set; }

		[Required(ErrorMessage = "Title is required.")]
		[MaxLength(50)]
		public string Title { get; set; }

		[Required(ErrorMessage = "Number of credits is required.")]
		[Range(0, 5, ErrorMessage = "Number of credits must be between 0 and 5.")]
		public int Credits { get; set; }

		[Display(Name = "Department")]
		public int DepartmentID { get; set; }

		[Timestamp]
		public Byte[] Timestamp { get; set; }

		public bool Deleted { get; set; }



		public virtual Department Department { get; set; }
		public virtual ICollection<Enrollment> Enrollments { get; set; }
		public virtual ICollection<Instructor> Instructors { get; set; }
	}
}