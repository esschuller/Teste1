using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.DAL;
using MvcApplication3.Models;

namespace MvcApplication3.BL {
	public class InstructorBo : BusinessBase<Instructor> {
		public InstructorBo(ModelStateDictionary modelState)
			: base(modelState) {
		}
	}
}