using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.DAL;
using MvcApplication3.Models;

namespace MvcApplication3.BL {
	public class StudentBo : BusinessBase<Student> {
		public StudentBo(ModelStateDictionary modelState)
			: base(modelState) {
		}
	}
}