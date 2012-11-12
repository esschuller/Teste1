using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MvcApplication3.DAL;
using MvcApplication3.Models;

namespace MvcApplication3.BL {
	public class DepartmentBo : BusinessBase<Department> {
		public DepartmentBo(ModelStateDictionary modelState)
			: base(modelState) {
		}

		public override bool Update(Department entityToUpdate) {

			if (modelState.IsValid) {
				ValidateOneAdministratorAssignmentPerInstructor(entityToUpdate);
			}

			return base.Update(entityToUpdate);
		}


		private void ValidateOneAdministratorAssignmentPerInstructor(Department department) {

			if (department.PersonID != null) {
				var duplicateDepartment = this.context.Departments
					.Include("Administrator")
					.Where(d => d.PersonID == department.PersonID)
					.AsNoTracking()
					.FirstOrDefault();

				if (duplicateDepartment != null && duplicateDepartment.DepartmentID != department.DepartmentID) {
					var errorMessage = String.Format(
						"Instructor {0} {1} is already administrator of the {2} department.",
						duplicateDepartment.Administrator.FirstMidName,
						duplicateDepartment.Administrator.LastName,
						duplicateDepartment.Name);
					this.modelState.AddModelError(string.Empty, errorMessage);
				}
			}
		}
	}
}