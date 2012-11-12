using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using MvcApplication3.Models;
using MvcApplication3.BL;

namespace MvcApplication3.Controllers {
	public class DepartmentController : Controller {
		private DepartmentBo departmentBo;

		public DepartmentController() {
			departmentBo = new DepartmentBo(ModelState);
		}
		//
		// GET: /Department/

		public ActionResult Index() {
			var departments = departmentBo.Get(includeProperties: "Administrator");
			return View(departments.ToList());
		}

		//
		// GET: /Department/Details/5

		public ActionResult Details(int id = 0) {
			Department department = departmentBo.GetByID(id);
			if (department == null) {
				return HttpNotFound();
			}
			return View(department);
		}

		//
		// GET: /Department/Create

		public ActionResult Create() {
			InstructorBo instBo = new InstructorBo(ModelState);

			ViewBag.PersonID = new SelectList(instBo.Get(orderBy: q => q.OrderBy(d => d.LastName)), "PersonID ", "FullName");
			return View();
		}

		//
		// POST: /Department/Create

		[HttpPost]
		public ActionResult Create(Department department) {

			if (departmentBo.Insert(department)) {
				return RedirectToAction("Index");
			}

			InstructorBo instBo = new InstructorBo(ModelState);

			ViewBag.PersonID = new SelectList(instBo.Get(orderBy: q => q.OrderBy(d => d.LastName)), "PersonID ", "FullName", department.PersonID);
			return View(department);
		}

		//
		// GET: /Department/Edit/5

		public ActionResult Edit(int id = 0) {
			Department department = departmentBo.GetByID(id);
			if (department == null) {
				return HttpNotFound();
			}

			InstructorBo instBo = new InstructorBo(ModelState);
			ViewBag.PersonID = new SelectList(instBo.Get(orderBy: q => q.OrderBy(d => d.LastName)), "PersonID ", "FullName", department.PersonID);
			return View(department);
		}

		//
		// POST: /Department/Edit/5

		[HttpPost]
		public ActionResult Edit(Department department) {

			if (departmentBo.Update(department))
				return RedirectToAction("Index");

			InstructorBo instBo = new InstructorBo(ModelState);
			ViewBag.PersonID = new SelectList(instBo.Get(orderBy: q => q.OrderBy(d => d.LastName)), "PersonID ", "FullName", department.PersonID);

			return View(department);
		}

		//
		// GET: /Department/Delete/5

		public ActionResult Delete(int id, bool? concurrencyError) {

			if (concurrencyError.GetValueOrDefault()) {
				ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
					+ "was modified by another user after you got the original values. "
					+ "The delete operation was canceled and the current values in the "
					+ "database have been displayed. If you still want to delete this "
					+ "record, click the Delete button again. Otherwise "
					+ "click the Back to List hyperlink.";
			}

			Department department = departmentBo.GetByID(id);
			if (department == null) {
				return HttpNotFound();
			}
			return View(department);
		}

		//
		// POST: /Department/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id) {
			try {
				departmentBo.Delete(id);
				return RedirectToAction("Index");
			/*} catch (DbUpdateConcurrencyException) {
				return RedirectToAction("Delete",
					new System.Web.Routing.RouteValueDictionary { { "concurrencyError", true } });*/
			} catch (DataException de) {
				//Log the error (add a variable name after Exception)
				ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
				return View(departmentBo.GetByID(id));
			}
		}

		protected override void Dispose(bool disposing) {
			departmentBo.Dispose();
			base.Dispose(disposing);
		}


	}
}