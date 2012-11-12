using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.DAL;
using MvcApplication3.Models;

namespace MvcApplication3.BL {
	public class CourseBo : BusinessBase<Course> {

		public CourseBo(ModelStateDictionary modelState)
			: base(modelState) {
		}

		public int UpdateCourseCredits(int multiplier) {
			return this.context.Database.ExecuteSqlCommand("UPDATE Course SET Credits = Credits * {0}", multiplier);
		}




	}
}