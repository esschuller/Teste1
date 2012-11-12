using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcApplication3.Models {
	public interface IEntity {
		
		Boolean Deleted { get; set; }
		Byte[] Timestamp { get; set; }
	}
}
