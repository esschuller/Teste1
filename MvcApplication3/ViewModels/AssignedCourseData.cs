﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication3.ViewModels {
	public class AssignedCourseData {
		public int CourseID { get; set; }
		public string Title { get; set; }
		public bool Assigned { get; set; }
	}
}