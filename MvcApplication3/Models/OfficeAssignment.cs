using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication3.Models {

	public class OfficeAssignment : IEntity {
		[Key]
		public int PersonID { get; set; }

		[MaxLength(50)]
		[Display(Name = "Office Location")]
		public string Location { get; set; }

		[Timestamp]
		public Byte[] Timestamp { get; set; }

		public bool Deleted { get; set; }

		public virtual Instructor Instructor { get; set; }
	}
}