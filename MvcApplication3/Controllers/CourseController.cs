using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;
using MvcApplication3.BL;

namespace MvcApplication3.Controllers {
	public class CourseController : Controller {

		private CourseBo courseBo;

		public CourseController() {
			courseBo = new CourseBo(ModelState);
		}

		//
		// GET: /Course/

		public ActionResult Index() {
			var courses = courseBo.Get(includeProperties: "Department");
			return View(courses.ToList());
		}

		//
		// GET: /Course/Details/5

		/*public ActionResult Details(int id = 0) {
			Course course = courseBo.GetByID(id);
			if (course == null) {
				return HttpNotFound();
			}
			return View(course);
		}*/

		public ActionResult Details(int id) {
			var query = "SELECT * FROM Course WHERE CourseID = @p0";
			return View(courseBo.GetWithRawSql(query, id).Single());
		}

		//
		// GET: /Course/Create

		public ActionResult Create() {
			//ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name");
			PopulateDepartmentsDropDownList();
			return View();
		}

		//
		// POST: /Course/Create

		[HttpPost]
		public ActionResult Create(Course course) {
			try {
				if (ModelState.IsValid) {
					courseBo.Insert(course);
					return RedirectToAction("Index");
				}
			} catch (DataException) {
				//Log the error (add a variable name after DataException)
				ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
			}

			//ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", course.DepartmentID);
			PopulateDepartmentsDropDownList(course.DepartmentID);
			return View(course);
		}

		//
		// GET: /Course/Edit/5

		public ActionResult Edit(int id = 0) {
			Course course = courseBo.GetByID(id);
			if (course == null) {
				return HttpNotFound();
			}

			//ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", course.DepartmentID);
			PopulateDepartmentsDropDownList(course.DepartmentID);
			return View(course);
		}

		//
		// POST: /Course/Edit/5

		[HttpPost]
		public ActionResult Edit(Course course) {
			try {
				if (ModelState.IsValid) {
					courseBo.Update(course);
					return RedirectToAction("Index");
				}
			} catch (DataException ex) {
				//Log the error (add a variable name after DataException)
				ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
			}

			//ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", course.DepartmentID);
			PopulateDepartmentsDropDownList(course.DepartmentID);
			return View(course);
		}

		private void PopulateDepartmentsDropDownList(object selectedDepartment = null) {
			
			DepartmentBo departmentBo = new DepartmentBo(ModelState);
			var departmentsQuery = departmentBo.Get(orderBy: q => q.OrderBy(d => d.Name));
			ViewBag.DepartmentID = new SelectList(departmentsQuery, "DepartmentID", "Name", selectedDepartment);
		}

		//
		// GET: /Course/Delete/5

		public ActionResult Delete(int id = 0) {
			Course course = courseBo.GetByID(id);
			if (course == null) {
				return HttpNotFound();
			}
			return View(course);
		}

		//
		// POST: /Course/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id) {

			courseBo.Delete(id);
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing) {
			courseBo.Dispose();
			base.Dispose(disposing);
		}

		public ActionResult UpdateCourseCredits(int? multiplier) {
			if (multiplier != null) {
				ViewBag.RowsAffected = courseBo.UpdateCourseCredits(multiplier.Value);
			}
			return View();
		}
	}
}