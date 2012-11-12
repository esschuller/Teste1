using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcApplication3.Models {
	public abstract class Person : IEntity {
		
		[Key]
		public int PersonID { get; set; }

		[Required(ErrorMessage = "Last name is required.")]
		[Display(Name = "Last Name")]
		[MaxLength(50)]
		public string LastName { get; set; }

		[Required(ErrorMessage = "First name is required.")]
		[Column("FirstName")]
		[Display(Name = "First Name")]
		[MaxLength(50)]
		public string FirstMidName { get; set; }

		public string FullName {
			get {
				return LastName + ", " + FirstMidName;
			}
		}

		[Timestamp]
		public Byte[] Timestamp { get; set; }

		public bool Deleted { get; set; }
	}
}