using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication3.Models;

namespace MvcApplication3.DAL {
	public class UnitOfWork : IDisposable {
		private SchoolContext context = new SchoolContext();
		private DataAccess<Department> departmentRepository;
		private DataAccess<Course> courseRepository;
		//private CourseRepository courseRepository;

		public DataAccess<Department> DepartmentRepository {
			get {

				if (this.departmentRepository == null) {
					this.departmentRepository = new DataAccess<Department>(context);
				}
				return departmentRepository;
			}
		}

		public DataAccess<Course> CourseRepository {
			get {

				if (this.courseRepository == null) {
					this.courseRepository = new DataAccess<Course>(context);
				}
				return courseRepository;
			}
		}

		




		public void Save() {
			context.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing) {
			if (!this.disposed) {
				if (disposing) {
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}