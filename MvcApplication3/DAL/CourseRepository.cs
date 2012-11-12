using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication3.Models;

namespace MvcApplication3.DAL {
	public class CourseRepository : GenericRepository<Course> {
		
		public CourseRepository(SchoolContext context)
			: base(context) {
		}

		public int UpdateCourseCredits(int multiplier) {
			return context.Database.ExecuteSqlCommand("UPDATE Course SET Credits = Credits * {0}", multiplier);
		}

	}
}