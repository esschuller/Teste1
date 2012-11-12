﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication3.ViewModels {
	public class EnrollmentDateGroup {
		[DisplayFormat(DataFormatString = "{0:d}")]
		public DateTime? EnrollmentDate { get; set; }

		public int StudentCount { get; set; }
	}
}