﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcApplication3.Models {
	public class Department : IEntity {
		public int DepartmentID { get; set; }

		[Required(ErrorMessage = "Department name is required.")]
		[MaxLength(50)]
		public string Name { get; set; }

		[DisplayFormat(DataFormatString = "{0:c}")]
		[Required(ErrorMessage = "Budget is required.")]
		[Column(TypeName = "money")]
		public decimal? Budget { get; set; }

		[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
		[Required(ErrorMessage = "Start date is required.")]
		public DateTime StartDate { get; set; }

		[Display(Name = "Administrator")]
		public int? PersonID { get; set; }



		public virtual Instructor Administrator { get; set; }
		public virtual ICollection<Course> Courses { get; set; }

		[Timestamp]
		public Byte[] Timestamp { get; set; }

		public bool Deleted { get; set; }

	}
}